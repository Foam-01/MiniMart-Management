using System;
using System.IO;

namespace TestConsole.day6
{
    public class MyReadFile
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 👑 วิธีที่ 1: ดึงตำแหน่งโฟลเดอร์ที่ .NET Build ไฟล์ (bin/Debug/net10.0/) มาใช้ตรงๆ
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "TestConsole.deps.json";

            // ใช้ Path.Combine เพื่อเชื่อม Path เข้าด้วยกันอย่างปลอดภัยตามมาตรฐาน OS
            string fullPath = Path.Combine(baseDir, fileName);

            Console.WriteLine("--- เริ่มต้นอ่านไฟล์ระดับระบบ ---");
            Console.WriteLine($"กำลังมองหาไฟล์ที่พิกัด: {fullPath}\n");

            // ใช้ try-catch ครอบเพื่อป้องกันแอปพลิเคชันระเบิด (สไตล์โปรดักชัน)
            try
            {
                if (File.Exists(fullPath))
                {
                    string dataInFile = File.ReadAllText(fullPath);
                    Console.WriteLine("✅ อ่านข้อมูลสำเร็จ:\n");
                    Console.WriteLine(dataInFile);
                }
                else
                {
                    Console.WriteLine("❌ ไม่พบไฟล์ในโฟลเดอร์ตัวพิมพ์เขียวรันระบบ");
                    Console.WriteLine("💡 ทริก: ลองคัดลอกไฟล์ TestConsole.deps.json ไปวางในโฟลเดอร์ bin/Debug/net10.0/ ดูครับ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"เกิดข้อผิดพลาดในการอ่านไฟล์: {ex.Message}");
            }
        }
    }
}