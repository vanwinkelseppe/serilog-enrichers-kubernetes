# Serilog.Enrichers.Kubernetes


The Kubernetes enricher for Serilog. This enricher makes use of the Downward Api. Please make sure this is setup before trying to Enrich using this package!

- [Expose Pod Information to Containers Through Files](https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/)
- [Expose Pod Information to Containers Through Environment Variables](https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/)
 
[![NuGet Version](http://img.shields.io/nuget/v/Serilog.Enrichers.Kubernetes.svg?style=flat)](https://www.nuget.org/packages/Serilog.Enrichers.Kubernetes/)


## Installation
To use the enricher, first install the NuGet package:

```powershell
Install-Package Serilog.Enrichers.Kubernetes
```

```cmd
dotnet add package Serilog.Enrichers.Kubernetes
```

## Usage

Then add one of the following to the `LoggerConfiguration()`:
- `Enrich.WithK8sPodNamespace()`
- `Enrich.WithK8sPodName()`
- `Enrich.WithK8sPodUID()`
- `Enrich.WithK8sPodAnnotations()`
- `Enrich.WithK8sPodLabels()`
- `Enrich.WithK8sPodInformation("PropertyName", DownwardApiMethod.File, filePath: "/etc/podinfo/propertyname")` or `Enrich.WithK8sPodInformation("PropertyName", DownwardApiMethod.EnvironmentVariable, environmentVariableName: "POD_PROPERTYNAME")`

By default the Enrichers will be in `DownwardApiMethod.File` mode of the DownwardApi [Documentation File Method](https://kubernetes.io/docs/tasks/inject-data-application/downward-api-volume-expose-pod-information/). You can look which of the properties have a default set, you can also overide it.

You can also choose to use the Environment Variable way by using  `DownwardApiMethod.EnvironmentVariable`  [Documentation ENV](https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose-pod-information/). You can look which of the properties have a default set, you can also overide it.

## Downward api File mode

See `examples/full-example-downwardapi-file-mode.yaml`

Code usage | Default path | Kubernetes Configuration variable
--- | --- | --- 
`Enrich.WithK8sPodNamespace()` | `/etc/podinfo/namespace` | `fieldRef.fieldPath: metadata.namespace`
`Enrich.WithK8sPodName()` | `/etc/podinfo/name` | `fieldRef.fieldPath: metadata.name`
`Enrich.WithK8sPodUID()` | `/etc/podinfo/uid` | `fieldRef.fieldPath: metadata.uid`
`Enrich.K8sPodNodeName()` | `/etc/podinfo/node_name` | `fieldRef.fieldPath: spec.nodeName`
`Enrich.K8sPodHostIP()` | `/etc/podinfo/host_ip` | `fieldRef.fieldPath: status.hostIP`
`Enrich.K8sPodIP()` | `/etc/podinfo/ip` | `fieldRef.fieldPath: status.podIP`
`Enrich.K8sPodServiceAccountName()` | `/etc/podinfo/service_account_name` | `fieldRef.fieldPath: spec.serviceAccountName`
`Enrich.K8sPodCPULimit()` | `/etc/podinfo/cpu_limit` | `resourceFieldRef.resource: limits.cpu`
`Enrich.K8sPodCPURequest()` | `/etc/podinfo/cpu_request` | `resourceFieldRef.resource: requests.cpu`
`Enrich.K8sPodMemoryLimit()` | `/etc/podinfo/mem_limit` | `resourceFieldRef.resource: limits.memory`
`Enrich.K8sPodMemoryRequest()` | `/etc/podinfo/mem_request` | `resourceFieldRef.resource: requests.memory`
`Enrich.K8sPodEphemeralStorageLimit()` | `/etc/podinfo/ephemeral_storage_limit` | `resourceFieldRef.resource: limits.ephemeral-storage`
`Enrich.K8sPodEphemeralStorageRequest()` | `/etc/podinfo/ephemeral_storage_request`| `resourceFieldRef.resource: requests.ephemeral-storage`
`Enrich.KubernetesPodAnnotationsEnricher()` | `/etc/podinfo/annotations` | `fieldRef.fieldPath: status.annotations`
`Enrich.KubernetesPodLabelsEnricher()` | `/etc/podinfo/labels` | `fieldRef.fieldPath: status.labels`

## Downward api Environment Variable mode

See `examples/full-example-downwardapi-environment-variable-mode.yaml`

Code usage | Default path | Kubernetes Configuration variable
--- | --- | --- 
`Enrich.WithK8sPodNamespace(DownwardApiMethod.EnvironmentVariable)` | `POD_NAMESPACE` | `fieldRef.fieldPath: metadata.namespace`
`Enrich.WithK8sPodName(DownwardApiMethod.EnvironmentVariable)` | `/POD_NAME` | `fieldRef.fieldPath: metadata.name`
`Enrich.WithK8sPodUID(DownwardApiMethod.EnvironmentVariable)` | `POD_UID` | `fieldRef.fieldPath: metadata.uid`
`Enrich.K8sPodNodeName(DownwardApiMethod.EnvironmentVariable)` | `POD_NODE_NAME` | `fieldRef.fieldPath: spec.nodeName`
`Enrich.K8sPodHostIP(DownwardApiMethod.EnvironmentVariable)` | `POD_HOST_IP` | `fieldRef.fieldPath: status.hostIP`
`Enrich.K8sPodIP(DownwardApiMethod.EnvironmentVariable)` | `POD_IP` | `fieldRef.fieldPath: status.podIP`
`Enrich.K8sPodServiceAccountName(DownwardApiMethod.EnvironmentVariable)` | `POD_SERVICE_ACCOUNT_NAME` | `fieldRef.fieldPath: spec.serviceAccountName`
`Enrich.K8sPodCPULimit(DownwardApiMethod.EnvironmentVariable)` | `POD_CPU_LIMIT` | `resourceFieldRef.resource: limits.cpu`
`Enrich.K8sPodCPURequest(DownwardApiMethod.EnvironmentVariable)` | `POD_CPU_REQUEST` | `resourceFieldRef.resource: requests.cpu`
`Enrich.K8sPodMemoryLimit(DownwardApiMethod.EnvironmentVariable)` | `POD_MEMORY_LIMIT` | `resourceFieldRef.resource: limits.memory`
`Enrich.K8sPodMemoryRequest(DownwardApiMethod.EnvironmentVariable)` | `POD_MEMORY_REQUEST` | `resourceFieldRef.resource: requests.memory`
`Enrich.K8sPodEphemeralStorageLimit(DownwardApiMethod.EnvironmentVariable)` | `POD_EPHEMERAL_STORAGE_LIMIT` | `resourceFieldRef.resource: limits.ephemeral-storage`
`Enrich.K8sPodEphemeralStorageRequest(DownwardApiMethod.EnvironmentVariable)` | `POD_EPHEMERAL_STORAGE_REQUEST`| `resourceFieldRef.resource: requests.ephemeral-storage`



Copyright &copy; 2021 Seppe Van Winkel - Provided under the [Apache License, Version 2.0](http://apache.org/licenses/LICENSE-2.0.html).