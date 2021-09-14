using System;
using Serilog.Configuration;
using Serilog.Enrichers;

namespace Serilog
{
    /// <summary>
    /// Extends <see cref="LoggerConfiguration"/> to add enrichers related to process.
    /// capabilities.
    /// </summary>
    public static class KubernetesLoggerConfigurationExtensions
    {
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod Namespace. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodNamespace(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= "POD_NAMESPACE", string filePath = "/etc/podinfo/namespace")
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodNamespace",downwardApiMethod, environmentVariableName, filePath));
        }
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod Name. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodName(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= "POD_NAMES", string filePath = "/etc/podinfo/name")
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodName",downwardApiMethod, environmentVariableName, filePath));
        }
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod UID. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodUID(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= "POD_UID", string filePath = "/etc/podinfo/uid")
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodUID",downwardApiMethod, environmentVariableName, filePath));
        }
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod Node Name. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodNodeName(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= "POD_NODE_NAME", string filePath = "/etc/podinfo/node_name")
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodNodeName",downwardApiMethod, environmentVariableName, filePath));
        }
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod Service Account Name. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodServiceAccountName(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= "POD_SERVICEACCOUNT_NAME", string filePath = "/etc/podinfo/serviceaccount_name")
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodServiceAccountName",downwardApiMethod, environmentVariableName, filePath));
        }
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod Host IP. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodHostIP(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= "POD_HOST_IP", string filePath = "/etc/podinfo/host_ip")
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodHostIP",downwardApiMethod, environmentVariableName, filePath));
        }
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod IP. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodIP(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= "POD_IP", string filePath = "/etc/podinfo/ip")
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodIP",downwardApiMethod, environmentVariableName, filePath));
        }
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod CPU Limit. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodCPULimit(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= "POD_CPU_LIMIT", string filePath = "/etc/podinfo/cpu_limit")
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodCPULimit",downwardApiMethod, environmentVariableName, filePath));
        }
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod CPU Request. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodCPURequest(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= "POD_CPU_REQUEST", string filePath = "/etc/podinfo/cpu_request")
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodCPURequest",downwardApiMethod, environmentVariableName, filePath));
        }
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod Memory Limit. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodMemoryLimit(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= "POD_MEMORY_LIMIT", string filePath = "/etc/podinfo/memory_limit")
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodMemoryLimit",downwardApiMethod, environmentVariableName, filePath));
        }
        /// <summary>
        /// Enriches log events with the current Kubernetes Pod Memory Request. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="downwardApiMethod">Downward Api method, defaults to File method.</param>
        /// <param name="environmentVariableName">Custom environment variable name, if you do not use the default.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodMemoryRequest(this LoggerEnrichmentConfiguration enrichmentConfiguration, DownwardApiMethod downwardApiMethod = DownwardApiMethod.File, string environmentVariableName= "POD_MEMORY_REQUEST", string filePath = "/etc/podinfo/memory_request")
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodInformationEnricher("K8sPodMemoryRequest",downwardApiMethod, environmentVariableName, filePath));
        }
        

        /// <summary>
        /// Enriches log events with the current Kubernetes Pod information property that is given. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/"/>
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
        /// Enriches log events with the current Kubernetes Pod Annotations. The process works only when you use the Downward api
        /// <see href="https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/"/>
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="filePath">Custom path to the podinfo file, if you do not use the default.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithK8sPodAnnotations(this LoggerEnrichmentConfiguration enrichmentConfiguration, string filePath = "/etc/podinfo/annotations")
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
        public static LoggerConfiguration WithK8sPodLabels(this LoggerEnrichmentConfiguration enrichmentConfiguration, string filePath = "/etc/podinfo/labels")
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new KubernetesPodLabelsEnricher(filePath));
        }

        
    }
}
