using NickStrupat;
using System.Timers;
namespace RamIn
{
    internal class Program
    {
        private static System.Timers.Timer timer;
        private static string filePath = "C:\\Users\\Eliya\\OneDrive\\Masaüstü\\ram_usage.txt";
        static void Main(string[] args)
        {

            timer = new System.Timers.Timer(20000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            Console.WriteLine("Press [Enter] to exit the program.");
            Console.ReadLine();

        }



        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            ComputerInfo CI = new ComputerInfo();
            ulong mem = ulong.Parse(CI.TotalPhysicalMemory.ToString());
            var total = (mem / (1024 * 1024) + " MB").ToString();

            ulong available1 = ulong.Parse(CI.AvailablePhysicalMemory.ToString());
            var available = (available1 / (1024 * 1024) + " MB").ToString();

            var use = mem - available1;
            var used = (use / (1024 * 1024) + " MB").ToString();

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Timestamp: {DateTime.Now}");
                writer.WriteLine($"Total Memory: {total}");
                writer.WriteLine($"Available Memory: {available}");
                writer.WriteLine($"Used Memory: {used}");
                writer.WriteLine(new string('-', 50));
            }

            Console.WriteLine($"Timestamp: {DateTime.Now}, Total Memory: {total},Available Memory: {available}, Used Memory: {used}");
        }
    }

}


