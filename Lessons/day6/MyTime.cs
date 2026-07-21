using System;

namespace TestConsole.day6
{
    public class MyTime
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // d1: วันที่ 1 เดือน 6 ปี 2024
            DateTime d1 = new DateTime(2024, 6, 1, 12, 30, 0);

            // d2: ปรับแก้จาก 15 เป็น 6 (เดือน) และจาก 1 เป็น 15 (วัน) ให้ถูกต้อง
            DateTime d2 = new DateTime(2024, 6, 15, 12, 15, 20);

            // คำนวณส่วนต่างของเวลา
            TimeSpan d3 = d2 - d1;

           
            Console.WriteLine($"เปรียบเทียบ d1 กับ d2 (CompareTo): {d1.CompareTo(d2)}");
            Console.WriteLine($"จำนวนวันต่างกัน (Total Days): {d3.Days} วัน"); // 💡 แนะนำเพิ่มตัวนี้เข้าไปจะเห็นผลชัดเจนขึ้นครับ
            Console.WriteLine($"ชั่วโมงที่ต่างกันเฉพาะเศษ (Hours): {d3.Hours}");
            Console.WriteLine($"นาทีที่ต่างกันเฉพาะเศษ (Minutes): {d3.Minutes}");
            Console.WriteLine($"วินาทีที่ต่างกันเฉพาะเศษ (Seconds): {d3.Seconds}");
        }
    }
}