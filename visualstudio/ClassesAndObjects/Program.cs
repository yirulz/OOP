using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    class Color
    {
        public float r, g, b;
    }
    class Dog
    {
        public string name;
        public int size;
        public string breed;
        public ConsoleColor color;

        private string lastEatenFood;

        public void Eat(string food)
        {
            if(lastEatenFood != null)
            {
                lastEatenFood += " & ";
            }
            lastEatenFood += food;
            Console.ForegroundColor = color;
            Console.WriteLine(name + " is eating " + food);
        }
        public void Sleep()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + " is sleeping");
        }
        public void Shit()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + " is shitting");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Color red = new Color();
            red.r = 1;
            red.g = 0;
            red.b = 0;
            
            //Create instance of Dog
            Dog dog1 = new Dog();
            //Set properties of instance
            dog1.name = "Lassy";
            dog1.size = 2;
            dog1.breed = "Dalmation";
            dog1.color = ConsoleColor.Red;

            dog1.Eat("Meat");
            
            dog1.Shit();

            //Create instance of Dog
            Dog dog2 = new Dog();
            //Set properties of instance
            dog2.name = "Rod";
            dog2.size = 2;
            dog2.breed = "Mutt";
            dog2.color = ConsoleColor.Green;

            dog2.Eat(dog1.name);
            dog2.Shit();

           
            Console.ReadLine();

        }
    }
}
