using System;
using PipelineCore.Abstractions;
using PipelineCore.Domain;
using PipelineCore.Domain.Enums;

namespace PipelineCore.Engine;

public class ConfigurationValidator : IValidator
{
    public ValidationResult ValidateConfiguration(IConfigData configData)
    {
        return new ValidationResult(ValidationStatus.None); // Placeholder implementation
    }
}
