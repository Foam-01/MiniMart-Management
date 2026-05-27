namespace TestConsole.day2
{
    public class Oper4
    {
        public Oper4()
        {
            bool a = true, b = false;

            Console.WriteLine(a == b); // a เท่ากับ b 
            Console.WriteLine(a != b); // a ไม่เท่ากับ b
            Console.WriteLine(!a);  // สลับ a จาก true ไป false
            Console.WriteLine(!b); //  สลับ b จาก false ไป true

            int x = 5, y = 10;

            Console.WriteLine(x > y); // x มากกว่า y
            Console.WriteLine(x >= y); // x มากกว่า หรือ เท่ากับ y
            Console.WriteLine(x < y); // x น้อยกว่า y
            Console.WriteLine(x <= y); // x น้อยกว่า หรือ เท่ากับ y

        }
    }
}