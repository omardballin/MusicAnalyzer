using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                if (args.Length != 2)
                {
                    Console.WriteLine("MusicAnalyzer <SampleMusicPlaylist> <error_file_path>");
                    Environment.Exit(1);
                }

                string csvDataFilePath = args[0];
                string errorFilePath = args[1];

                List<Setup> setupList = null;
                try
                {
                    setupList = Configure.Load(csvDataFilePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(2);
                }

                var report = Statements.GenerateText(setupList);

                try
                {
                    System.IO.File.WriteAllText(setupFilePath, report);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(3);
                }
            }
        }
    }
}
