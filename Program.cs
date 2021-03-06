﻿using System;
using Patterns.Factory;

namespace Patterns_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            // var point = Point.Factory.NewPolarPoint(3.56,2.78);
            // Console.WriteLine(point);

            // var machine = new HotDrinkMachine();
            // var drink = machine.MakedRink();
            // drink.Consume();
            var factory = new PersonFactory();
            factory.CreatePerson("Bob");
            factory.CreatePerson("Bob");

            foreach ( Person p in factory.Persons)
            {
                System.Console.WriteLine(p);
            }
        }
    }
}
