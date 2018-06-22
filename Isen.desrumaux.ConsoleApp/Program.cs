using System;
using Isen.desrumaux.Library;

namespace Isen.desrumaux.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bonjour = new Node("Bonjour");
            var hello = new Node("Hello");
            var hi = new Node("Hi");
            
            
            bonjour.AddChildNode(hello);
            bonjour.AddChildNode(hi);
            
            Console.WriteLine(bonjour);
            Console.WriteLine(bonjour.Depth);

            foreach (var bonjourChild in bonjour.children)
            {
                Console.WriteLine(bonjourChild);
                Console.WriteLine(bonjourChild.Depth);
            }
            
            bonjour.RemoveChildNode(hello);

            foreach (var bonjourChild in bonjour.children)
            {
                Console.WriteLine(bonjourChild);
                Console.WriteLine(bonjourChild.Depth);
            }
        }
    }
}
