using System;
using PipelineCore.Abstractions;
using System.Text.Json;
using PipelineCore.Domain;

namespace PipelineCore.Configuration;

public class JsonConfigurationLoader : IConfigurationLoader
{
    public ConfigData LoadConfiguration(string filePath)
    {
        // // Implement JSON loading logic here
        // throw new NotImplementedException("JSON configuration loading not implemented yet.");

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true
        };
        ConfigData configData;
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            configData = JsonSerializer.Deserialize<ConfigData>(fs, options) ?? throw new Exception("Failed to load configuration. Invalid JSON file.");
        }

        return configData;
    }

    public ConfigData LoadConfiguration(Stream configStream)
    {
        // Implement JSON loading logic from stream here
        throw new NotImplementedException("JSON configuration loading from stream not implemented yet.");
    }

}
