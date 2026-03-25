using System;

public class Class1
{
    class teacher
    {
        public string name;
        public int yearsOfexp;
       
        public cont(string name, int yearsOfexp)
        {
            this.name = name;
            this.yearsOfexp = yearsOfexp;
        }
    }

    class school
    {
        public string name;
        public List<teacher> teacherList = new List<teacher>();

        public cont(string name)
        {
            this.name=name;
        }

        public void showTeacher()
        {
            foreach (teacher tec in teacherList)
            {
                Console.WriteLine($"{tec.name} , {tec.yearsOfexp}");
            }
        }

        public void mostExp()
        {

            int exp = 0;
            foreach (teacher tech in teacherList)
            {
                if (tech.yearsOfexp > exp)
                {
                    exp = tech.yearsOfexp;
                }
            }

            foreach (teacher tech in teacherList)
            {

                    if (tech.yearsOfexp == exp)
                    {
                        Console.WriteLine($"{tech.name} , {tech.yearsOfexp} ")

                    }
                }
        }

            Class program{
                static void main()
                {
                    teacher tec1 = new teacher("Farooq" , 19);
                    


            teacher tec2 = new teacher("Moeez" , 19);
           


            school sch1 = new school("the gramer school");

            
            sch1.teacherList.Add(tec1);
            sch1.teacherList.Add(tec2);

            sch1.showTeacher();
            sch1.mostExp();
                }
            }
        }
