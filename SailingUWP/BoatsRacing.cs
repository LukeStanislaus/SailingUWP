using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingUWP
{
    public class BoatsRacing
    {
        public string name { get; set; }
        public string boatName { get; set; }
        public int boatNumber { get; set; }
        public BoatsRacing()
        {

        }
        public BoatsRacing(string Name, string Boat, int BoatNumber)
        {
            name = Name;
            boatName = Boat;
            boatNumber = BoatNumber;


        }
        public static BoatsRacing converter1(Boatsold boat)
        {
            BoatsRacing racer1 = new BoatsRacing(boat.name, boat.boat1, boat.boatNumber1);
            return racer1;
        }
        public static BoatsRacing converter2(Boatsold boat)
        {
            BoatsRacing racer1 = new BoatsRacing(boat.name, boat.boat2, boat.boatNumber2);
            return racer1;
        }
        public static BoatsRacing converter3(Boatsold boat)
        {
            BoatsRacing racer1 = new BoatsRacing(boat.name, boat.boat3, boat.boatNumber3);
            return racer1;
        }
        public static BoatsRacing converter4(Boatsold boat)
        {
            BoatsRacing racer1 = new BoatsRacing(boat.name, boat.boat4, boat.boatNumber4);
            return racer1;
        }
        public static BoatsRacing converter5(Boatsold boat)
        {
            BoatsRacing racer1 = new BoatsRacing(boat.name, boat.boat5, boat.boatNumber5);
            return racer1;
        }
        public static Dictionary<string, BoatsRacing> loadRaceFile(Dictionary<string, BoatsRacing> raceDictionary, string path)
        {
            StreamReader reader = System.IO.File.OpenText(@path + @"\Race List.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(char.Parse(", "));
                Console.WriteLine("{0}, {1}, {2}", items[0], items[1], items[2]);
                BoatsRacing boat1 = new BoatsRacing(items[0], items[1], int.Parse(items[2]));


                raceDictionary.Add(items[0], boat1);


            }
            reader.Close();
            return raceDictionary;
        }
    }
}

