using System;
namespace TestConsole.day8
{
    public class NestedTryCatch
    {
        public NestedTryCatch()
        {
            try
            {
                try
                {
                    File.ReadAllText("data.txt");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: {0}", ex.Message);
                }
                try
                {
                    File.ReadAllText("dotnet.txt");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: {0}", ex.Message);
                }

                Console.WriteLine("-----end-----");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: {0}", ex.Message);
            }
        }
    }
}