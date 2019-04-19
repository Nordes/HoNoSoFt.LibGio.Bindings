using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace HoNoSoFt.LibGio.IntegrationTests.Fixtures
{
    /// <summary>
    /// Some documentation about fixture: https://xunit.github.io/docs/shared-context
    /// </summary>
    public class GSchemaFixture : IDisposable
    {
        private static object _lockObject = new object();

        private string SchemaPath { get; } = Path.Combine(Directory.GetCurrentDirectory(), "Assets/Schemas/");
        public string SchemaName { get; } = "com.honosoft.integration.with.path";
        private string _userSchemaFolder = "~/schemas/";
        private static bool _instantiationCompleted = false;

        private string IntegrationSchemaFullPath => Path.Combine(SchemaPath, $"{SchemaName}.gschema.xml");

        public GSchemaFixture()
        {
            if (Environment.OSVersion.Platform != PlatformID.Unix)
            {
                throw new NotSupportedException($"The OS {Environment.OSVersion.Platform} is not supported.");
            }

            if (!_instantiationCompleted)
            {
                lock (_lockObject)
                {
                    RegisterSchemas();
                    CompileSchemas();

                    _instantiationCompleted = true;
                }
            }
        }

        private void RegisterSchemas()
        {
            UpdateSchemaPaths();
        }

        private void CompileSchemas()
        {
            var tmp = new ProcessStartInfo
            {
                FileName = "/bin/sh",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardInput = true,
            };

            var process = new Process
            {
                StartInfo = tmp
            };

            process.Start();
            var commands = new List<string>();
            commands.Add($"glib-compile-schemas {SchemaPath}");
            commands.Add($"cp -v -f -s -r {SchemaPath}./ {_userSchemaFolder}");
            using (var sw = process.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    foreach (var command in commands)
                    {
                        Console.WriteLine(command);

                        sw.WriteLine(command);
                    }
                }
            }

            process.WaitForExit();
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            // Does not work in Win-10 SubSystem
            ////Environment.SetEnvironmentVariable("GSETTINGS_SCHEMA_DIR", _userSchemaFolder, EnvironmentVariableTarget.Process);
        }

        private void UpdateSchemaPaths()
        {
            var officialInstallPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "schemas/");
            var gSchemaXml = File.ReadAllText(IntegrationSchemaFullPath);
            gSchemaXml = gSchemaXml.Replace("%filepath%", officialInstallPath);
            File.WriteAllText(IntegrationSchemaFullPath, gSchemaXml);
        }

        public void Dispose()
        {
            // Todo... delete the schema files.
        }
    }
}
