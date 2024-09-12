using ConsoleApp6.Context;
using ConsoleApp6.Entities;
using System.Xml;

namespace ConsoleApp6
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HospitalDbContext context = new HospitalDbContext();

            Pediatry pediatry=new Pediatry("Pediatry");
            Stamology stamology=new Stamology("Stamology");
            Traumatology traumatology = new Traumatology("Traumatology");



            var doctorsP = new List<Doctor>() {
                new Doctor("Farida", "Shakiyeva", 5),
                new Doctor("Arzu", "Aliyeva", 7),
                new Doctor("Sevil", "Sevileva", 8)

            };
            var doctorsT = new List<Doctor>
            {
                new Doctor("Zefer", "Haciyev", 5),
                new Doctor("Hikmet", "Qurbanov", 3),
                new Doctor("Qedir", "Eliyev", 4)
            };
            var doctorsS = new List<Doctor>
            {
                new Doctor("Rovsen", "Rovsenov", 6),
                new Doctor("Adil", "Adilov", 7),
                new Doctor("Veli", "Veliyev", 7)
            };
            pediatry.Doctors= doctorsP;
            stamology.Doctors= doctorsS;
            traumatology.Doctors = doctorsT;
          
        
            List<User> users = new List<User>();

            context.Departments.AddRange(pediatry, stamology, traumatology);
            context.Doctors.AddRange(doctorsP.Concat(doctorsS).Concat(doctorsT));
            context.SaveChanges();




            while (true)
            {
                Console.WriteLine("Asagidakilarindan birini secin:");
                Console.WriteLine("1.Add User");
                Console.WriteLine("2.Add Reserve");
                short choice = 0;
                Console.Write("choice:");
                choice = short.Parse(Console.ReadLine());


                if (choice == 1)
                {
                    Console.Write("Enter name:");
                    string name = Console.ReadLine();
                    

                    Console.Write("Enter surname:");
                    string surname = Console.ReadLine();

                    Console.Write("Email:");
                    string email = Console.ReadLine();

                    Console.Write("Number:");
                    string number = Console.ReadLine();


                    User user = new User(name, surname, email, number);
                    users.Add(user);
                    context.Users.Add(user);

                }
                else if (choice == 2)
                {
                    if (users.Count == 0)
                    {
                        Console.WriteLine("Zehmet olmasa istifadeci elave edin!");
                        continue;
                    }
                    Console.WriteLine("Istifadeciler:");
                    for (int i = 0; i < users.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{users[i].Name}{users[i].Surname}");
                    }
                    Console.WriteLine("Istifadeci secin:");
                    int userIndex = int.Parse(Console.ReadLine()) - 1;
                    if (userIndex < 0 || userIndex >= users.Count)
                    {
                        throw new UserException("Istifadeci tapilmadi!");
                    }
                    var selectedU = users[userIndex];
                    Console.WriteLine("Asagida qeyd olunan sobelerden birini secin");
                    Console.Write("Secimi daxil edin(sozle)-->1)Pediatry 2)Stamology 3)Traumatology:");
                    Console.Write("choice:");
                    
                    string choiceDept= Console.ReadLine();
                    Department selectedDep = new Department(choiceDept);

                    if (choiceDept == "Pediatry")
                    {

                        pediatry.showDoctor();
                        Console.WriteLine("Hansi hekimi isteyirsiniz?(sirasini daxil edin reqemle)");
                        int index = int.Parse(Console.ReadLine()) - 1;
                        if (index >= 0 && index < pediatry.Doctors.Count)
                        {
                            var selectedDoct = selectedDep.Doctors.ElementAt(index);
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("Zehmet olmasa vaxt rezerv edin!");
                                    selectedDoct.showHours();
                                    int reservee = int.Parse(Console.ReadLine());

                                    if ((reservee == 1 && selectedDoct.Saat1 == false) || (reservee == 2 && selectedDoct.Saat2 == false) || (reservee == 3 && selectedDoct.Saat3 == false))
                                    {
                                        selectedDoct.Reserve(reservee);
                                        string timee = "";
                                        if (reservee == 1)
                                        {
                                            timee = "09:00-11:00";
                                        }
                                        else if (reservee == 2)
                                        {
                                            timee = "12:00-14:00";
                                        }
                                        else if (reservee == 3)
                                        {
                                            timee = "15:00-17:00";
                                        }
                                        Console.WriteLine($"Tesekkurler {selectedU.Name}{selectedU.Surname},siz saat {timee} de {selectedDoct.Name}{selectedDoct.Surname} hekimin qebuluna yazildiniz");

                                        //var reservvInfo = new
                                        //{
                                        //    User = selectedU,
                                        //    Doctor = selected,
                                        //    Time = timee

                                        //};
                                        //string json = JsonConvert.SerializeObject(reservvInfo, Formatting.Indented);
                                        //File.WriteAllText("reservation.json", json);

                                        break;
                                    }
                                }
                                catch (ReservationException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Xeta :{ex.Message}");
                                }
                            }

                        }

                    }


                    if (choiceDept == "Stamology")
                    {

                        stamology.showDoctor();
                        Console.WriteLine("Hansi hekimi isteyirsiniz?(sirasini daxil edin reqemle)");
                        int index = int.Parse(Console.ReadLine()) - 1;
                        if (index >= 0 && index < stamology.Doctors.Count)
                        {
                            var selectedDoct = selectedDep.Doctors.ElementAt(index);
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("Zehmet olmasa vaxt rezerv edin!");
                                    selectedDoct.showHours();
                                    int reservee = int.Parse(Console.ReadLine());

                                    if ((reservee == 1 && selectedDoct.Saat1 == false) || (reservee == 2 && selectedDoct.Saat2 == false) || (reservee == 3 && selectedDoct.Saat3 == false))
                                    {
                                        selectedDoct.Reserve(reservee);
                                        string timee = "";
                                        if (reservee == 1)
                                        {
                                            timee = "09:00-11:00";
                                        }
                                        else if (reservee == 2)
                                        {
                                            timee = "12:00-14:00";
                                        }
                                        else if (reservee == 3)
                                        {
                                            timee = "15:00-17:00";
                                        }
                                        Console.WriteLine($"Tesekkurler {selectedU.Name}{selectedU.Surname},siz saat {timee} de {selectedDoct.Name}{selectedDoct.Surname} hekimin qebuluna yazildiniz");

                                        //var reservvInfo = new
                                        //{
                                        //    User = selectedU,
                                        //    Doctor = selected,
                                        //    Time = timee

                                        //};
                                        //string json = JsonConvert.SerializeObject(reservvInfo, Formatting.Indented);
                                        //File.WriteAllText("reservation.json", json);

                                        break;
                                    }
                                }
                                catch (ReservationException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Xeta :{ex.Message}");
                                }
                            }

                        }

                    }

                    if (choiceDept == "Traumatology")
                    {

                        traumatology.showDoctor();
                        Console.WriteLine("Hansi hekimi isteyirsiniz?(sirasini daxil edin reqemle)");
                        int index = int.Parse(Console.ReadLine()) - 1;
                        if (index >= 0 && index < traumatology.Doctors.Count)
                        {
                            var selectedDoct = selectedDep.Doctors.ElementAt(index);
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("Zehmet olmasa vaxt rezerv edin!");
                                    selectedDoct.showHours();
                                    int reservee = int.Parse(Console.ReadLine());

                                    if ((reservee == 1 && selectedDoct.Saat1 == false) || (reservee == 2 && selectedDoct.Saat2 == false) || (reservee == 3 && selectedDoct.Saat3 == false))
                                    {
                                        selectedDoct.Reserve(reservee);
                                        string timee = "";
                                        if (reservee == 1)
                                        {
                                            timee = "09:00-11:00";
                                        }
                                        else if (reservee == 2)
                                        {
                                            timee = "12:00-14:00";
                                        }
                                        else if (reservee == 3)
                                        {
                                            timee = "15:00-17:00";
                                        }
                                        Console.WriteLine($"Tesekkurler {selectedU.Name}{selectedU.Surname},siz saat {timee} de {selectedDoct.Name}{selectedDoct.Surname} hekimin qebuluna yazildiniz");

                                        //var reservvInfo = new
                                        //{
                                        //    User = selectedU,
                                        //    Doctor = selected,
                                        //    Time = timee

                                        //};
                                        //string json = JsonConvert.SerializeObject(reservvInfo, Formatting.Indented);
                                        //File.WriteAllText("reservation.json", json);

                                        break;
                                    }
                                }
                                catch (ReservationException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Xeta :{ex.Message}");
                                }
                            }

                        }

                    }



                }
            }


        }
    }
}
