namespace PipelineCore.Abstractions;

public interface IPipelineEngine
{
    void Execute(PipelineDefinition definition, PipelineExecution execution);
}
