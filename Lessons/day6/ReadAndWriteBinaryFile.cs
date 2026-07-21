using System;

namespace TestConsole.day6
{
    public class ReadAndWriteBinaryFile
    {

        public static void Run()
        {
            FileStream fs1 = new FileStream("data.kob", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs1);
            bw.Write(10);
            bw.Write(99.99);
            bw.Write(true);
            bw.Write("Hello World");
            bw.Close();

            FileStream fs2 = new FileStream("data.kob", FileMode.Open);
            BinaryReader br = new BinaryReader(fs2);
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadDouble());
            Console.WriteLine(br.ReadBoolean());
            Console.WriteLine(br.ReadString());
            br.Close();

        }
    }
}
