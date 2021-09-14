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

### Defaults 
Property | File Path | Environment Variable
--- | --- | --- 
PodNamespace | `/etc/podinfo/namespace` | `POD_NAMESPACE`
PodName | `/etc/podinfo/name` | `POD_NAME`
PodUID | `/etc/podinfo/uid` | `POD_UID`
PodAnnotations | `/etc/podinfo/annotations` | /
PodLabels | `/etc/podinfo/labels` | /

```csharp
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.WithProcessId()
    .Enrich.WithProcessName()
    .CreateLogger();
```



Copyright &copy; 2021 Seppe Van Winkel - Provided under the [Apache License, Version 2.0](http://apache.org/licenses/LICENSE-2.0.html).