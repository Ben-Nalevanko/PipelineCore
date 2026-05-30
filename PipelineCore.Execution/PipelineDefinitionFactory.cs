using System;
using System.Security;
using PipelineCore.Abstractions;
using PipelineCore.Domain;
using PipelineCore.Domain.Enums;

namespace PipelineCore.Execution;

public static class PipelineDefinitionFactory
{
    public static PipelineDefinition CreatePipelineDefinition(IConfigData configData, IValidator validator)
    {
        if(configData == null)
        {
            throw new ArgumentNullException(nameof(configData));
        }
        if(validator == null)
        {
            throw new ArgumentNullException(nameof(validator));
        }

        if (validator.ValidateConfiguration(configData).ValidationStatus != ValidationStatus.Valid)
        {
            throw new Exception("PipelineDefinitionFactory.CreatePipelineDefinition: definition creation failed. Invalid configuration.");;
        }

        // Temporary for MVP, flesh out logic later
        return new PipelineDefinition();
    }
}
