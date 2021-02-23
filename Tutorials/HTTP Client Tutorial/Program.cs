using System;
using System.Net.Http;
using System.Threading.Tasks;

/*
 * Tutorial part 1
 * https://www.youtube.com/watch?v=3d96CVSoSxM&list=LL&index=1
 * part 2
 * https://www.youtube.com/watch?v=xkB-cIMjXGQ
 
 using
 https://jsonplaceholder.typicode.com/
 */

namespace HTTP_Client_Tutorial
{
    class Program
    {
        HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetTodoItems();
        }

        private async Task GetTodoItems()
        {
            string response = await client.GetStringAsync(
                "https://jsonplaceholder.typicode.com/todos");
            Console.WriteLine(response);
        }
    }
}
