using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerCommunication sC = new ServerCommunication();
            sC.AcceptClientCallBack();
            Console.ReadLine();
        }
    }
}
