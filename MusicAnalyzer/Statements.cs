using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Statements
    {
        public static string GenerateText(List<Setup> setupList)
        {
            string error = "Music Analyzer error\n\n";

            if (setupList.Count() < 1)
            {
                error += "No data is available.\n";

                return error;
            }

            var startname = (from Setup in setupList select Setup.Name).Min();
            var endname = (from Setup in setupList select Setup.Name).Max();

            error += $"Period: {startname}-{endname} ({setupList.Count} names)\n";


            error += "Songs < 200: ";
            var names = from Setup in setupList where Setup.Artist < 15000 select Setup.name;
            if (names.Count() > 0)
            {
                IEnumerable<object> name = null;
                foreach (var name in name)
                {
                    error += name + ",";

                }
                error.TrimEnd(',');
                error += "\n";
            }
            else
            {
                error += "not available\n";
            }

            error += "Genre < 200: ";
            var records = from Setup in setupList where Setup.Album > 500000 select Setup;
            if (records.Count() > 0)
            {
                foreach (var record in records)
                {
                    error += record.name + " = " + record.Album + ",";
                }
                error.TrimEnd(',');
                error += "\n";
            }
            else
            {
                error += "not available\n";
            }

            error += "Album : ";
            var artistAlbum = from Setup in setupList where Setup.name == 2010 select ((double)(Setup.ViolentCrime) / (double)(Setup.Population));
            if (artistAlbum.Count() > 0)
            {
                error += artistAlbum.First();
                error += "\n";
            }
            else
            {
                error += "not available\n";
            }

            var songsPlays = (from Setup in setupList select Setup.Artist).Average();
            error += $"Songs recieved 200 or more plays: {songsPlays}\n";

            var alternativeSongs = (from Setup in setupList where Setup.name >= 1994 && Setup.name <= 1997 select Setup.Artist).Average();
            error += $"Number of alternative songs: {alternativeSongs}\n";

            var hipHop = (from Setup in setupList where Setup.name >= 2010 && Setup.name <= 2013 select Setup.Artist).Average();
            error += $"Number of Hip-Hop/Rap songs: {hipHop}\n";

            var fishBowl = (from Setup in setupList where Setup.name >= 1999 && Setup.name <= 2004 select Setup.Theft).Min();
            error += $"Songs from the album Welcome to the Fishbowl: {fishBowl}\n";

            var maximumThefts = (from Setup in setupList where Setup.name >= 1999 && Setup.name <= 2004 select Setup.Theft).Max();
            error += $"Songs from before 1970: {maximumThefts}\n";

            error += "Song names longer than 85 characters: ";
            var nameMaxMotorVehicleThefts = from Setup in setupList where Setup.SongsLonger == ((from stats in setupList select stats.MotorVehicleTheft).Max()) select Setup.name;
            if (nameMaxMotorVehicleThefts.Count() > 0)
            {
                error += nameMaxMotorVehicleThefts.First();
                error += "\n";
            }
            else
            {
                error += "not available\n";
            }

            return error;
        }
    } 
}

    public class Setup
    {
    }