using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Studenti
{
    class Program
    {
        static public IList<Student> School = new List <Student>();
        private static int MAX_VOTE = 10;
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"C:\Users\Pozzame\Source\Repos\Studenti\Studenti\Studenti.csv"))
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
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            while (input !='q' && input != 'Q')
            {
                switch (input)
                {
                    case '?':
                        Console.WriteLine("L = List all Students;\nF = Search for ID;\nV = Average value of students votes;\nM = Mode of students votes;\nD = Median f students votes;\nQ = Quit.");
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
                        Console.WriteLine("Insert ID: ");
                        int key = Convert.ToInt32(Console.ReadLine());
                        bool found = false;

                        foreach (var Student in School)
                        {
                            if (Student.ID == key)
                            {
                                Console.WriteLine(Student.ToString());
                                found = true;
                            }
                        }
                        if (found != true)
                        {
                            Console.WriteLine("Student not found...");
                        }
                        break;
                    case 'v':
                    case 'V':
                        int tot=0;
                        foreach (var Student in School)
                        {
                            tot += Student.Vote;
                        }
                        float average = (float) tot / School.Count;
                        Console.WriteLine("The average grade of all stuents is:" + average);
                        break;
                    case 'm':
                    case 'M':
                        foreach (var Student in School)
                        {
                            IDictionary<int, int> map = new Dictionary<int, int>();
                            foreach (var student in School)
                            {
                                if (map.ContainsKey(student.Vote))
                                {
                                    map[student.Vote]++;
                                }else
                                {
                                    map.Add(student.Vote, 1);
                                }
                                //try
                                //{
                                //    map[student.Vote]++;
                                //}
                                //catch (KeyNotFoundException)
                                //{
                                //    map.Add(student.Vote, 1);
                                //}
                            }
                            bubbleSort(ref map);

                            for (int i = map.Count; i > 0; i--)
                            {
                                while (map[i]>map[i-1])
                                {
                                    Console.WriteLine("Moda is: " + i + "trovata" + map[i] + "volte.");
                                }
                            }
                            //for (int i = 0; i < map.Count; i++)
                            //{
                            //    Console.WriteLine(i + map[i]);
                            //}
                            //{
                            //    Console.WriteLine(map.ToString());
                            //}
                        }
                        break;
                    default:
                        { break; }
                }
            Console.WriteLine("Enter command: (? for Help)");
            input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            }

            void bubbleSort(ref IDictionary<int,int> map)
            {
                int i, j;
                for (i = 0; i < map.Count - 1; i++)

                    // Last i elements are already in place    
                    for (j = 0; j < MAX_VOTE; j++)
                        if (map.ContainsKey(j) && map.ContainsKey(j + 1) && map[j] > map[j + 1])
                        {
                            int temp = map[j];
                            map[j] = map[i];
                            map[i] = temp;
                        }
                            if (map.ContainsKey(j + 1))
                            {
                                if (map[j] > map[j + 1])
                                {

                                }
                            }
                        }
                        if (map[j] > map[j + 1])
                        {
                            int temp = map[j];
                            map[j] = map[i];
                            map[i] = temp;
                        }
            }
            //void swap(ref int xp, ref int yp)
            //{
            //    int temp = xp;
            //    xp = yp;
            //    yp = temp;
            //}
            //Student Pippo = new Student(1, "Pippo", "Pasticcio", 23, 'M', 5);
            //Console.WriteLine(Pippo.ToString());
        }
    }
}
