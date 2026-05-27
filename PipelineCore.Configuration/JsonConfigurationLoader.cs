using System;
using PipelineCore.Abstractions;

namespace PipelineCore.Configuration;

public class JsonConfigurationLoader : IConfigurationLoader
{
    public IConfigData LoadConfiguration(string filePath)
    {
        // Implement JSON loading logic here
        throw new NotImplementedException("JSON configuration loading not implemented yet.");
    }

    public IConfigData LoadConfiguration(Stream configStream)
    {
        // Implement JSON loading logic from stream here
        throw new NotImplementedException("JSON configuration loading from stream not implemented yet.");
    }

}
