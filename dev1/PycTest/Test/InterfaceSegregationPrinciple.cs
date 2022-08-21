using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycTest.Test
{
    public interface Flyable
    {
        void fly();
    }
    public interface Runnable
    {
        void run();
    }
    public interface Barkable
    {
        void bark();
    }
    public class Bird : Flyable, Runnable
    {
        public void run()
        {
            Console.WriteLine("Kuş,Koşuyorum");
            //logic 
        }
        public void fly()
        {
            Console.WriteLine("Kuş, Uçuyorum.");
            //logic 
        }
    }
    public class Cat : Runnable
    {
        public void run()
        {
            Console.WriteLine("Kedi,Koşuyorum");
            //logic 
        }
    }
    public class Dog : Runnable, Barkable
    {
        public void bark()
        {
            Console.WriteLine("Köpek,Havlıyorum.");
            //logic 
        }
        public void run()
        {
            Console.WriteLine("Köpek,Koşuyorum.");
            //logic 
        }
    }

    public class InterfaceSegregationPrinciple
    {
    }
}
