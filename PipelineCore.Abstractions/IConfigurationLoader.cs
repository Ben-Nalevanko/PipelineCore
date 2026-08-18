using System;
using PipelineCore.Domain;

namespace PipelineCore.Abstractions;

public interface IConfigurationLoader
{
    public ConfigData LoadConfiguration(string filePath);

    public ConfigData LoadConfiguration(Stream configStream);
}
