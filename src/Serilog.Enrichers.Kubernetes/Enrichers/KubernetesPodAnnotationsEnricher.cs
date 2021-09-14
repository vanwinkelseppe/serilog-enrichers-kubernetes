using System;
using System.Collections.Generic;
using System.IO;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    /// <summary>
    /// Enriches log events with the current Kubernetes Pod Annotations. The process works only when you use the Downward api
    /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
    /// </summary>
    public class KubernetesPodAnnotationsEnricher : ILogEventEnricher
    {
        private List<LogEventProperty> _cachedProperties;
        private readonly string _filePath;

        public KubernetesPodAnnotationsEnricher( string filepath )
        {
            _filePath = filepath;
        }

        /// <summary>
        /// The property name added to enriched log events.
        /// </summary>
        public const string KubernetesPodAnnotationBaseName = "KubernetesPodAnnotation-";
        
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
                var annotations = GetKubernetesAnnotations();
                foreach (var annotation in annotations)
                {
                 _cachedProperties.Add(propertyFactory.CreateProperty($"{KubernetesPodAnnotationBaseName}-{annotation.Key}", annotation.Value));   
                }
            }

            foreach (var cachedProperty in _cachedProperties)
            {
                logEvent.AddPropertyIfAbsent(cachedProperty);
            }
        }

        private IDictionary<string, string> GetKubernetesAnnotations()
        {
            var annotations = new Dictionary<string, string>();
            if (File.Exists(_filePath))
            {
                var lines = File.ReadAllLines(_filePath);
                foreach (var line in lines)
                {
                    //Skip last applied configuration
                    if(line.Contains("kubectl.kubernetes.io/last-applied-configuration")) continue;
                    var annotationPart = line.Split(new[] {'='}, 2);
                    annotations.Add(annotationPart[0], annotationPart[1]);
                }
            }

            return annotations;
        }
    }
}