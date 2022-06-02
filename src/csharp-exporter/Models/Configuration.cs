﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CSharpExporter.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OutputType
    {
        Angular,
        CSharp,
        Ocelot,
        TypeScript
    }

    public class Configuration
    {
        public string ConfigFilePath { get; set; }

        public ModelConfiguration Models { get; set; }
        public ControllerConfiguration Controllers { get; set; }

        public string OnlyWhenAttributed { get; set; }
        public bool UseAttribute => !string.IsNullOrEmpty(OnlyWhenAttributed);

        public Dictionary<string, string> CustomTypeTranslations { get; set; }
    }

    public class ConfigurationType
    {
        public List<string> Include { get; set; }
        public List<string> Exclude { get; set; }
        public List<ConfigurationTypeOutput> Output { get; set; }
    }

    public class ModelConfiguration : ConfigurationType
    {
        public bool CamelCaseEnums { get; set; }
        public bool NumericEnums { get; set; }
        public bool StringLiteralTypesInsteadOfEnums { get; set; }
    }

    public class ControllerConfiguration : ConfigurationType
    {
        public string Gateway { get; set; }
        public string ServiceName { get; set; }
        public int ServicePort { get; set; }
        public bool SecureService { get; set; }
    }

    public class ConfigurationTypeOutput
    {
        public OutputType Type { get; set; }
        public string Location { get; set; }
        public string HelperFile { get; set; }
        public string ModelPath { get; set; }

        //For Ocelot
        public bool NoAuth { get; set; }
        public bool ExcludeScopes { get; set; }
    }
}