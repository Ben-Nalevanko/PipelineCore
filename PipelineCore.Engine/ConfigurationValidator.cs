using System;
using PipelineCore.Abstractions;
using PipelineCore.Domain;
using PipelineCore.Domain.Enums;

namespace PipelineCore.Engine;

public class ConfigurationValidator : IValidator
{
    public ValidationResult ValidateConfiguration(ConfigData configData)
    {
        return new ValidationResult(ValidationStatus.None); // Placeholder implementation
    }
}
