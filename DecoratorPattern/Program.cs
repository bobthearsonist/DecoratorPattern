using DecoratorPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza supreme = new SupremePizza();
            var mushrooms = new Mushrooms();
            mushrooms.AddTopping(supreme);
            var olives = new Olives();
            olives.AddTopping(mushrooms);
            var pepperoni = new Pepperoni();
            pepperoni.AddTopping(olives);

            pepperoni.Cook();
        }
    }

    //it looks like this could be an interface, but at least in c#, Pizza topping
    public abstract class Pizza
    {
        public abstract void Cook();
    }

    public class SupremePizza : Pizza
    {
        public override void Cook()
        {
            Console.Out.WriteLine("cooking the pizza");
        }
    }

    public abstract class PizzaTopping : Pizza
    {
        private Pizza pizza;
        protected abstract string toppingName { get; }
        public void AddTopping(Pizza pizza) { this.pizza = pizza; }

        public override void Cook()
        {
            if(pizza==null)
            { throw new Exception("You cannot cook a topping by iteslf!"); }
            Console.Out.WriteLine("adding " + toppingName);
            pizza.Cook();
        }
    }

    internal class Olives : PizzaTopping
    {
        protected override string toppingName
        {
            get
            {
                return "Olives";
            }
        }
    }

    internal class Pepperoni:PizzaTopping
    {
        protected override string toppingName
        {
            get
            {
                return "Pepperoni";
            }
        }
    }

    internal class Mushrooms:PizzaTopping
    {
        protected override string toppingName
        {
            get
            {
                return "Mushrooms";
            }
        }
    }
}
