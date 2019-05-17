using System;
using System.Collections.Generic;


namespace Patterns.Factory
{
    public interface IHotDrink
    {
        void  Consume();
    }
    public interface IHotDrinkfactory
    {
        IHotDrink Prepare (int amount);
    }
    internal class Tea:IHotDrink
    {
        public void Consume()
        {
            System.Console.WriteLine("Ahh, tea...");
        }
    }
    internal class Coffe:IHotDrink
    {
        public void Consume()
        {
            System.Console.WriteLine("Coffe - strong and black.");
        }
    }
    internal class TeaFactory: IHotDrinkfactory
    {
        public IHotDrink Prepare(int amount)
        {
            System.Console.WriteLine($"Put a tea bag, boil water, pour {amount} ml. Enjoy!");
            return new Tea();
        }
    }
    internal class CoffeFactory: IHotDrinkfactory
    {
        public IHotDrink Prepare(int amount)
        {
            System.Console.WriteLine($"Grind some beans, boil water, pour{amount} ml,add cream and sugar for you taste. Enjoy !");
            return new Coffe();
        }
    }


}