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
    private readonly object lockObject = new();

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
                    AddPipeline(pipelineEngine);
                    try
                    {
                        pipelineEngine.ExecutePipeline(cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Pipeline execution failed: {ex.Message}");

                    }
                    RemovePipeline(pipelineEngine);
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

    public void StopAllPipelines()
    {
        cancellationTokenSource.Cancel();
        Console.WriteLine("All pipelines have been stopped.");
    }

    private void AddPipeline(IPipelineEngine pipelineEngine)
    {
        lock (lockObject)
        {
            activeExecutions.Add(pipelineEngine);
        }
    }
    private void RemovePipeline(IPipelineEngine pipelineEngine)
    {
        lock (lockObject)
        {
            activeExecutions.Remove(pipelineEngine);
        }
    }
}
