﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeAppMVC.Contracts
{
    public class ApiRoutes
    {

        public const string Root = "api";
        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class PokeApiCalls
        {
            public const string GetAll = Base + "/pokemon";

        }
    }
}
