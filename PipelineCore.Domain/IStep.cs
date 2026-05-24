using System;
using PipelineCore.Domain;
namespace PipelineCore.Abstractions;

public interface IStep
{
    bool Execute(object context);
}
