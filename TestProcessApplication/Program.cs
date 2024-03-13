// See https://aka.ms/new-console-template for more information

string pathFiles = @"C:\Users\Marcos Anaya\Downloads\";

List<string> fileNames = ["265953.xml", "265954.xml"];

Dictionary<string,string> tagList = [];

foreach (var file in fileNames)
{
    string fullnameFile = string.Concat(pathFiles, file);

    Console.WriteLine("Reading file in : {0}", fullnameFile);

    if (File.Exists(fullnameFile))
    {
        using (StreamReader sr = new(fullnameFile))
        {
            string? line;
            int lineNumber = 0;

            while ((line = sr.ReadLine()) != null)
            {
                AnalizaTag(line);
            }
            Console.WriteLine("{0} tag's recolectados", tagList.Count);
            sr.Close();
        }
    }
}

foreach (var tag in tagList)
{
    Console.WriteLine(tag);
}
Console.ReadLine();

void AnalizaTag(string line)
{
    if (line != null)
        if(line.Length > 0)
        {
            int startposition = 0;
            int endposition = 0;
            bool initTag = false;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '<')
                {
                    startposition = i;
                    initTag = true;
                }

                if (line[i] == ' ' || line[i] == '>')
                    if (initTag)
                        endposition = i;

                if (line[i] == '?' || line[i] == '/')
                {
                    startposition = 0;
                    endposition = 0;
                    initTag=false;
                }

                if (endposition > 0 && initTag)
                {
                    string tagName = line.Substring(startposition + 1, endposition - startposition-1);

                    if (tagName.Length > 0)
                    {
                        //Console.WriteLine("Agregando tag: {0}", tagName);
                        tagList.TryAdd(tagName, tagName);
                    }

                    startposition = 0;
                    endposition = 0;
                    initTag = false;
                }
            }
        }
}