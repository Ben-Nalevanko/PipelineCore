using System;
using PipelineCore.Domain;

namespace PipelineCore.Abstractions;

public interface IStep
{
    StepResult Execute(PipelineCore.Domain.PipelineExecution context);
}
