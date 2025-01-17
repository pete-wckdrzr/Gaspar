﻿using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WCKDRZR.Gaspar.Models
{
    internal class Model
    {
        public string ModelName { get; set; }
        public List<Property> Fields { get; set; }
        public List<Property> Properties { get; set; }
        public List<string> BaseClasses { get; set; }
        public Dictionary<string, object> Enumerations { get; set; }
        public bool IsInterface => Type == "interface";
        public OutputType ExportFor { get; set; }
        public string Type { get; set; }
    }

    internal class Property
    {
        public string Identifier { get; set; }
        public string Type { get; set; }

        public static implicit operator Property(PropertyDeclarationSyntax propertySyntax)
        {
            Property p = new();
            p.Identifier = propertySyntax.Identifier.ToString();
            p.Type = propertySyntax.Type.ToString();
            return p;
        }

        public static implicit operator Property(FieldDeclarationSyntax field)
        {
            Property p = new();
            p.Identifier = field.Declaration.Variables.First().GetText().ToString();
            p.Type = field.Declaration.Type.ToString();
            return p;
        }
    }
}