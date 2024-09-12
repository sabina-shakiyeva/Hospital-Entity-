namespace ConsoleApp6.Entities
{
    public class Department
    {
        public Department(string name)
        {
            Name = name;
        }
        public Department() { } 
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

        //public List<Doctor> Doctors { get; set; }

        public void showDoctor()
        {
            for (int i = 0; i < Doctors.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{Doctors.ElementAt(i)}");
            }
        }
    }
}
