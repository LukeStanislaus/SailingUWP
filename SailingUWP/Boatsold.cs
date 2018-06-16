using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingUWP
{
    public class Boatsold
    {
        public string name { get; set; }
        public int noOfBoats { get; set; }
        public string boat1 { get; set; }
        public int boatNumber1 { get; set; }
        public string boat2 { get; set; }
        public int boatNumber2 { get; set; }
        public string boat3 { get; set; }
        public int boatNumber3 { get; set; }
        public string boat4 { get; set; }
        public int boatNumber4 { get; set; }
        public string boat5 { get; set; }
        public int boatNumber5 { get; set; }

        public Boatsold()
        {
            name = "";
            noOfBoats = -1;
            boat1 = "";
            boatNumber1 = 0;
            boat2 = "";
            boatNumber2 = 0;
            boat3 = "";
            boatNumber3 = 0;
            boat4 = "";
            boatNumber4 = 0;
            boat5 = "";
            boatNumber5 = 0;
        }

            public Boatsold(string Name, string Boat1, int BoatNumber1)
        {
            name = Name;
            noOfBoats = 1;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;


        }
        public Boatsold(string Name, string Boat1, int BoatNumber1, string Boat2,
        int BoatNumber2)
        {
            name = Name;
            noOfBoats = 2;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;
            boat2 = Boat2;
            boatNumber2 = BoatNumber2;



        }
        public Boatsold(string Name, string Boat1, int BoatNumber1, string Boat2,
        int BoatNumber2, string Boat3, int BoatNumber3)
        {
            name = Name;
            noOfBoats = 3;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;
            boat2 = Boat2;
            boatNumber2 = BoatNumber2;
            boat3 = Boat3;
            boatNumber3 = BoatNumber3;


        }
        public Boatsold(string Name, string Boat1, int BoatNumber1, string Boat2,
        int BoatNumber2, string Boat3, int BoatNumber3, string Boat4, int BoatNumber4)
        {
            name = Name;
            noOfBoats = 4;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;
            boat2 = Boat2;
            boatNumber2 = BoatNumber2;
            boat3 = Boat3;
            boatNumber3 = BoatNumber3;
            boat4 = Boat4;
            boatNumber4 = BoatNumber4;


        }
        public Boatsold(string Name, string Boat1, int BoatNumber1, string Boat2,
        int BoatNumber2, string Boat3, int BoatNumber3, string Boat4, int BoatNumber4,
        string Boat5, int BoatNumber5)
        {
            name = Name;
            noOfBoats = 5;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;
            boat2 = Boat2;
            boatNumber2 = BoatNumber2;
            boat3 = Boat3;
            boatNumber3 = BoatNumber3;
            boat4 = Boat4;
            boatNumber4 = BoatNumber4;
            boat5 = Boat5;
            boatNumber5 = BoatNumber5;

        }
        public Boatsold(System.String Name, System.Int32 NoOfBoats, System.String Boat1, System.Int32 BoatNumber1,
System.String Boat2, System.Int32 BoatNumber2, System.String Boat3, System.Int32 BoatNumber3,
System.String Boat4, System.Int32 BoatNumber4, System.String Boat5, System.Int32 BoatNumber5)
        {
            name = Name;
            noOfBoats = NoOfBoats;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;
            boat2 = Boat2;
            boatNumber2 = BoatNumber2;
            boat3 = Boat3;
            boatNumber3 = BoatNumber3;
            boat4 = Boat4;
            boatNumber4 = BoatNumber4;
            boat5 = Boat5;
            boatNumber5 = BoatNumber5;
        }

        public static void Addboats(string response, string path, string person,
            Dictionary<string, Boatsold> boatDictionary)
        {
            Console.Clear();
            Console.WriteLine("Would you like to add a boat? y/n");
            response = Console.ReadLine();
            if (response == "y")
            {
                Console.WriteLine("Enter the name of the boat");
                string boat = Console.ReadLine();
                Console.Write("Enter the boat number of the boat ");
                int boatNumber = int.Parse(Console.ReadLine());
                using (StreamWriter file =
new StreamWriter(@path + @"\Full List.txt", true))
                {
                    file.Write("\n{0}\t{1}\t{2}", person, boatNumber, boat);

                }
                Console.Clear();
            }
        }



    }
}
