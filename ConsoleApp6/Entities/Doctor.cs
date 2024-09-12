namespace ConsoleApp6.Entities
{
    public class Doctor
    {
        public Doctor(string name, string surname, int workExperience)
        {
            Name = name;
            Surname = surname;
            WorkExperience = workExperience;
            Saat1 = false;
            Saat2 = false;
            Saat3 = false;
            


        }
        public Doctor() { }
        public override string ToString() =>
       $"Name:{Name}\nSurname:{Surname}\nWorkExperience:{WorkExperience}";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int WorkExperience { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public bool Saat1 { get; set; }
        public bool Saat2 { get; set; }
        public bool Saat3 { get; set; }
        //Dictionary<string, string> WorkHours { get; set; }

        public void Reserve(int reservee)
        {
            if (reservee == 1)
            {
                {
                    if (Saat1 == false)
                    {
                        Saat1 = true;
                        Console.WriteLine("Saat 09:00-11:00 ucun rezerv edildi");
                    }
                    else
                    {
                        throw new ReservationException("Hemin saat artiq rezerv olunub");
                    }
                }

            }
            else if (reservee == 2)
            {
                if (Saat2 == false)
                {
                    Saat2 = true;
                    Console.WriteLine("Saat 12:00-14:00 ucun rezerv edildi");
                }
                else
                {
                    throw new ReservationException("Hemin saat artiq rezerv olunub");
                }


            }
            else if (reservee == 3)
            {
                if (Saat3 == false)
                {
                    Saat3 = true;
                    Console.WriteLine("Saat 15:00-17:00 ucun rezerv edildi");

                }
                else
                {
                    throw new ReservationException("Hemin saat artiq rezerv olunub");
                }
            }

        }
        public void showHours()
        {
            Console.WriteLine($"1)09:00-11:00 - {(Saat1 ? "Reverv olunub" : "Rezerv olunmayib")}");
            Console.WriteLine($"2) 12:00-14:00 - {(Saat2 ? "Reverv olunub" : "Rezerv olunmayib")}");
            Console.WriteLine($"3) 15:00-17:00 - {(Saat3 ? "Rezerv olunub" : "Rezerv olunmayib")}");
        }

    }
}
