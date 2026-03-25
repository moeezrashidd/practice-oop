using System;

public class Class1
{
    class magzines
    {
        public string title;
        public int issueNum;
        public string month;

        pubic cont(string title, int issueNum,  string month)
        {
            this.title = title;
            this.issueNum = issueNum;

            this.month = month;
        }

    }

    class library
    {
        public string libraryName;
        public List<magzines> mag = new List<magzines>();
        public cont(string libraryName)
        {
            this.libraryName = libraryName; 
        }

        int num = 0;
        
        foreach (magzines magz in mag) {
            if (magz.issueNum > num){
                num = magz.issueNum;
            }




        public void showMagzine()
        {
            foreach (magzines magz in mag) {
                Console.WriteLine($"{magz.title} , {magz.issueNum} , {magz.month}");

            }
        }
        public void showLatestmag()
        {


            foreach (magzines magz in mag) {

                if (magz.issueNum == num) {
                    Console.WriteLine($"{magz.title} , {magz.month} ,{magz.issueNum}")

                }

            }

        }
    }
      Class program{
                static void main()
                {
                    magzines mag1 = new magzines("way to hell" , 10, "january");
                   

                    magzines mag2 = new magzines("back to hell" , 12 , "march");
                    


                    library lab1 = new library("book shop");

                    lab1.mag.Add(mag1);
                    lab1.mag.Add(mag2);

                    lab1.showLatestmag();
                    lab1.showMagzine();
                }
            }
}
