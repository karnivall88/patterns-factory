using System;
using System.Collections.Generic;


namespace Patterns.Factory
{
    public class HotDrinkMachine
    {
        // public enum Drinks
        // {
        //     Coffe,
        //     Tea
        // }

        // private Dictionary<Drinks,IHotDrinkfactory> factories = new Dictionary<Drinks, IHotDrinkfactory>();

        // public HotDrinkMachine()
        // {
        //     foreach (Drinks drink in Enum.GetValues(typeof(Drinks)))
        //     {
        //         var factory = (IHotDrinkfactory)Activator.CreateInstance(Type.GetType("Patterns.Factory." + Enum.GetName(typeof(Drinks),drink)+"Factory"));
        //         factories.Add(drink,factory);
        //     }
        // }
        // public IHotDrink MakedRink (Drinks drink, int amount)
        // {
        //     return factories[drink].Prepare(amount);
        // }
        private List<Tuple<string,IHotDrinkfactory>> factories = new List<Tuple<string, IHotDrinkfactory>>();
        public HotDrinkMachine ()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if(typeof(IHotDrinkfactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(t.Name.Replace("Factory",string.Empty),(IHotDrinkfactory)Activator.CreateInstance(t)));
                }
            }
        }
        public IHotDrink MakedRink ()
        {
            System.Console.WriteLine("Available drinks: ");
            for (int i = 0; i < factories.Count; i++)
            {
                var tuple = factories[i];
                System.Console.WriteLine($"{i}: {tuple.Item1}");
            }
            while(true)
            {
                System.Console.Write("Choose your drink:");
                string s;
                if((s = System.Console.ReadLine()) != null && int.TryParse(s,out int i) && i>=0 && i< factories.Count)
                {
                    System.Console.Write("Specify the amount:");
                    s = System.Console.ReadLine();

                    if(s!= null && int.TryParse(s, out int amount) && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }
                System.Console.WriteLine("Incorrect input, try again...");
            }
        }
    }
}