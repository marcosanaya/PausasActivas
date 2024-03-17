// See https://aka.ms/new-console-template for more information
using ConsoleForLinux.Business;
using ConsoleForLinux.Clases;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

ProcessParams infoParams;
DateTime startTime = DateTime.Now;

var dspaceManager = DSpaceAPIManager.GetInstance();
var fileManager = FileResourcesManager.GetInstance();

RunCommandWithBash("clear");
Console.Clear();
Console.WriteLine("Process to Attach resources from AtoM folders to DSpace.");
Console.WriteLine("");
Console.WriteLine("reading params for process...");

var currentDirectory  = Directory.GetCurrentDirectory();
infoParams = ReadingParams();

dspaceManager.StartProcess();

Thread mp = new(mainProcess);
mp.Start();

CompleteParams();



void mainProcess()
{
    Thread dspaceData = new(CollectDataFromDSpace);
    dspaceData.Start();

    Thread filesystemData = new(CollectDataFromFileSystem);
    filesystemData.Start();

    while (true)
        if (!dspaceManager.IsStillRunning())
        {
            //Console.WriteLine(JsonSerializer.Serialize(infoParams));
            Console.WriteLine("Fin del proceso");
            Console.WriteLine("Duración: {0}", DateTime.Now - startTime);
            Environment.Exit(0);
        }
}

void CollectDataFromFileSystem()
{
    var exceptionManager = GenericsManager.GetInstance();

    while (true)
        if (CanLogin())
        {
            break;
        }

    try
    {
        fileManager.SetParamProcess(infoParams);
        Console.WriteLine("Reading Folders from {0}", fileManager.GetResourcePath());

        fileManager.SearchPDFFiles(fileManager.GetResourcePath());
        fileManager.SearchImageFiles();
        fileManager.CalculatingHasFromFileSystem();
        fileManager.StopProcess();
    }
    catch (Exception e)
    {
        GenericsManager.PrintExceptionMessage(e);
    }
}

void CollectDataFromDSpace()
{
    var exceptionManager = GenericsManager.GetInstance();

    while (true)
        if (CanLogin())
        {
            break;
        }
    try
    {
        Console.WriteLine("Doing login at DSpace...");
        dspaceManager.SetParamProcess(infoParams);
        Console.WriteLine("Getting Session Token...");
        dspaceManager.RequestXSRFTOKEN();
        dspaceManager.MakeLogin();

        Console.WriteLine("Reading Collections from DSpace...");
        dspaceManager.GetResponseProcessed(RequestType.ForDSpaceCollections);
        Console.WriteLine("Validating collections...");
        dspaceManager.ValidateFilterCollections();

        Console.WriteLine("Reading Items for Collections Validated from DSpace...");        
        dspaceManager.ProcessesItemsCollectionsValidated();

        while (true)
            if (!fileManager.IsStillRunning())
            {
                break;
            }
        
        var filesScanned = fileManager.GetPDFPathFiles();
        dspaceManager.AttacheImageFromFiles(filesScanned);
        dspaceManager.StopProcess();
    }
    catch (Exception e)
    {
        GenericsManager.PrintExceptionMessage(e);
    }
}

bool CanLogin()
{
    bool result;

    if (infoParams.UseProxy.HasValue)
    {
        if (infoParams.UseProxy.Value)
        {
            result = infoParams.User.Length > 0
            && infoParams.Password.Length > 0
            && infoParams.ProxyPassword.Length > 0
            && infoParams.ProxyUser.Length > 0;
        }
        else
            result = infoParams.User.Length > 0 && infoParams.Password.Length > 0;
    }
    else
        result = false;

    return result;
}

string RunCommandWithBash(string command)
{
    var psi = new ProcessStartInfo();
    string result = string.Empty;
    psi.FileName = "/bin/bash";
    psi.Arguments = command;
    psi.RedirectStandardOutput = true;
    psi.UseShellExecute = false;
    psi.CreateNoWindow = true;

    if (OperatingSystem.IsLinux())
        using (var process = Process.Start(psi))
        {
            if (process == null)
                return string.Empty;

            process.WaitForExit();
            result = process.StandardOutput.ReadToEnd() ?? string.Empty;
        }
    return result;
}

void CompleteParams()
{
    if (infoParams != null)
    {
        while (string.IsNullOrEmpty(infoParams.ResourcePath))
        {
            Console.Write("Input Resource Path to Attach: ");
            infoParams.ResourcePath = Console.ReadLine() ?? string.Empty;
        }
        while (string.IsNullOrEmpty(infoParams.Host))
        {
            Console.Write("Input DSpace URL: ");
            infoParams.Host= Console.ReadLine() ?? string.Empty;
        }
        while (string.IsNullOrEmpty(infoParams.User))
        {
            Console.Write("User to Login in Host: ");
            infoParams.User = Console.ReadLine() ?? string.Empty;
        }
        while (string.IsNullOrEmpty(infoParams.Password))
        {
            Console.Write("Password To User: ");
            var keypresed = Console.ReadKey(true);
            List<char> tmppass = [];
            while (keypresed.KeyChar != 13)
            {
                tmppass.Add(keypresed.KeyChar);
                keypresed = Console.ReadKey(true);
            }
            infoParams.Password = string.Concat(tmppass);
        }
        while (infoParams.Collections.Count == 0)
        {
            Console.WriteLine("Input Embedded ID(s): ");
            Console.Write("input * to finish-> ");
            string collectionID = Console.ReadLine() ?? string.Empty;
            while (!collectionID.Equals("*"))
            {
                infoParams.Collections.Add(collectionID);
                Console.Write("input * to finish-> ");
                collectionID = Console.ReadLine() ?? string.Empty;
            }
        }

        while (!infoParams.UseProxy.HasValue)
        {
            do
            {
                Console.Write("Using Proxy for this execution (true/false)? : ");
                string useproxy = Console.ReadLine() ?? string.Empty;
                
                if (bool.TryParse(useproxy, out bool useproxyresult))
                {
                    infoParams.UseProxy = useproxyresult;
                    if (useproxyresult)
                    {
                        while (string.IsNullOrEmpty(infoParams.ProxyUser))
                        {
                            Console.Write("User for Proxy: ");
                            infoParams.ProxyUser = Console.ReadLine() ?? string.Empty;
                        }
                        while (string.IsNullOrEmpty(infoParams.ProxyPassword))
                        {
                            Console.Write("Password for User Proxy: ");
                            var keypresed = Console.ReadKey(true);
                            List<char> tmppass = [];
                            while (keypresed.KeyChar != 13)
                            {
                                tmppass.Add(keypresed.KeyChar);
                                keypresed = Console.ReadKey(true);
                            }
                            infoParams.ProxyPassword = string.Concat(tmppass);
                        }
                    }
                }
            } while (!infoParams.UseProxy.HasValue);
        }

        List<string> norepeatcollections = [];
        infoParams.Collections.ForEach(x =>
        {
            if (!norepeatcollections.Contains(x))
                norepeatcollections.Add(x);
        });
        infoParams.Collections = norepeatcollections;
    }
}

ProcessParams  ReadingParams()
{
    var exceptionManager = GenericsManager.GetInstance();
    List<string> rawlines;
    StringBuilder data = new();
    ProcessParams result = new();

    rawlines = File.ReadAllLines("ParamConfiguration.json").ToList() ?? [];
    rawlines.ForEach(x => data.AppendLine(x));

    string strInfo = data.ToString();

    try
    {
        result = JsonSerializer.Deserialize<ProcessParams>(strInfo, ParamsContext.Default.ProcessParams) ?? new();
        data.Clear();
    }
    catch (Exception e)
    {
        GenericsManager.PrintExceptionMessage(e);
    }

    return result;
}