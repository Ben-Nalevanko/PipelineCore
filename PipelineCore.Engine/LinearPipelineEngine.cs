using PipelineCore.Abstractions;
using PipelineCore.Domain;

namespace PipelineCore.Engine;

public class LinearPipelineEngine : IPipelineEngine
{
    public PipelineExecution pipelineExecution { get; set; }
    public PipelineDefinition pipelineDefinition { get; set; }

    public LinearPipelineEngine(PipelineDefinition definition)
    {
        pipelineDefinition = definition;
        pipelineExecution = new PipelineExecution();
    }
    public bool ExecutePipeline()
    {
        // Execute steps in order
        foreach (var step in pipelineDefinition.Steps)
        {
            if (!step.Execute(pipelineExecution))
            {
                return false; // Stop execution if any step fails
            }
        }

        return true; // All steps executed successfully
    }

}
