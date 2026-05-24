using System;

namespace PipelineCore.Execution;

public class PipelineExecution
{
    private Dictionary<string, object> _context;
    
    public PipelineExecution()
    {
        _context = new Dictionary<string, object>();
    }

    public object GetKey(string key)
    {
        return _context.TryGet(key);
    }

    public bool HasKey(string key)
    {
        return _context.ContainsKey(key);
    }

    public void SetKey(string key, object value)
    {
        _context[key] = value;
    }
}
