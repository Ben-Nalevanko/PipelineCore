using PipelineCore.Abstractions;
using PipelineCore.Domain;
using System;
using System.Collections.Generic;

namespace PipelineCore.Engine;

public class LinearPipelineEngine : IPipelineEngine
{
    public PipelineExecution pipelineExecution { get; set; }
    public PipelineDefinition pipelineDefinition { get;}

    public LinearPipelineEngine(PipelineExecution execution, PipelineDefinition definition)
    {
        pipelineDefinition = definition;
        pipelineExecution = execution;
    }

    public Task ExecutePipeline(CancellationToken cancellationToken)
    {
        // Execute steps in order
        foreach (var step in pipelineDefinition.Steps)
        {
            if (step.Execute(pipelineExecution).Success)
            {
                break; // Stop execution if any step fails
            }
        }
        return Task.CompletedTask;
    }

    public Task ExecuteAsync(PipelineExecution execution)
    {
        // This method can be implemented to execute the pipeline asynchronously if needed
        throw new NotImplementedException();
    }

}
