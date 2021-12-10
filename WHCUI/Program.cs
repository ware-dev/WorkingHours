using System;
using System.Globalization;
using System.IO;
using WHLib;

namespace WHCUI
{
    class Program
    {
        static void Main(string[] args)
        {

            const int DAY_OF_WORK = 5;
            string name = String.Empty;
            Time startTime = null;
            Time endTime = null;
            Time dayTime = null;
            Time weekTime = null;

            Console.WriteLine("Welcome in the Working Hours program ! (type 'quit' to exit)\n");

            while (true)
            {
                Console.Write("Entrez le nom du travailleur : ");
                name = Console.ReadLine();
                if (name.ToLower() == "quit") break;

                try
                {
                    startTime = ReadTime("début");
                    endTime = ReadTime("fin");

                    dayTime = endTime - startTime;
                    weekTime = dayTime * DAY_OF_WORK;

                    Console.WriteLine($"\n{name} travaille {dayTime.ToString()} par jour ({ ((float)dayTime).ToString("0.00") }).");
                    Console.WriteLine($"{name} travaille {weekTime.ToString()} par semaine ({ ((float)weekTime).ToString("0.00") }).\n");

                    WriteInFile(name, dayTime, weekTime);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
        private static void WriteInFile(string name, Time dayTime, Time weekTime)
        {
            using (StreamWriter sw = File.AppendText("..\\Data\\WorkingHours.txt"))
            {
                sw.WriteLine(name);
                sw.WriteLine("Day Hours : " + dayTime.ToString());
                sw.WriteLine("Week Hours : " + weekTime.ToString() + "\n");
            }
        }

        private static Time ReadTime(string typeHeure)
        {
            Console.Write($"Quelle est l'heure de {typeHeure} de travail : (hh:mm) : ");
            string hm = Console.ReadLine();

            if (hm.Length != 5) throw new FormatException("Le format spécifé n'est pas correct.");

            string[] values = hm.Split(':');
            if (values.Length != 2) throw new FormatException("Le format spécifié n'est pas correct.");

            return new Time(int.Parse(values[0]), int.Parse(values[1]));
        }
    }
}
