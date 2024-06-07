


using System.Reflection;

namespace ReflectionSpace
{
    public class ReflectionClass
    {
        public void ReflectionMethod()
        {
            Console.WriteLine("ReflectionMethod");
        }


        public static void Main()
        {
            // 获取类型
            // Type type = typeof(ReflectionClass);
            Assembly assembly = Assembly.LoadFrom(@"D:\localhostWebPage\C#\testOne\bin\Debug\net8.0\testOne");
            Type[] types = assembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine("types ==" +types[i]);
            }
            // 加载 程序集 中的额一个 对象
            Type testClassType = assembly.GetType("testNameSpace.testClass");

            // h获取所有的成员
            MemberInfo[] members = testClassType.GetMembers();
            foreach (MemberInfo member in members)
            {
                Console.WriteLine("member == " + member);
            }
            // 通过 反射 实例化一个  对象
            // 先得到 枚举的 type  再得到 可以传入 的参数

            Type testClassEnumType = assembly.GetType("testNameSpace.testClass+Color");
            Console.WriteLine("testClassEnumType == " + testClassEnumType);
            // // 获取 枚举的 成员变量
            FieldInfo[] fields = testClassEnumType.GetFields();
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine("field == " + field);
            }

            FieldInfo red = testClassEnumType.GetField("red");

            // Console.WriteLine("red == " + red, "= red.GetValue(null) =", red.GetValue(null));
            // 获取 枚举的 成员变量
            // red.GetValue(null)  枚举 得到 具体的值
            object testClassObj = Activator.CreateInstance(testClassType, 1, "string", red.GetValue(null));
            // Console.WriteLine("这里 " );
            Console.WriteLine("testClassObj == " + testClassObj);
            // 得到 枚举的 成员变量
            // red.GetValue(null)  枚举 得到 具体的值
            // 得到 枚举的 成员变量
            // red.GetValue(null)  枚举 得到 具体的值
            // 得到 枚举的 成员变量
            // red.GetValue(null)  枚举 得到 具体的值

            // // 通过 反射  得到 对象的方法
            MethodInfo method = testClassType.GetMethod("testMethod");
            
            Thread.Sleep(1000);
            // // 执行方法
            method.Invoke(testClassObj, null);
    
            
            // 直接实例化
        }
    }
}