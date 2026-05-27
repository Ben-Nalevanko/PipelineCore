using System;
using PipelineCore.Abstractions;

namespace PipelineCore.Configuration;

public class YamlConfigurationLoader : IConfigurationLoader
{
    public IConfigData LoadConfiguration(string filePath)
    {
        // Implement YAML loading logic here
        // For now, return null or a mock IConfigData implementation
        return null;
    }

    public IConfigData LoadConfiguration(Stream configStream)
    {
        // Implement YAML loading logic from stream here
        // For now, return null or a mock IConfigData implementation
        return null;
    }
}
