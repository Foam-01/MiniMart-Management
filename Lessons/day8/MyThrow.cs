using System;
namespace TestConsole.day8
{
    public class MyThrow
    {
        public MyThrow()
        {
            try
            {
             for (int i = 0; i < 100; i++)
                {
                    if (i == 50)
                    {
                        throw new Exception("i is 50");
                    }

                    Console.WriteLine(i);
                }   
            } catch (Exception ex)
            {
                Console.WriteLine("error: {0}", ex.Message);
            }
        }
    }
}