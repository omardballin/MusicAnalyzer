using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAnalyser
{
    class Configure
    {
        private static int NumItemsInRow = 8;

        public static List<Setup> Load(string csvDataFilePath)
        {
            List<Setup> crimeStatsList = new List<Setup>();

            try
            {
                using (var reader = new StreamReader(csvDataFilePath))
                {
                    int lineNumber = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        lineNumber++;
                        if (lineNumber == 1) continue;

                        var values = line.Split(',');

                        if (values.Length != NumItemsInRow)
                        {
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}.");
                        }
                        try
                        {
                            String name = string(values[0]);
                            String artist= string(values[1]);
                            String album = string(values[2]);
                            String genre = string(values[3]);
                            int size = Int32.Parse(values[4]);
                            int time = Int32.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);

                            Setup setup = new Setup(name, artist, album, genre, size, time, year, plays);
                            object setupList = null;
                            setupList.Add(setup);
                        }
                        catch (FormatException e)
                        {
                            throw new Exception($"Row {lineNumber} contains invalid data. ({e.Message})");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to open {csvDataFilePath} ({e.Message}).");
            }

            return crimeStatsList;
        }
    }

    internal class Setup
    {
    }
}
