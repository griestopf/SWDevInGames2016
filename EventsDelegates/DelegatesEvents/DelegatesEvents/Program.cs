using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegatesEvents
{
    public delegate void ReportProgressFunc(int i);
    public class MyClass
    {
        public int CalcSomething(int a, int b, ReportProgressFunc ReportProgress)
        {
            for (int i = 0; i < 10000; i++)
            {
                Thread.Sleep(1);
                if (i%100 == 0 && ReportProgress != null)
                    ReportProgress(i);
            }
            return 2*(b - a);
        }
    }

    public class UserNotifier
    {
        public string str;
        public void NotifyUser(int i)
        {
            Console.Write(str);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();

            UserNotifier un = new UserNotifier {str = "$"};

            int result = mc.CalcSomething(2, 3, un.NotifyUser);

            Console.WriteLine(result);
            Console.ReadKey();
        }


    }
}
