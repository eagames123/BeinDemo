using DiziFilm.Core.Aspects.Postsharp.ValidationAspects;

namespace DiziFilm.Project.Console
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            var myObject = new MyClass();
            myObject.MyMethod();

            System.Console.ReadLine();
        }

    }

    public class MyClass
    {
        [MyAspect]
        public void MyMethod()
        {
            System.Console.WriteLine("Hello world!");
        }
    }

}
