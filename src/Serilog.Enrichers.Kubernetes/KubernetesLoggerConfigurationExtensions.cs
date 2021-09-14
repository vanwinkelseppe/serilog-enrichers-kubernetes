using System;
using Serilog.Configuration;
using Serilog.Enrichers;

namespace Serilog
{
    /// <summary>
    /// Extends <see cref="LoggerConfiguration"/> to add enrichers related to process.
    /// capabilities.
    /// </summary>
    public static class ProcessLoggerConfigurationExtensions
    {
        //POD NAMESPACE
        private const string KubernetesPodNamespaceFilePath = "/etc/podinfo/namespace";
        private const string KubernetesPodNamespaceEnvironmentVariable = "POD_NAMESPACE";
        
        //POD NAME
        private const string KubernetesPodNameFilePath = "/etc/podinfo/name";
        private const string KubernetesPodNameEnvironmentVariable = "POD_NAME";
        
        //POD UID
        private const string KubernetesPodUIDFilePath = "/etc/podinfo/uid";
        private const string KubernetesPodUIDEnvironmentVariable = "POD_UID";
        
        //POD Annotations
        private const string KubernetesPodAnnotationsFilePath = "/etc/podinfo/annotations";
        
        //POD Labels
        private const string KubernetesPodLabelsFilePath = "/etc/podinfo/labels";
        
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod Namespace. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodNamespace(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= KubernetesPodNamespaceEnvironmentVariable, string filePath = KubernetesPodNamespaceFilePath)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodNamespace",downwardApiMethod, environmentVariableName, filePath));
        }
        
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod Name. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodName(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= KubernetesPodNameEnvironmentVariable, string filePath = KubernetesPodNameFilePath)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodName",downwardApiMethod, environmentVariableName, filePath));
        }
        
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod UID. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodUID(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= KubernetesPodUIDEnvironmentVariable, string filePath = KubernetesPodUIDFilePath)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodUID",downwardApiMethod, environmentVariableName, filePath));
        }

        /// <summary>
        /// Enriches log events with the current Kubernetes Pod information property that is given. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="propertyName">Custom property that is not yet present in the Enricher package</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, cannot be null if DownwardApiMethod.EnvironmentVariable</param>
        /// <param name="filePath">Custom path to the podinfo file, cannot be null if DownwardApiMethod.File</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodInformation(this LoggerEnrichmentConfiguration enrichmentConfiguration,string propertyName, DownwardApiMethod downwardApiMethod, string environmentVariableName = "", string filePath = "")
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher(propertyName,downwardApiMethod, environmentVariableName, filePath));
        }
        
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod UID. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodInformation(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= KubernetesPodUIDEnvironmentVariable, string filePath = KubernetesPodUIDFilePath)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodUID",downwardApiMethod, environmentVariableName, filePath));
        }
        
        
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod Annotations. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodAnnotations(this LoggerEnrichmentConfiguration enrichmentConfiguration, string filePath = KubernetesPodAnnotationsFilePath)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodAnnotationsEnricher(filePath));
        }
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod Labels. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodLabels(this LoggerEnrichmentConfiguration enrichmentConfiguration, string filePath = KubernetesPodLabelsFilePath)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodLabelsEnricher(filePath));
        }
    }
}