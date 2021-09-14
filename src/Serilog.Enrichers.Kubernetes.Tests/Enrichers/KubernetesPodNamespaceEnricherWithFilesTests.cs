using Serilog.Events;
using Serilog.Tests.Fixtures;
using Serilog.Tests.Support;
using Xunit;

namespace Serilog.Tests.Enrichers
{
    public class KubernetesPodNamespaceEnricherWithFilesTests : IClassFixture<FileTestFixture>
    {
        [Fact]
        public void KubernetesPodNamespaceEnricherIsApplied()
        {
            LogEvent evt = null;
            var log = new LoggerConfiguration()
                .Enrich.WithK8sPodNamespace(DownwardApiMethod.File, filePath: FileTestFixture.FilePath)
                .WriteTo.Sink(new DelegatingSink(e => evt = e))
                .CreateLogger();

            log.Information(@"Has a K8sPodNamespace property");

            Assert.NotNull(evt);

            Assert.Equal(FileTestFixture.FileContents,(string)evt.Properties["K8sPodNamespace"].LiteralValue());
        }
    }
}