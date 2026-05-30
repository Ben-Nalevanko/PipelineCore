using System;

namespace PipelineCore.Domain;

public class StepResult
{
    public bool Success { get; set; }
    public required string Message { get; set; }
    public required PipelineCore.Domain.PipelineExecution Context { get; set; }
}
