using Serilog.Events;
using Serilog.Tests.Fixtures;
using Serilog.Tests.Support;
using Xunit;

namespace Serilog.Tests.Enrichers
{
    public class KubernetesPodUIDEnricherWithEnvironmentVariablesTests : IClassFixture<EnvironmentVariableTestFixture>
    {
        //Due the fact we are not mocking the File
        [Fact]
        public void KubernetesUIDEnricherIsApplied()
        {
            LogEvent evt = null;
            var log = new LoggerConfiguration()
                .Enrich.WithK8sPodUID(DownwardApiMethod.EnvironmentVariable, environmentVariableName: EnvironmentVariableTestFixture.VariableName)
                .WriteTo.Sink(new DelegatingSink(e => evt = e))
                .CreateLogger();

            log.Information(@"Has a K8sPodUID property");

            Assert.NotNull(evt);

            Assert.Equal(EnvironmentVariableTestFixture.VariableValue,(string)evt.Properties["K8sPodUID"].LiteralValue());
        }
    }
}