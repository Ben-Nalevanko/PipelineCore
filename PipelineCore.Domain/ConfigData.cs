using System;

namespace PipelineCore.Domain;

public class ConfigData
{
    private Dictionary<string, object> _metadata { get; set; }

    public ConfigData()
    {
        _metadata = new Dictionary<string, object>();
    }
}
