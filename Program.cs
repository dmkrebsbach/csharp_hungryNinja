using System;
using System.Collections.Generic;

namespace hungryNinja
{

    public class Food
    {
        public string Name {get;set;}
        public int Calories {get;set;}=100;
        public bool IsSpicy{get;set;}=false; // Foods can be Spicy and/or Sweet
        public bool IsSweet{get;set;}=false; // Foods can be Spicy and/or Sweet

        public string GetInfo()
        {
            return $"Your { Name } has { Calories } calories. Is it sweet? { IsSweet }. Is it spicy? { IsSpicy }.";
        }
        
        // add a Food constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
        public Food(string name, int calories, bool spicy, bool sweet) 
        {
            Name = name;
            Calories = calories;
            IsSpicy = spicy;
            IsSweet = sweet;        
        }
    }

    class Buffet
    {
        public List<Food> Menu;
        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Pizza", 285, false, false),
                new Food("Cupcake", 131, false, true),
                new Food("Cheeseburger", 303, false, false),
                new Food("Hot Wings", 420, true, false),
                new Food("Brownie", 132, false, true),
                new Food("Fries", 365, false, false),
                new Food("Sushi", 300, true, false),
                new Food("Ice Cream",125, false, true),

            };
        }
        public Food Serve()
        {
            Random randFood = new Random();
            int randInt = randFood.Next(Menu.Count);
            return Menu[randInt];
        }
    }

    class Ninja
    {
        public Ninja() // add a constructor
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }    
        private int calorieIntake;
        public List<Food> FoodHistory;

        public bool IsFull {get;set;} // add a public "getter" property called "IsFull"
        public void Eat(Food item) // build out the Eat method
        {
               
            if (calorieIntake <= 1200)
            {
                calorieIntake += item.Calories;
                FoodHistory.Add(item);
                item.GetInfo();
                IsFull = false;
            }
            else
            {
                Console.WriteLine("The Ninja full and can't eat another bite!");
                IsFull = true;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var damian = new Ninja();
            var newBuffet = new Buffet();
            while (!damian.IsFull)
            {
                damian.Eat(newBuffet.Serve());
            }
            Console.WriteLine(damian);
            Console.Write("The Ninja ate the following: ");
            foreach (var food in damian.FoodHistory)
            {
                Console.Write($"{food.Name}: {food.Calories} cal; ");
            }
            Console.WriteLine();
        }
    }
}
