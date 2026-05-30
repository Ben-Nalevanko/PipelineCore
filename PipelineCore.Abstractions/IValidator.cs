using System;
using PipelineCore.Domain;

namespace PipelineCore.Abstractions;

public interface IValidator
{
    ValidationResult ValidateConfiguration(IConfigData configData);
}
