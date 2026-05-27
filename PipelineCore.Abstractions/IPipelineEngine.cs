using PipelineCore.Domain;
using System;

namespace PipelineCore.Abstractions;

public interface IPipelineEngine
{ 
    PipelineExecution pipelineExecution {get; set;}
    PipelineDefinition pipelineDefinition {get; }

    Task ExecuteAsync(PipelineExecution execution);
}
