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
            var mushrooms = new Mushrooms(supreme);
            var olives = new Olives(mushrooms);
            var pepperoni = new Pepperoni(olives);

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
        public PizzaTopping(Pizza pizza) { this.pizza = pizza; }

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
        public Olives(Pizza pizza) : base(pizza)
        {
        }

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
        public Pepperoni(Pizza pizza) : base(pizza)
        {
        }

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
        public Mushrooms(Pizza pizza) : base(pizza)
        {
        }

        protected override string toppingName
        {
            get
            {
                return "Mushrooms";
            }
        }
    }
}
