using System;
using System.IO;

namespace Serilog.Tests.Fixtures
{
    internal class FileTestFixture : IDisposable
    {
        public static string FilePath;
        public const string FileContents = "Serilog";

        public FileTestFixture()
        {
            FilePath = $"{Directory.GetCurrentDirectory()}/POD_FILE";
            File.WriteAllText(FilePath,FileContents);
        }

        public void Dispose()
        {
            File.Delete(FilePath);
        }
    }
}