using Codere.SGBOnlineGames.CasinoFeed.ServiceSlotsGamesCodere;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codere.SBGOnlineGames.CasinoFeed.AppConsole
{
    class Program
    {
        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            Console.WriteLine("Press any key ...");
            Console.ReadLine();

            var service = new ServiceSlotsGamesCodere();
            var jackpots = await service.GetJackpots();

            Console.WriteLine("End request");
            Console.ReadLine();
        }
    }
}
