using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObfuscationSpeedTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = 10000;

            // Without obfuscation
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            { 
                var result = Sha256.SHA256("test");
            }

            sw.Stop();
            var time = sw.Elapsed;

            Console.WriteLine($"Without obfuscation: {time.TotalMilliseconds / iterations} ms");

            // Obfuscate names
            sw = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                var result = Sha256_ObfuscateNames.SHA256("test");
            }

            sw.Stop();
            var timeObfuscateNames = sw.Elapsed;

            Console.WriteLine($"Names obfuscation: {timeObfuscateNames.TotalMilliseconds / iterations} ms (+{(int)(100 * (timeObfuscateNames.TotalMilliseconds - time.TotalMilliseconds) / time.TotalMilliseconds)}%)");

            // Control flow obfuscation
            sw = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                var result = Sha256_ObfuscateControlFlow.SHA256("test");
            }

            sw.Stop();
            var timeControlFlowObfuscation = sw.Elapsed;

            Console.WriteLine($"Control flow obfuscation: {timeControlFlowObfuscation.TotalMilliseconds / iterations} ms (+{(int)(100 * (timeControlFlowObfuscation.TotalMilliseconds - time.TotalMilliseconds) / time.TotalMilliseconds)}%)");

            // Virtualization
            sw = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                var result = Sha256_Virtualization.SHA256("test");
            }

            sw.Stop();
            var timeVirtualization = sw.Elapsed;

            Console.WriteLine($"Virtualization: {timeVirtualization.TotalMilliseconds / iterations} ms (+{(int)(100 * (timeVirtualization.TotalMilliseconds - time.TotalMilliseconds) / time.TotalMilliseconds)}%)");
        }
    }
}
