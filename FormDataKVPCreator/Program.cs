using FormDataKVPCreator.Models;
using System;
using System.Collections.Generic;

namespace FormDataKVPCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            checkBasicData();
            checkChildCollectionData();
            checkReferenceToAnotherObject();
            Console.ReadLine();

        }

        private static void checkReferenceToAnotherObject()
        {
            Console.WriteLine("Reference to another object");
            ReferenceToAnotherObject test = new ReferenceToAnotherObject();
            test.id = 1;
            test.name = "test";
            test.decimal_value = 5.3M;
            test.reference = test.Clone() as ReferenceToAnotherObject;

            var creator = new Creator<ReferenceToAnotherObject>();

            var kvps = new List<KeyValuePair<string, object>>();
            creator.addKVP(kvps, test);

            foreach (var kvp in kvps)
            {
                Console.WriteLine($"{kvp.Key}  - {kvp.Value}");
            }
        }

        private static void checkChildCollectionData()
        {
            Console.WriteLine("Child Collection Format");
            ChildCollection test = new ChildCollection();
            test.id = 1;
            test.name = "test";
            test.decimal_value = 5.3M;

            test.collections = new List<ChildCollection>()
            {
            test.Clone() as ChildCollection
            };

            var creator = new Creator<ChildCollection>();

            var kvps = new List<KeyValuePair<string, object>>();
            creator.addKVP(kvps, test);

            foreach (var kvp in kvps)
            {
                Console.WriteLine($"{kvp.Key}  - {kvp.Value}");
            }
        }

        private static void checkBasicData()
        {
            Console.WriteLine("Basic format.");
            Basic test = new Basic();
            test.id = 1;
            test.name = "test";
            test.decimal_value = 5.3M;
            test.int_values = new List<int>() { 1, 2, 3, 4, 5 };

            var creator = new Creator<Basic>();

            var kvps = new List<KeyValuePair<string, object>>();
            creator.addKVP(kvps, test);

            foreach (var kvp in kvps)
            {
                Console.WriteLine($"{kvp.Key}  - {kvp.Value}");
            }
        }
    }
}
