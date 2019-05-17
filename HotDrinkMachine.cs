using System;
using System.Collections.Generic;


namespace Patterns.Factory
{
    public class HotDrinkMachine
    {
        public enum Drinks
        {
            Coffe,
            Tea
        }

        private Dictionary<Drinks,IHotDrinkfactory> factories = new Dictionary<Drinks, IHotDrinkfactory>();

        public HotDrinkMachine()
        {
            foreach (Drinks drink in Enum.GetValues(typeof(Drinks)))
            {
                var factory = (IHotDrinkfactory)Activator.CreateInstance(Type.GetType("Patterns.Factory." + Enum.GetName(typeof(Drinks),drink)+"Factory"));
                factories.Add(drink,factory);
            }
        }
        public IHotDrink MakedRink (Drinks drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
        
    }
}