using PipelineCore.Domain;

namespace PipelineCore.Abstractions;

public interface IPipelineEngine
{ 
    PipelineExecution pipelineExecution {get; set;}
    PipelineDefinition pipelineDefinition {get; set;}
    bool ExecutePipeline();
}
