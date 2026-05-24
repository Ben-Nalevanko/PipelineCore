using System;
using PipelineCore.Abstractions;
using PipelineCore.Domain;

namespace PipelineCore.Execution;

public class PipelineDefinitionFactory
{
    public PipelineDefinition CreatePipelineDefinition(IConfigData configData, IValidator validator)
    {
        if(configData == null)
        {
            throw new ArgumentNullException(nameof(configData));
        }
        if(validator == null)
        {
            throw new ArgumentNullException(nameof(validator));
        }

        if (!validator.ValidateConfiguration(configData))
        {
            throw new ArgumentException("Invalid configuration data.");
        }

        // Temporary for MVP, flesh out logic later
        return new PipelineDefinition();
    }
}
