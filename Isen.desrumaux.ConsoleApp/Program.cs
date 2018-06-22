using System;
using System.Collections.Generic;
using Isen.desrumaux.Library;

namespace Isen.desrumaux.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var Item1 = new Node("Item1");
            var Item11 = new Node("Item11");
            var Item111 = new Node("Item111");
            var Item1111 = new Node("Item1111");
            var Item112 = new Node("Item112");
            var Item1121 = new Node("Item1121");
            var Item1122 = new Node("Item1122");
            var Item113 = new Node("Item113");
            var Item12 = new Node("Item12");
            var Item13 = new Node("Item13");
            
            Item1.AddChildNode(Item11);
            Item1.AddChildNode(Item12);
            Item1.AddChildNode(Item13);
            
            Item11.AddChildNode(Item111);
            Item11.AddChildNode(Item112);
            Item11.AddChildNode(Item113);
            
            Item111.AddChildNode(Item1111);
            Item112.AddChildNode(Item1121);
            Item112.AddChildNode(Item1122);

            Console.WriteLine(Item1);
        }
    }
}