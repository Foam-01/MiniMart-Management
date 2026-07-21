using System;

namespace TestConsole.day5
{
    public class SearchInArray
    {

        public static void Run()
        {
            string[] arr =
{
    "Java",
    "Python",
    "C#",
    "JavaScript",
    "Ruby",
    "Go",
    "Swift",
    "Kotlin",
    "PHP-j",
    "TypeScript"
};

            //Contains() = มีตัวอักษรนี้อยู่ที่ไหนก็ได้
            //StartsWith() = ขึ้นต้นด้วย
            //EndsWith() = ลงท้ายด้วย
            //Find() = เอาตัวแรกที่เจอ
            //FindAll() = เอาทุกตัวที่เจอครับ

            // Contains J
            string containsJ = Array.Find(arr, e => e.Contains("J"))!;
            Console.WriteLine("Contains J = " + containsJ);

            // Contains j
            string containsj = Array.Find(arr, e => e.Contains("j"))!;
            Console.WriteLine("Contains j = " + containsj);

            Console.WriteLine();

            // StartsWith J
            string startsJ = Array.Find(arr, e => e.StartsWith("J"))!;
            Console.WriteLine("StartsWith J = " + startsJ);

            // StartsWith j
            string startsj = Array.Find(arr, e => e.StartsWith("j"))!;
            Console.WriteLine("StartsWith j = " + startsj);

            Console.WriteLine();

            // EndsWith J
            string endsJ = Array.Find(arr, e => e.EndsWith("J"))!;
            Console.WriteLine("EndsWith J = " + endsJ);

            // EndsWith j
            string endsj = Array.Find(arr, e => e.EndsWith("j"))!;
            Console.WriteLine("EndsWith j = " + endsj);

            Console.WriteLine();

            // FindAll Contains J
            string[] allContainsJ =
                Array.FindAll(arr, e => e.Contains("J"));

            Console.WriteLine("All Contains J");
            foreach (string item in allContainsJ)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // FindAll Contains j
            string[] allContainsj =
                Array.FindAll(arr, e => e.Contains("j"));

            Console.WriteLine("All Contains j");
            foreach (string item in allContainsj)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // FindAll StartsWith J
            string[] allStartsJ =
                Array.FindAll(arr, e => e.StartsWith("J"));

            Console.WriteLine("All StartsWith J");
            foreach (string item in allStartsJ)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // FindAll EndsWith j
            string[] allEndsj =
                Array.FindAll(arr, e => e.EndsWith("j"));

            Console.WriteLine("All EndsWith j");
            foreach (string item in allEndsj)
            {
                Console.WriteLine(item);
            }


        }
    }
}