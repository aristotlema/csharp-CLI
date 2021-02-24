using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

/*Get Atomic Time from Internet Clock 
* This program will get the true atomic time from an atomic time clock on the Internet. 
* Use any one of the atomic clocks returned by a simple Google search.

Modified challenge to instead using http://worldtimeapi.org/
*/

namespace Get_Atomic_Time_from_Internet_Clock
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            bool active = true;

            Program program = new Program();

            Console.WriteLine("Welcome to Time Finder type '-H' or '-Help' for info");

            while(active)
            {
                Console.WriteLine("Enter your Time Zone: ");
                string userInput = Console.ReadLine();
                userInput = userInput.ToLower();

                //To Do needs to be refactored for false
                if (await program.CheckTimeZone(userInput))
                {
                    await program.GetTime(userInput);
                }
                else if(userInput == "-h" || userInput == "-help")
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine("");
                    Console.WriteLine("-h -help     lists all commands");
                    Console.WriteLine("-l -list     lists all time zones");
                    Console.WriteLine("-s -search   Search an country to find an area");
                    Console.WriteLine("-q -quit     exit the application");
                    Console.WriteLine("");
                    Console.WriteLine("=================================");
                }
                else if(userInput == "-list" || userInput == "-l")
                {
                    await program.ListAllTimeZones();
                }
                else if (userInput == "-s" || userInput == "-search")
                {
                    Console.WriteLine("Enter and area to search: ");
                    userInput = Console.ReadLine();
                    userInput = userInput.ToLower();
                    await program.SearchArea(userInput);
                }
                else if (userInput == "-q"|| userInput == "-quit")
                {
                    active = false;
                }
            }          
        }

        private async Task GetTime(string input)
        {
            string response = await client.GetStringAsync(
                $"http://worldtimeapi.org/api/timezone/{input}");

            Time time = JsonConvert.DeserializeObject<Time>(response);

            Console.WriteLine(time.datetime);
        }

        private async Task<bool> CheckTimeZone(string input)
        {
            string response = await client.GetStringAsync(
                "http://worldtimeapi.org/api/timezone");

            response = response.ToLower();

            List<string> timeZoneList = JsonConvert.DeserializeObject<List<string>>(response);

            if(timeZoneList.Contains(input))
                return true;
            else
                return false;
        }
        private async Task ListAllTimeZones()
        {
            string response = await client.GetStringAsync(
                "http://worldtimeapi.org/api/timezone");

            List<string> timeZoneList = JsonConvert.DeserializeObject<List<string>>(response);

            foreach (var item in timeZoneList)
            {
                Console.WriteLine(item);
            }
        }

        private async Task SearchArea(string input)
        {
            string response = await client.GetStringAsync(
                $"http://worldtimeapi.org/api/timezone/{input}");
            response = response.ToLower();

            List<string> areaList = JsonConvert.DeserializeObject<List<string>>(response);

            foreach(var item in areaList)
            {
                Console.WriteLine(item);
            }
        }
    }
    /*{"abbreviation":"EST",
     * "client_ip":"better luck next time",
     * "datetime":"2021-02-24T07:21:02.153361-05:00",
     * "day_of_week":3,"day_of_year":55,"dst":false,
     * "dst_from":null,"dst_offset":0,
     * "dst_until":null,
     * "raw_offset":-18000,
     * "timezone":"EST",
     * "unixtime":1614169262,
     * "utc_datetime":"2021-02-24T12:21:02.153361+00:00",
     * "utc_offset":"-05:00",
     * "week_number":8}*/
    class Time
    {
        public string datetime { get; set; }
        public string timezone { get; set; }
    }
}
