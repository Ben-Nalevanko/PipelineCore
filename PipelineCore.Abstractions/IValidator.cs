using System;

namespace PipelineCore.Abstractions;

public interface IValidator
{
    bool ValidateConfiguration(IConfigData configData);
}
