using System;

namespace TestConsole.day8
{
    public class MyTryCatch
    {
        public MyTryCatch()
        {
            int x = 10;

            try
            {
                Console.WriteLine(x / 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: {0}", ex.Message);
            }
        }
    }
}