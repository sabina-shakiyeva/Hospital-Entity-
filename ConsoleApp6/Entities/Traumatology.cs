namespace ConsoleApp6.Entities
{
    public class Traumatology:Department
    {
        //List<Doctor> doctorsT = new List<Doctor>();
        public Traumatology() { } 
        public Traumatology(string name) : base(name)
        {
        }

        //public override string ToString() =>
        //$"Name:{Name}\nSurname:{Surname}\nWorkExperience:{WorkExperience}";
    }
}
