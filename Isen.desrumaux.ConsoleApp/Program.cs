using System;
using System.Collections.Generic;
using Isen.desrumaux.Library;
using Newtonsoft.Json.Linq;

namespace Isen.desrumaux.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var Item1 = new Node<string>("Item1");
            var Item11 = new Node<string>("Item11");
            var Item111 = new Node<string>("Item111");
            var Item1111 = new Node<string>("Item1111");
            var Item112 = new Node<string>("Item112");
            var Item1121 = new Node<string>("Item1121");
            var Item1122 = new Node<string>("Item1122");
            var Item113 = new Node<string>("Item113");
            var Item12 = new Node<string>("Item12");
            var Item13 = new Node<string>("Item13");

            Item1.AddChildNode(Item11);
            Item1.AddChildNode(Item12);
            Item1.AddChildNode(Item13);

            Item11.AddChildNode(Item111);
            Item11.AddChildNode(Item112);
            Item11.AddChildNode(Item113);

            Item111.AddChildNode(Item1111);
            Item112.AddChildNode(Item1121);
            Item112.AddChildNode(Item1122);

            Console.WriteLine("Recherche d'élément : " + System.Environment.NewLine + Item11.FindTraversing(Item112));

            Item1.RemoveChildNode(Item11);

            Console.WriteLine(Item1);

            JObject json = Item1.SerializeJson();

            var deserialize = new Node<string>();

            deserialize.DeserializeJson(json);

            Console.WriteLine(deserialize);

            Item1.RemoveChildNode(Item11);

            Console.WriteLine(Item1);
        }
    }
}