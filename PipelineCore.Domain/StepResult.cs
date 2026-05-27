using System;

namespace PipelineCore.Domain;

public class StepResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public PipelineCore.Domain.PipelineExecution Context { get; set; }
}
