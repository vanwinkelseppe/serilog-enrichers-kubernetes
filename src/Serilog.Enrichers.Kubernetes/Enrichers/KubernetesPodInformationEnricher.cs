using System;
using System.IO;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    /// <summary>
    /// Enriches log events with the current Kubernetes Pod information property that is given. The process works only when you use the Downward api
    /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
    /// </summary>
    public class KubernetesPodInformationEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;
        private readonly DownwardApiMethod _downwardApiMethod;
        private readonly string _propertyName;
        private readonly string _environmentVariableName;
        private readonly string _filePath;

        public KubernetesPodInformationEnricher(string propertyName, DownwardApiMethod downwardApiMethod, string environmentVariableName , string filepath )
        {
            _propertyName = propertyName;
            _downwardApiMethod = downwardApiMethod;
            _environmentVariableName = environmentVariableName;
            _filePath = filepath;
        }

        /// <summary>
        /// Enrich the log event.
        /// </summary>
        /// <param name="logEvent">The log event to enrich.</param>
        /// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            _cachedProperty ??= propertyFactory.CreateProperty(_propertyName, GetKubernetesData());
            logEvent.AddPropertyIfAbsent(_cachedProperty);
        }

        private string GetKubernetesData()
        {
            if (_downwardApiMethod == DownwardApiMethod.File)
            {
                if(File.Exists(_filePath))
                    return File.ReadAllText(_filePath);
                return $"The file {_filePath} was not found. Please make sure the downward api is configured properly.";
            }
            return Environment.GetEnvironmentVariable(_environmentVariableName);
        }
    }
}