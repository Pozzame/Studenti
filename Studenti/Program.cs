using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Studenti
{
    class Program
    {
        public IList<Student> School = new List <Student>();
        private int MAX_VOTE = 10;
        static void Main(string[] args)
        {
            IList<Student> School = new List<Student>();
            
            using (var reader = new StreamReader(@"C:\Users\Allievo 3\source\repos\Studenti\Studenti\Studenti.csv"))
            {
                string line;
                string[] values;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    values = line.Split(',');
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
                        Console.WriteLine("L = List all Students;\nF = Search for ID;\nV = Average value of students votes;\nM = Mode of students votes;\nD = Median of students votes;\nQ = Quit.");
                        break;
                    case 'l':
                    case 'L':
                        foreach (var student in School)
                        {
                            Console.WriteLine(student);
                        }
                        break;
                    case 'f':
                    case 'F':
                        Console.WriteLine("Insert ID: ");
                        int key = Convert.ToInt32(Console.ReadLine());
                        bool found = false;

                        foreach (var student in School)
                        {
                            if (student.ID == key)
                            {
                                Console.WriteLine(student);
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                            Console.WriteLine("Student not found...");
                        break;
                    case 'v':
                    case 'V':
                        double tot = 0;
                        foreach (var student in School)
                        {
                            tot += student.Vote;
                        }
                        double average = tot / School.Count;
                        Console.WriteLine("The average grade of all stuents is:" + average);
                        break;
                    case 'm':
                    case 'M':
                        IDictionary<int, int> map = new Dictionary<int, int>();
                        foreach (var student in School)
                        {
                            if (map.ContainsKey(student.Vote))
                            {
                                map[student.Vote]++;
                            }
                            else
                            {
                                map.Add(student.Vote, 1);
                            }
                        }
                        int moda = 0;
                        int maxFrequency = 0;
                        foreach (KeyValuePair<int, int> item in map)
                        {
                            if (item.Value > maxFrequency)
                            {
                                moda = item.Key;
                                maxFrequency = item.Value;
                            }
                        }
                        Console.WriteLine("The mode is: " + moda);
                        break;
                    case 'd':
                    case 'D':
                        int[] votes = new int[School.Count];     //creo un array di int chiamato votes lungo quanto la lista degli studenti
                        int i = 0;

                        foreach (var Student in School)
                        {
                            votes[i] = Student.Vote;           //Inserisce nell'array i voti
                            i++;
                        }
                        
                        Array.Sort(votes);

                        if (votes.Length % 2 != 0)                     //Se è dispari
                        {
                            Console.WriteLine("The mediane is: " + votes[votes.Length / 2]);          //La media è..  la posizione della media è alla metà
                        }
                        else
                        {
                            double mediane = (votes[votes.Length / 2] + votes[(votes.Length / 2) - 1]) / 2.0;    //(Se è pari) Fai la media dei due voti mediani
                            Console.WriteLine("The mediane is: " + mediane);
                        }
                        break;

                    default:
                        break; 
                }
                Console.WriteLine("Enter command: (? for Help)");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            Console.WriteLine("Bye bye...");
        }
    }
}