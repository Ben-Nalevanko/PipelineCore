using System.Collections.Generic;
using PipelineCore.Abstractions;

namespace PipelineCore.Domain;

public class PipelineDefinition
{
    private IList<IStep> _steps = new List<IStep>();

    public IList<IStep> Steps 
    { 
        get
        {
            return(_steps); 
        }
        set 
        {
            if(_steps != value)
            {
                _steps = value;
            }
        }
}

    public PipelineDefinition()
    {
        Steps = new List<IStep>();
    }
}

