using System;
namespace TestConsole.day2
{
    public class Oper2
    {
        public Oper2()
        {
            int x = 10;

            x++; //x = x + 1
            Console.WriteLine(x); // = 11

            x--; //x = x - 1
            Console.WriteLine(x); // = 10

            x = 10;
            Console.WriteLine(x++); //แสดงค่า x ก่อนแล้วค่อยเพิ่ม = 10 มีผลบรรทัดถัดไป
            
            x = 10;
            Console.WriteLine(x--); //แสดงค่า x ก่อนแล้วค่อยลด = 10 มีผลบรรทัดถัดไป

            x = 10;
            Console.WriteLine(++x); //เพิ่มค่า x ก่อนแล้วค่อยแสดง = 11 มีผลบรรนี้เลย

            x = 10;
            Console.WriteLine(--x); //ลดค่า x ก่อนแล้วค่อยแสดง = 9  มีผลบรรนี้เลย
        }
    }
}