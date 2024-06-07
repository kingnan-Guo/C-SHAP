#define Fun
using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;// 条件编译 使用


// using System.Runtime.InteropServices;// DllImport 使用； 用来 标记非 .Net 程序集; 一般用来 调用 C 或 C++ 的 DLL 包
// 写法
// [DllImport("Test.dll")]
// public static extern int MessageBox(int a, int b);

namespace ReflectionSpace2
{



    #region 
    // 为 特性类 添加使用范围
    // 参数 1 AttributeTargets --- 特性用在哪些地方; 类 ： System.AttributeTargets.Class ； 成员 ： System.AttributeTargets.Field
    // 参数 2 Inherited --- 子类是否继承特性
    // 参数 3 AllowMultiple --- 特性是否可以重复使用； 特性是否被派生类和重写 成员继承
    #endregion

    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    class myCustomAttribute : Attribute
    {
        public string info;
        public myCustomAttribute(string info)
        {
            this.info = info;
        }

        public void TestFun()
        {
            Console.WriteLine("myCustomAttribute this.info = "+ this.info);
        }
    }
    
    [myCustomAttribute("这是一个自定义特性1")]
    [myCustom("这是一个自定义特性")]
    public  class MyClass
    {

        [Conditional("Fun")]
        public static  void Fun(){
            Console.WriteLine("Conditional 条件特性 Fun");
        }



        [myCustom("这是一个成员变量")]
        public int value;


        // 参数 1  调用 过时 方法 时  提示，
        // 参数 2 是否 抛出 异常； 默认 false
        [Obsolete("这是一个过时的方法, 请使用 TestFun 方法", false)]
        public void oldTestFun()
        {
            Console.WriteLine("observed 过时 的 特性");
        }
        public void TestFun(int a){
            Console.WriteLine("TestFun");
        }


        // 系统 会自动  补全 后面的值
        public void SpeakCaller(string str, [CallerFilePath]string fileName = "", [CallerLineNumber]int lineNumber = 0, [CallerMemberName]string memberName = ""){
            Console.WriteLine("str == "+ str);
            Console.WriteLine("fileName == "+ fileName);
            Console.WriteLine("lineNumber == "+ lineNumber);
            Console.WriteLine("memberName == "+ memberName);
        }



        public static void Main(string[] args)
        {

            Console.WriteLine("特性使用");

            #region 特性使用
            MyClass myClass = new MyClass();
            // Console.WriteLine("myClass");
            // 获取 成员变量的 特性

            // 这三个 是相等的
            Type type =  myClass.GetType();
            // type = typeof(MyClass);
            // type =  type.GetType("反射特性.MyClass");


            // 判断 是否使用了 某个 特性;
            // 参数 一 ： 特性类
            // 参数 二 ： 是否 查找 父类； 是否 搜索 继承链（属性 和 事件忽略此参数 ）
            if(type.IsDefined(typeof(myCustomAttribute), false)){
                Console.WriteLine("使用了自定义特性");
            }

            // 获取 元数据 中的所有 特性
            // 参数 继承链
            object[] array= type.GetCustomAttributes(true);
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] is myCustomAttribute){

                    // Console.WriteLine("array == "+ array[i]);
                    myCustomAttribute data = (array[i] as myCustomAttribute);
                    Console.WriteLine("info == "+ data.info);
                    data.TestFun();
                }
            }


            // 使用过时方法
            myClass.oldTestFun();

            myClass.SpeakCaller("string");


            Fun();

            #endregion
        }
    }
}