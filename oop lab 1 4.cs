using System;

public class Class1
{
    class Dish
    {
        public string name;
        public int price;

        public cont(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

    }

    class resturant
    {
        public string name;
        public List<Dish> dishlist = new List<Dish>();

        pubic cont(string name)
        {
            this.name = name;
        }

        public void showDishes()
        {
            foreach (Dish d in dishlist)
            {
                Console.WriteLine($"{d.name} , {d.price}");
            }
        }

        public void MostExpensiveDish()
        {

            int max = 0;
            foreach (Dish d in dishlist)
            {
                if (d.price > max)
                {
                    max = d.price;
                }
            }

            foreach (Dish d in dishlist)
            {

                if (d.price == max)
                {
                    Console.WriteLine($"{d.name} , {d.price}")

                    }
            }
        }

        Class program
        {
                static void main()
        {
            Dish d1 = new Dish("Biryani" , 120);
           


            Dish d2 = new Dish("rajma chawal" , 200);
         


            resturant c1 = new resturant("hungerZone");

            c1.dishlist.Add(d1);
            c1.dishlist.Add(d2);

            c1.showDishes();
            c1.MostExpensiveDish();
        }
    }
}
