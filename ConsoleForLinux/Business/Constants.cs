﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForLinux.Business
{
    public enum RequestType
    {
        ForDSpaceCollections,
        ForDSpaceItems
    }

    public enum HashDBDataStatus
    {
        NoData,
        DSpaceData,
        ResourceData,
        DataComplete
    }
}
