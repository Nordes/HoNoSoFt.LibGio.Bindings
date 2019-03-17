using System;

namespace HoNoSoFt.LibGio.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Schema to look: ");
            var gSettingsSchema = Console.ReadLine();
            Console.Write("Key to look: ");
            var gSettingsKey = Console.ReadLine();

            var gSettings = new Bindings.GSettings(gSettingsSchema);
            var result = gSettings.GetInt(gSettingsKey);
            Console.WriteLine($"Value is: {result}");
            Console.ReadKey();
        }
    }
}
