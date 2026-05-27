using System;

namespace PipelineCore.Domain;

public class PipelineExecution
{
    private Dictionary<string, object> _context;
    
    public PipelineExecution()
    {
        _context = new Dictionary<string, object>();
    }

    public object GetKey(string key)
    {
        var retval = _context.TryGetValue(key, out var value) ? value : null;
        if(retval == null)
        {
            throw new KeyNotFoundException($"The key '{key}' was not found in the context.");
        }
        return retval;
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
