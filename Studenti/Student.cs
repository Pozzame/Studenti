namespace Studenti
{
    public class Student
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }
        public char Gender  { get; private set; }
        public int Vote { get; private set; }

        public Student(int ID, string Name, string Surname, int Age, char Gender, int Vote)
        {
            this.ID = ID;
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Gender = Gender;
            this.Vote = Vote;
        }

        public override string ToString()
        {
            return ID + " " + Name + " " + Surname + " " + Age + " " + Gender + " " + Vote;
        }
    }
}