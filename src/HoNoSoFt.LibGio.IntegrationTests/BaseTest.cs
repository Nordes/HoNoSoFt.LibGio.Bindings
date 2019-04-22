using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HoNoSoFt.LibGio.IntegrationTests
{
    public class BaseTest// : IDisposable
    {
        //private string _userSchemaFolder = "~/schemas/";
        //public string SchemaName { get; } = "com.honosoft.integration.with.path";

        ///// <summary>
        ///// After everytest we should do : GSETTINGS_SCHEMA_DIR=~/schemas/ gsettings reset-recursively com.honosoft.integration.with.path
        ///// </summary>
        //public void Dispose()
        //{
        //    var processStartInfo = new ProcessStartInfo
        //    {
        //        FileName = "/bin/sh",
        //        RedirectStandardOutput = true,
        //        RedirectStandardError = true,
        //        UseShellExecute = false,
        //        CreateNoWindow = true,
        //        RedirectStandardInput = true,
        //    };

        //    var process = new Process
        //    {
        //        StartInfo = processStartInfo
        //    };

        //    process.Start();
        //    var commands = new List<string>
        //    {
        //        $"gsettings reset-recursively {SchemaName}"
        //    };

        //    using (var sw = process.StandardInput)
        //    {
        //        if (sw.BaseStream.CanWrite)
        //        {
        //            foreach (var command in commands)
        //            {
        //                //Console.WriteLine(command);
        //                sw.WriteLine(command);
        //            }
        //        }
        //    }

        //    process.WaitForExit();
        //}
    }
}
