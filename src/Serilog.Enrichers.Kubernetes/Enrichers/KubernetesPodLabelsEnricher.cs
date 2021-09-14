using System;
using System.Collections.Generic;
using System.IO;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    /// <summary>
    /// Enriches log events with the current Kubernetes Pod Labels. The process works only when you use the Downward api
    /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
    /// </summary>
    public class KubernetesPodLabelsEnricher : ILogEventEnricher
    {
        private List<LogEventProperty> _cachedProperties;
        private readonly string _filePath;

        public KubernetesPodLabelsEnricher( string filepath )
        {
            _filePath = filepath;
        }

        /// <summary>
        /// The property name added to enriched log events.
        /// </summary>
        public const string KubernetesPodLabelBaseName = "KubernetesPodLabel-";
        
        /// <summary>
        /// Enrich the log event.
        /// </summary>
        /// <param name="logEvent">The log event to enrich.</param>
        /// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (_cachedProperties == null)
            {
                _cachedProperties = new List<LogEventProperty>();
                var annotations = GetKubernetesLabels();
                foreach (var annotation in annotations)
                {
                 _cachedProperties.Add(propertyFactory.CreateProperty($"{KubernetesPodLabelBaseName}-{annotation.Key}", annotation.Value));   
                }
            }

            foreach (var cachedProperty in _cachedProperties)
            {
                logEvent.AddPropertyIfAbsent(cachedProperty);
            }
        }

        private IDictionary<string, string> GetKubernetesLabels()
        {
            var labels = new Dictionary<string, string>();
            if (File.Exists(_filePath))
            {
                var lines = File.ReadAllLines(_filePath);
                foreach (var line in lines)
                {
                    var labelPart = line.Split(new[] {'='}, 2);
                    labels.Add(labelPart[0], labelPart[1]);
                }
            }

            return labels;
        }
    }
}