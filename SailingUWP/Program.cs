using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using Microsoft;
using System.Windows.Input;
using System.Linq;
using System.Data;
using ExcelDataReader;
using System.Data.OleDb;
//using Sailing2;

namespace SailingUWP
{
 
    class Program1
    {
        //public List<Boats> boatlist = new List<Boats>();
        //public Boats personboat = new Boats();
        //public static void Main1()
        public static void hello(string name)
        {

            //Boats boat1 = new Boats("Adrian Stanislaus", 2, "Laser Stratos", 927, "Laser", 182782);
            //Boats boat2 = new Boats("Luke Stanislaus", 1, "Laser Stratos", 182782, null, 0);
            //Boats boat3 = new Boats("Simon Clark", 2, "Phantom", 1080, "Laser", 1234);
            //List<Boats> boat = new Dictionary<string, Boats>();
            List<BoatsRacing> raceList = new List<BoatsRacing>();
            List<Boatsold> boatlist = new List<Boatsold>();
            Boatsold personboat = new Boatsold();
            //Console.WriteLine("Enter path to folder of files");
            string[] path1 = System.Reflection.Assembly.GetEntryAssembly().Location.Split(char.Parse(@"\"));
            string path = "";
            int b = 0;
            while (path1[b] != "SailingUWP")
            {
                path = string.Concat(path + path1[b] + @"\");
                b++;
            }
            //string path2 = path.Split(path)
            /*
            Console.WriteLine("Enter name");
            string name1 = Console.ReadLine();
            LoadFullSQL db = new LoadFullSQL();
            boatlist = db.GetBoats();
            Console.WriteLine(db.GetBoat(name1).boat1);
            */
            //boatDictionary = LoadFullSQL.getdictionary(boatlist);
            /*
            Console.WriteLine("Enter name");
            string name2 = Console.ReadLine();
            Console.WriteLine("Enter boatname");
            string boatname2 = Console.ReadLine();
            Console.WriteLine("Enter boatnumber");
            int boatnumber2 = int.Parse(Console.ReadLine());
            if (LoadFullSQL.AddBoat(name2, boatname2, boatnumber2) == true)
                Console.WriteLine("Success");
            else
                Console.WriteLine("Fail");
                */
            //boatDictionary = LoadFullFile.loadFullFile(path);
            //Console.WriteLine(boatDictionary["Adrian Stanislaus"].boat1);
            //string hi = LoadFullFile();
            //Console.WriteLine(boatDictionary["Abc"].name);
            //boatDictionary.Add(boat1.name, boat1);
            //boatDictionary.Add(boat2.name, boat2);
            //boatDictionary.Add(boat3.name, boat3);
            //LoadFullFile.ExportToFile(boatDictionary, path);
            /*
            while (0==1)
            {
                Console.WriteLine("Who is it?");
                string person = name;
                try
                {
                    LoadFullSQL db1 = new LoadFullSQL();
                    //Boats personboat = db1.GetBoat(person);
                    personboat = db1.GetBoat(person);
                    while (person == personboat.name)
                    {

                        if (personboat.noOfBoats > 0)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, Y/N?", personboat.boat1);
                            string response = Console.ReadLine();
                            if (response == "Y" || response == "y")
                            {

                                //BoatsRacing.converter1(personboat);
                                LoadFullSQL.SQLaddnewracer(personboat, BoatsRacing.converter1(personboat));
                                Console.ReadLine();

                                break;

                            }
                            else if (personboat.noOfBoats == 1)
                            {
                                LoadFullSQL.AddBoat(personboat);
                            }
                        }
                        if (personboat.noOfBoats > 1)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, Y/N?", personboat.boat2);
                            string response = Console.ReadLine();
                            if (response == "Y" || response == "y")
                            {

                                LoadFullSQL.SQLaddnewracer(personboat, BoatsRacing.converter1(personboat));
                                Console.ReadLine();
                                break;

                            }
                            else if (personboat.noOfBoats == 2)
                            {
                                LoadFullSQL.AddBoat(personboat);
                            }
                        }
                        if (personboat.noOfBoats > 2)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, Y/N?", personboat.boat3);
                            string response = Console.ReadLine();
                            if (response == "Y" || response == "y")
                            {

                                LoadFullSQL.SQLaddnewracer(personboat, BoatsRacing.converter1(personboat));
                                Console.ReadLine();
                                break;

                            }
                            else if (personboat.noOfBoats == 3)
                            {
                                LoadFullSQL.AddBoat(personboat);
                            }
                        }
                        if (personboat.noOfBoats > 3)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, Y/N?", personboat.boat4);
                            string response = Console.ReadLine();
                            if (response == "Y" || response == "y")
                            {

                                LoadFullSQL.SQLaddnewracer(personboat, BoatsRacing.converter1(personboat));
                                Console.ReadLine();
                                break;

                            }
                            else if (personboat.noOfBoats == 4)
                            {
                                LoadFullSQL.AddBoat(personboat);
                            }
                        }
                        if (personboat.noOfBoats > 4)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, Y/N?", personboat.boat5);
                            string response = Console.ReadLine();
                            if (response == "Y" || response == "y")
                            {

                                LoadFullSQL.SQLaddnewracer(personboat, BoatsRacing.converter1(personboat));
                                Console.ReadLine();
                                break;

                            }
                            else if (personboat.noOfBoats == 5)
                            {
                                LoadFullSQL.AddBoat(personboat);
                            }
                        }
                        Console.Clear();
                        personboat = db1.GetBoat(person);
                    }
                }

                catch (KeyNotFoundException)
                {


                }
                //Dictionary<string, Boats> nothing = new Dictionary<string, Boats>();
                //boatDictionary = LoadFullFile.loadFullFile(path);
                //string hi2 = LoadFullFile();
                Console.Clear();
                Console.WriteLine("Escape, Y/N?");
                if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
                    break;

            }
            foreach (var item in raceList)
            {
                Console.WriteLine("Name = {0}, BoatName = {1}, BoatNumber = {2}", item.name, item.boatName, item.boatNumber);
            }
            Console.ReadLine();
            /*
            Console.WriteLine("Would you like to remove a boat?");
            if (Console.ReadLine() == "y" || Console.ReadLine() == "Y") 
            {
                LoadFullSQL.SQLremoveboat()
            }
            */

        }
    }
}

