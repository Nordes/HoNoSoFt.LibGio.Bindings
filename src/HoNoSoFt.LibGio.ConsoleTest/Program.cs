using System;

namespace HoNoSoFt.LibGio.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Schema to look: ");
            var gsettingsSchema = Console.ReadLine();
            Console.Write("Key to look: ");
            var gsettingsKey = Console.ReadLine();

            var gsettings = HoNoSoFt.LibGio.Bindings.GSettings.New(gsettingsSchema);
            var result = HoNoSoFt.LibGio.Bindings.GSettings.GetInt(gsettings, gsettingsKey);
            Console.WriteLine($"Value is: {result}");
            Console.ReadKey();
        }
    }
}
