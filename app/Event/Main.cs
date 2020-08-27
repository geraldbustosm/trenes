using System;
using System.Threading.Tasks;

namespace Event
{
    public class Main
    {

        public static void DoWork()
        {
            Task.Run(async () => {
            for(; ; )
                {
                    await Task.Delay(10000);
                    Console.WriteLine("Hi after 10 seconds");
                }
            });
        }
    }
}
