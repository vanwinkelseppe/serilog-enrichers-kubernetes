using System;

namespace Serilog.Tests.Fixtures
{
    internal class EnvironmentVariableTestFixture : IDisposable
    {
        public const string VariableName = "SERILOG_POD_TEST";
        public const string VariableValue = "Serilog";

        public EnvironmentVariableTestFixture()
        {
            Environment.SetEnvironmentVariable(VariableName, VariableValue);
        }

        public void Dispose()
        {
            Environment.SetEnvironmentVariable(VariableName, null);
        }
    }
}