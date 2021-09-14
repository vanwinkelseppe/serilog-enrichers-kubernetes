using Serilog.Events;
using Serilog.Tests.Fixtures;
using Serilog.Tests.Support;
using Xunit;

namespace Serilog.Tests.Enrichers
{
    public class KubernetesPodUIDEnricherWithFilesTests : IClassFixture<FileTestFixture>
    {
        [Fact]
        public void KubernetesPodUIDEnricherIsApplied()
        {
            LogEvent evt = null;
            var log = new LoggerConfiguration()
                .Enrich.WithK8sPodUID(DownwardApiMethod.File, filePath: FileTestFixture.FilePath)
                .WriteTo.Sink(new DelegatingSink(e => evt = e))
                .CreateLogger();

            log.Information(@"Has a K8sPodUID property");

            Assert.NotNull(evt);

            Assert.Equal(FileTestFixture.FileContents,(string)evt.Properties["K8sPodUID"].LiteralValue());
        }
    }
}