using System;

namespace PipelineCore.Abstractions;

public interface IConfigurationLoader
{
    public IConfigData LoadConfiguration(string filePath);

    public IConfigData LoadConfiguration(Stream configStream);
}
