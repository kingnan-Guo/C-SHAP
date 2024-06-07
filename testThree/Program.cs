// See https://aka.ms/new-console-template for more information

using System;
// using System.Reflection;

// Console.WriteLine("反射特性");
namespace ReflectionSpace
{

    #region 
    // 特性的本质 是个 类
    // 可以用 特性类 为 元数据 添加额外信息
    // 之后可以 通过反射来获取到这些额外的信息
    #endregion


    #region 
    // 反射特性
    // 基本语法： [特性名(参数列表)]
    // 本质上 就是在调用 特性类 的构造函数
    //类 函数 变量 上一行， 表示他们具有 该提醒信息
    #endregion

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
    
    // [myCustomAttribute("这是一个自定义特性")]
    [myCustom("这是一个自定义特性")]
    public  class MyClass
    {
        [myCustom("这是一个成员变量")]
        public int value;


        [myCustom("这是一个用于 计算的函数")]
        public void TestFun([myCustom("函数参数")]int a){

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

            // 获取 成员变量的 特性



            // var attrs = typeof(MyClass).GetMethod("TestFun").GetCustomAttributes(true);
            // foreach (var item in attrs)
            // {
            //     myCustomAttribute attr = item as myCustomAttribute;
            //     Console.WriteLine(attr.info);
            // }

            #endregion
        }
    }
}