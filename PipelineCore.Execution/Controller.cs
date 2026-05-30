using System;
using PipelineCore.Engine;
using PipelineCore.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PipelineCore.Configuration;
using PipelineCore.Domain;

namespace PipelineCore.Execution;

public class Controller
{
    private List<IPipelineEngine> activeExecutions;
    private CancellationTokenSource cancellationTokenSource;
    private CancellationToken cancellationToken;

    public Controller()
    {
        cancellationTokenSource = new CancellationTokenSource();
        cancellationToken = cancellationTokenSource.Token;
        activeExecutions = new List<IPipelineEngine>();
    }

    private void StartPipelineExecution(string filepath)
    {
        IConfigurationLoader configLoader = ConfigurationLoaderFactory.GetConfigurationLoader(filepath);
        if (configLoader != null)
        {
            IConfigData configData = configLoader.LoadConfiguration(filepath);
            ConfigurationValidator validator = new ConfigurationValidator();

            PipelineDefinition pipelineDefinition = PipelineDefinitionFactory.CreatePipelineDefinition(configData, validator);
            if (pipelineDefinition == null)
            {
                throw new Exception("Pipeline definition creation failed. Invalid configuration.");
            }
            var pipelineEngine = new LinearPipelineEngine(new PipelineExecution(), pipelineDefinition);
            if (pipelineEngine != null)
            {
                Task.Run(() =>
                {
                    activeExecutions.Add(pipelineEngine);

                    try
                    {
                        pipelineEngine.ExecutePipeline(cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Pipeline execution failed: {ex.Message}");

                    }
                    activeExecutions.Remove(pipelineEngine);
                });
            }
            else
            {
                throw new Exception("Failed to initialize pipeline engine. Invalid configuration.");
            }
        }
        else
        {
            throw new Exception("Failed to initialize configuration loader.");
        }
    }
    
    public void Execute(string filepath)
    {
        StartPipelineExecution(filepath);
    }
}
