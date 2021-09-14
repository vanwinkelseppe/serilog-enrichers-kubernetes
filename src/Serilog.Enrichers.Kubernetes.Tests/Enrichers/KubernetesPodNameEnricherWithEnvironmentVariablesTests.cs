using Serilog.Events;
using Serilog.Tests.Fixtures;
using Serilog.Tests.Support;
using Xunit;

namespace Serilog.Tests.Enrichers
{
    public class KubernetesPodNameEnricherWithEnvironmentVariablesTests : IClassFixture<EnvironmentVariableTestFixture>
    {
        //Due the fact we are not mocking the File
        [Fact]
        public void KubernetesNameEnricherIsApplied()
        {
            LogEvent evt = null;
            var log = new LoggerConfiguration()
                .Enrich.WithK8sPodName(DownwardApiMethod.EnvironmentVariable, environmentVariableName: EnvironmentVariableTestFixture.VariableName)
                .WriteTo.Sink(new DelegatingSink(e => evt = e))
                .CreateLogger();

            log.Information(@"Has a K8sPodName property");

            Assert.NotNull(evt);

            Assert.Equal(EnvironmentVariableTestFixture.VariableValue,(string)evt.Properties["K8sPodName"].LiteralValue());
        }
    }
}