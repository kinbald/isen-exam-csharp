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
            var ciao = new Node("Ciao");


            bonjour.AddChildNode(hello);
            bonjour.AddChildNode(hi);

            hi.AddChildNode(ciao);

            Console.WriteLine(bonjour);
            Console.WriteLine(bonjour.Depth);

            foreach (var bonjourChild in bonjour.children)
            {
                Console.WriteLine(bonjourChild);
                Console.WriteLine(bonjourChild.Depth);
            }

            Console.WriteLine($"Noeud trouvé : {bonjour.FindTraversing(ciao)}");

            bonjour.RemoveChildNode(hello);

            foreach (var bonjourChild in bonjour.children)
            {
                Console.WriteLine(bonjourChild);
                Console.WriteLine(bonjourChild.Depth);
            }
        }
    }
}