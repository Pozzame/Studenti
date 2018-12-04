using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Studenti
{
    class Program
    {
        static public IList<Student> School = new List <Student>();

        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"C:\Users\Allievo 3\source\repos\Studenti\Studenti\Studenti.csv"))
            {
                //List<string> listA = new List<string>();
                //List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    School.Add(new Student(Convert.ToInt32(values[0]), values[1], values[2], Convert.ToInt32(values[3]), Convert.ToChar(values[4]), Convert.ToInt32(values[5])));
                }
            }

            Console.WriteLine("Enter command: (? for Help)");
            var input = Console.Read();
            switch (input)
            {
                case '?':
                    Console.WriteLine("L = List all Students;\nF = Search for ID;\nV = Valore medio voti degli studenti;\nM = Moda dei voti degli studenti;\nD = Mediana dei voti degli studenti;");
                    break;
                case 'l':
                case 'L':
                    foreach (var Student in School)
                    {
                        Console.WriteLine(Student.ToString());
                    }
                    break;
                case 'f':
                case 'F':
                    Console.WriteLine("Insert ID:");
                    var key = (Console.Read());

                    foreach (var Student in School)
                    {
                        if (Student.ID == key)
                        {
                            Console.WriteLine(Student.ToString());
                            break;
                        }
                    }
                    Console.WriteLine("Student not found...");
                    break;
                default:
                    { break; }



                    //Student Pippo = new Student(1, "Pippo", "Pasticcio", 23, 'M', 5);
                    //Console.WriteLine(Pippo.ToString());
            }
        } 
   }
}
