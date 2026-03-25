using System;

public class Class1
{
    class Movie
    {
        public string title;
        public int duration;

        public cont(string title, int duration)
        {
            this.title = title;
            this.duration = duration;
        }

    }

    class cinema
    {
        public string name;
        public List<Movie> movielist = new List<Movie>();

        public cont(string name)
        {
            this.name = name;
        }

        public void showMovies()
        {
            foreach (Movie mov in movielist)
            {
                Console.WriteLine($"{mov.title} , {mov.duration}");
            }
        }

        public void longMovie()
        {

            int max = 0;
            foreach (Movie mov in movielist)
            {
                if (mov.duration > max)
                {
                    max = mov.duration;
                }
            }

            foreach (Movie mov in movielist)
            {

                if (mov.duration == max)
                {
                    Console.WriteLine($"{mov.title} , {mov.duration} ")

                    }
            }
        }

        Class program
        {
                static void main()
        {
            Movie m1 = new Movie("Misson impossible" ,150);
           


            Movie m2 = new Movie("oblivion" , 105);
            


            cinema c1 = new cinema("prime max");

         
            c1.movielist.Add(m1);
            c1.movielist.Add(m2);

            c1.showMovies();
            c1.longMovie();
        }
    }
}
