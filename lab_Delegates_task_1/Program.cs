using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_Delegates_task_1
{




    /* Func<Action<string,int>, int,int>  */
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Func < Action<string, int>, int, int> lambda = (f, x) =>
            {
                return (x == 4) ? (2 * x) : (x * x);
            };
            Action<string, int> TT = MyFunc;
            Console.WriteLine(lambda(TT, 4));
            Console.ReadKey();

        }
        static void MyFunc(string f, int x)
        {
            Console.WriteLine(f + x + " b c d e f");
            Console.ReadLine();
        }


    }
}
