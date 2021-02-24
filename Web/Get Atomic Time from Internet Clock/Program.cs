using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

/*Get Atomic Time from Internet Clock 
* This program will get the true atomic time from an atomic time clock on the Internet. 
* Use any one of the atomic clocks returned by a simple Google search.

Using http://worldtimeapi.org/
*/

namespace Get_Atomic_Time_from_Internet_Clock
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetTime();
        }

        private async Task GetTime()
        {
            string response = await client.GetStringAsync(
                "http://worldtimeapi.org/api/timezone/est");

            Time time = JsonConvert.DeserializeObject<Time>(response);

            Console.WriteLine(time.datetime);
        }
    }
    /*{"abbreviation":"EST",
     * "client_ip":"73.160.86.10",
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
