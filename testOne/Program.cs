// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


namespace testNameSpace
{



    public class testClass
    {
        public int a = 11;
        public string b = "Hello, World!";

        public enum Color
        {
            red,
            black,
        };


        public testClass(int i, string j,  Color data)
        {
            // Console.WriteLine("Hello, World!");
            this.a = i;
            this.b = j;

            if(data == Color.red){
                // Console.WriteLine(" =  Color.red");
                this.a = 223;
            }

        }

        public void testMethod()
        {
            Console.WriteLine("testMethod a = " + a +" b =" + b);
        }
        public static void Main()
        {
            testClass tc = new testClass(12, "Hello, World!", Color.red);
            Console.WriteLine(tc.a);
            Console.WriteLine(tc.b);
        }
    }

}

//  dotnet new console 
//  dotnet run