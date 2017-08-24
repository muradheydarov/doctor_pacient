using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor_pacient
{
    class Program
    {
        static void Main(string[] args)
        {
            Pacient tor = new Pacient();
        }
    }
    class Pacient
    {
        public Pacient()
        {
            Console.WriteLine("Adinizi daxil edin: ");
            string pacientName = Console.ReadLine();
            Console.WriteLine("Zehmet olmasa sobelerden birini secin: ");
            Console.WriteLine();
            for (int i = 0; i < Sections.sections.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i, Sections.sections[i]);
            }
            Console.WriteLine();
            int decision = Convert.ToInt32(Console.ReadLine());
            Doctors.ShowDoctors(decision);
        }
    }
    static class Sections
    {
        static public string[] sections = { "Ginekologiya", "Urologiya", "Travmatologiya" };
    }
    static class Doctors
    {
        static string[,] ListDoctors = { { "Gulten doxtur", "Gunel doxtur" }, { "Qasim doxtur", "Alqasim doxtur" }, { "Qulu doxtur", "Beydulla doxtur" } };
        static string[,,] workingHours = { { { "08:00-10:00", "12:00-14:00", "16:00-18:00" }, { "10:00-12:00", "12:00-14:00", "14:00-16:00" } }, { { "08:00-10:00", "12:00-14:00", "16:00-18:00" }, { "10:00-12:00", "12:00-14:00", "14:00-16:00" } }, { { "08:00-10:00", "12:00-14:00", "16:00-18:00" }, { "10:00-12:00", "12:00-14:00", "14:00-16:00" } } };
        static string[,,] BusyOrNot = { { { "Bos", "Bos", "Dolu" }, { "Dolu", "Bos", "Dolu" } }, { { "Bos", "Bos", "Bos" }, { "Dolu", "Bos", "Bos" } }, { { "Bos", "Dolu", "Dolu" }, { "Bos", "Bos", "Dolu" } } };

        public static void ShowDoctors(int decision)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("{0}. {1}", i, ListDoctors[decision, i]);
            }

            Console.WriteLine("Zehmet olmasa muracite etmek istediyiniz hekimi secin: ");
            int ChosenDoctor = Convert.ToInt32(Console.ReadLine());

            Label:
            Console.WriteLine("Zehmet olmasa qebul ucun bir vaxt secin: ");
            for (int k = 0; k < 3; k++)
            {
                Console.WriteLine("{0}. {1}", k, workingHours[decision, ChosenDoctor, k]+" "+ BusyOrNot[decision, ChosenDoctor, k]);
            }
            int chosenHour = Convert.ToInt32(Console.ReadLine());

            if (BusyOrNot[decision, ChosenDoctor, chosenHour] == "Dolu")
            {
                Console.WriteLine("Secdiyiniz saatlarda artiq qeyde alinib. Zehmet olmasa basqa bir vaxt secin...");
                goto Label;
            }
            else
            {
                Console.WriteLine("Tesekkurler secdiyiniz vaxt qeyde alindi...");
                BusyOrNot[decision, ChosenDoctor, chosenHour] = "Dolu";
                goto Label;
            }
        }
    }
}
