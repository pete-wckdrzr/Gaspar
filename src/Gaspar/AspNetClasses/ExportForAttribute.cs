﻿using System;
using WCKDRZR.Gaspar.Models;

namespace WCKDRZR.Gaspar
{
    public class ExportForAttribute : Attribute
    {
        public ExportForAttribute(GasparType types) { }

        public string ReturnTypeOverride { get; set; }

        public string Serializer { get; set; }

        public string[] ScopesOveride { get; set; } //not figured this out yet; but needs to be an option like this...
    }

    public class ExportOptionsAttribute : Attribute
    {
        public string ReturnTypeOverride { get; set; }

        public string Serializer { get; set; }

        public string[] ScopesOveride { get; set; } //not figured this out yet; but needs to be an option like this...
    }

    [Flags]
    public enum GasparType
    {
        All = 1 << 0,
        FrontEnd = 1 << 1,

        Angular = 1 << 2,
        CSharp = 1 << 3,
        Ocelot = 1 << 4,
        TypeScript = 1 << 5,
        Proto = 1 << 6,
    }
}