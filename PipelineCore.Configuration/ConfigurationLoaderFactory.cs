using System;
using PipelineCore.Abstractions;

namespace PipelineCore.Configuration;

public static class ConfigurationLoaderFactory
{
    public static IConfigurationLoader GetConfigurationLoader(string filepath)
    {
        switch(filepath)
        {
            case string s when s.EndsWith(".json", StringComparison.OrdinalIgnoreCase):
                return new JsonConfigurationLoader();
            case string s when s.EndsWith(".yaml", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".yml", StringComparison.OrdinalIgnoreCase):
                return new YamlConfigurationLoader();
            default:
                throw new NotSupportedException($"Unsupported configuration file format: {filepath}");
        }
    }
}
