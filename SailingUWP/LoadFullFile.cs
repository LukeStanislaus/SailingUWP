using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingUWP
{
    class LoadFullFile
    {
        public void newpersontofile(string person)
        {
            Console.WriteLine("Your name, " + person + ", is not in my records, would you like to add it?(y/n)");
            string response = Console.ReadLine();
            if (string.Equals(response, "y"))
            {
                Console.WriteLine("Please re-enter your name, capitalised how you want it.");
                string name = Console.ReadLine();
                Console.WriteLine("Please enter the number of boats you have.");
                int noOfBoats = int.Parse(Console.ReadLine());
                for (int i = 0; i < noOfBoats; i++)
                {
                    Console.WriteLine("Enter the name of boat {0}", i);
                    string boat = Console.ReadLine();
                    Console.Write("Enter the boat number of boat {0}", i);
                    int boatNumber = int.Parse(Console.ReadLine());
                    using (StreamWriter file =
new StreamWriter(@"c:\temp\Full List.txt", true))
                    {
                        file.WriteLine("{0}\t{1}\t{2}", name, boatNumber, boat);
                        //LoadFullSQL.AddPerson()

                    }


                }
            }
        }
        public void racerwritetofile(BoatsRacing racer, string path)
        {
            using (StreamWriter sw = System.IO.File.AppendText(@path + @"\Race List.txt"))
            {
                sw.WriteLine("{0}, {1}, {2}", racer.name,
                    racer.boatName,
                    racer.boatNumber);
            }
        }
        public static void ExportToFile(Dictionary<string, Boatsold> fulldictionary, string path)
        {
            using (StreamWriter sw = File.AppendText(@path + @"\FullDump.csv"))
            {
                foreach (var entry in fulldictionary)
                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", entry.Value.name, entry.Value.noOfBoats,
                        entry.Value.boat1, entry.Value.boatNumber1,
                        entry.Value.boat2, entry.Value.boatNumber2,
                         entry.Value.boat3, entry.Value.boatNumber3,
                         entry.Value.boat4, entry.Value.boatNumber4,
                         entry.Value.boat5, entry.Value.boatNumber5);
            }
        }

        public static Dictionary<string, Boatsold> loadFullFile(string path)
        //public static string LoadFullFile()
        {
            StreamReader reader = System.IO.File.OpenText(@path + @"Full List.txt");
            string line;
            Dictionary<int, Boats> BoatDictionaryInterim = new Dictionary<int, Boats>();
            Dictionary<string, Boatsold> BoatDictionary = new Dictionary<string, Boatsold>();

            int count1 = 0;
            while ((line = reader.ReadLine()) != null)

            {
                string[] items = line.Split(char.Parse("\n"));

                while ((line = reader.ReadLine()) != null)
                {

                    /*
                    string[] items1 = line.Split('\t');
                    Boats boat1 = new Boats(items1[0], int.Parse(items1[1]), items1[2]);
                    BoatDictionaryInterim.Add(count1, boat1);
                    */
                    count1++;
                }


            }
            List<string> keys = new List<string>();

            int m = 0;
            foreach (KeyValuePair<int, Boats> Boat in BoatDictionaryInterim)
            {
                if (keys.Contains(BoatDictionaryInterim[m].name))
                {
                    if (BoatDictionary[BoatDictionaryInterim[m].name].boat2 == null)
                    {
                        Boatsold boat1 = new Boatsold(BoatDictionaryInterim[m].name,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber1,
                        BoatDictionaryInterim[m].boatName,
                        BoatDictionaryInterim[m].boatNumber);
                        BoatDictionary.Remove(BoatDictionaryInterim[m].name);
                        BoatDictionary.Add(boat1.name, boat1);
                    }
                    else if (BoatDictionary[BoatDictionaryInterim[m].name].boat3 == null)
                    {

                        Boatsold boat1 = new Boatsold(BoatDictionaryInterim[m].name,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat2,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber2,
                        BoatDictionaryInterim[m].boatName,
                        BoatDictionaryInterim[m].boatNumber);
                        BoatDictionary.Remove(BoatDictionaryInterim[m].name);
                        BoatDictionary.Add(boat1.name, boat1);
                    }
                    else if (BoatDictionary[BoatDictionaryInterim[m].name].boat4 == null)
                    {
                        Boatsold boat1 = new Boatsold(BoatDictionaryInterim[m].name,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat2,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber2,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat3,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber3,
                        BoatDictionaryInterim[m].boatName,
                        BoatDictionaryInterim[m].boatNumber);
                        BoatDictionary.Remove(BoatDictionaryInterim[m].name);
                        BoatDictionary.Add(boat1.name, boat1);
                    }
                    else if (BoatDictionary[BoatDictionaryInterim[m].name].boat5 == null)
                    {
                        Boatsold boat1 = new Boatsold(BoatDictionaryInterim[m].name,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat2,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber2,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat3,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber3,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat4,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber4,
                        BoatDictionaryInterim[m].boatName,
                        BoatDictionaryInterim[m].boatNumber);
                        BoatDictionary.Remove(BoatDictionaryInterim[m].name);
                        BoatDictionary.Add(boat1.name, boat1);
                    }

                }
                else
                {
                    Boatsold boat3 = new Boatsold(BoatDictionaryInterim[m].name,
                    BoatDictionaryInterim[m].boatName,
                    BoatDictionaryInterim[m].boatNumber);
                    BoatDictionary.Add(boat3.name, boat3);
                    keys.Add(BoatDictionaryInterim[m].name);
                }
                m++;






            }
            reader.Close();
            return BoatDictionary;
        }
    }
}


