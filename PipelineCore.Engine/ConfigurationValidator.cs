using System;
using PipelineCore.Abstractions;

namespace PipelineCore.Engine;

public class ConfigurationValidator : IValidator
{
    public bool ValidateConfiguration(IConfigData configData)
    {
        return true; // Placeholder implementation
    }
}
