using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data;

namespace SailingUWP
{
    public class LoadFullSQL
    {
        public static void displayboats(Boatsold personboat)
        {
            Console.WriteLine("Your first boat, a(n) {0}, has boat number {1}", personboat.boat1, personboat.boatNumber1);
            Console.WriteLine("Your second boat, a(n) {0}, has boat number {1}", personboat.boat2, personboat.boatNumber2);
            Console.WriteLine("Your third boat, a(n) {0}, has boat number {1}", personboat.boat3, personboat.boatNumber3);
            Console.WriteLine("Your fourth boat, a(n) {0}, has boat number {1}", personboat.boat4, personboat.boatNumber4);
            Console.WriteLine("Your fifth boat, a(n) {0}, has boat number {1}", personboat.boat5, personboat.boatNumber5);
        }

        public static void SQLremoveboat(Boatsold boats, BoatsRacing boat)
        {
            /*
            if (boats.name == boat.name)
            {
                boats.noOfBoats = boats.noOfBoats - 1;
                LoadFullSQL.SQLremove(false, boats.name);
                if (boats.boat1 == boat.boatName)
                {
                    if (boats.noOfBoats == 1)
                    {
                        boats.boat1 = "";
                        boats.boatNumber1 = 0;
                    }
                    else if (boats.noOfBoats == 2)
                    {
                        boats.boat1 = boats.boat2;
                        boats.boat2 = "";
                        boats.boatNumber1 = boats.boatNumber2;
                        boats.boatNumber2 = 0;
                    }
                    else if (boats.noOfBoats == 3)
                    {
                        boats.boat1 = boats.boat3;
                        boats.boat3 = "";
                        boats.boatNumber1 = boats.boatNumber3;
                        boats.boatNumber3 = 0;
                    }
                    else if (boats.noOfBoats == 4)
                    {
                        boats.boat1 = boats.boat4;
                        boats.boat4 = "";
                        boats.boatNumber1 = boats.boatNumber4;
                        boats.boatNumber4 = 0;
                    }
                    else if (boats.noOfBoats == 5)
                    {
                        boats.boat1 = boats.boat5;
                        boats.boat5 = "";
                        boats.boatNumber1 = boats.boatNumber5;
                        boats.boatNumber5 = 0;
                    }

                }
                else if (boats.boat2 == boat.boatName)
                {
                    if (boats.noOfBoats == 2)
                    {
                        boats.boat2 = "";
                        boats.boatNumber2 = 0;
                    }
                    else if (boats.noOfBoats == 3)
                    {
                        boats.boat2 = boats.boat3;
                        boats.boat3 = "";
                        boats.boatNumber2 = boats.boatNumber3;
                        boats.boatNumber3 = 0;
                    }
                    else if (boats.noOfBoats == 4)
                    {
                        boats.boat2 = boats.boat4;
                        boats.boat4 = "";
                        boats.boatNumber2 = boats.boatNumber4;
                        boats.boatNumber4 = 0;
                    }
                    else if (boats.noOfBoats == 5)
                    {
                        boats.boat2 = boats.boat5;
                        boats.boat5 = "";
                        boats.boatNumber2 = boats.boatNumber5;
                        boats.boatNumber5 = 0;
                    }


                }

                else if (boats.boat3 == boat.boatName)
                {
                    if (boats.noOfBoats == 3)
                    {
                        boats.boat3 = "";
                        boats.boatNumber3 = 0;
                    }
                    else if (boats.noOfBoats == 4)
                    {
                        boats.boat3 = boats.boat4;
                        boats.boat4 = "";
                        boats.boatNumber3 = boats.boatNumber4;
                        boats.boatNumber4 = 0;
                    }
                    else if (boats.noOfBoats == 5)
                    {
                        boats.boat3 = boats.boat5;
                        boats.boat5 = "";
                        boats.boatNumber3 = boats.boatNumber5;
                        boats.boatNumber5 = 0;
                    }

                }
                else if (boats.boat4 == boat.boatName)
                {
                    if (boats.noOfBoats == 4)
                    {
                        boats.boat4 = "";
                        boats.boatNumber4 = 0;
                    }
                    else if (boats.noOfBoats == 5)
                    {
                        boats.boat4 = boats.boat5;
                        boats.boat5 = "";
                        boats.boatNumber4 = boats.boatNumber5;
                        boats.boatNumber5 = 0;
                    }

                }
                else if (boats.boat5 == boat.boatName)
                {
                    boats.boat5 = "";
                    boats.boatNumber5 = 0;

                }

                LoadFullSQL.SQLAddboat(boats.name, boats.noOfBoats, boats.boat1, boats.boatNumber1);
                LoadFullSQL.SQLAddboat(boats.name, boats.noOfBoats, boats.boat2, boats.boatNumber2);
                LoadFullSQL.SQLAddboat(boats.name, boats.noOfBoats, boats.boat3, boats.boatNumber3);
                LoadFullSQL.SQLAddboat(boats.name, boats.noOfBoats, boats.boat4, boats.boatNumber4);
                LoadFullSQL.SQLAddboat(boats.name, boats.noOfBoats, boats.boat5, boats.boatNumber5);
                }
            */
            



        }
        public static void SQLremove(bool race, string name)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                //connection.Query("call removeperson('" + race + "', '" + name + "')");
                connection.Query("call removeperson(@race, @name)", new { race = race, name = name });
            }
        }
        public static void SQLaddnewracer(Boats personboat)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                connection.Query("call enterraceperson(@name, @boatName, @boatNumber)", new
                {
                    name = personboat.name,
                    boatName = personboat.boatName,
                    boatNumber = personboat.boatNumber
                });
            }
        }

        public static Dictionary<string, Boatsold> getdictionary(List<Boatsold> list)
        {
            Dictionary<string, Boatsold> boatDictionary = new Dictionary<string, Boatsold>();
            foreach (var boat in list)
            {
                boatDictionary.Add(boat.name, boat);
            }
            return boatDictionary;
        }
        /*
        public void Addboat(string name)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                connection.Query($"update fulllist set '{ name }'");
            }
        }
        */
        public static List<string> GetNames()
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                //string sql = "call returnboat('" + name + "')";
                //var obj =  connection.Query<Boats>(sql).First();
                return connection.Query<string>("call returnnames").Distinct<string>().ToList();


                //return obj;
                //return connection.Query<Boats>("returnboat @fullname", new { fullname = name }).First();
            }
        }
        public List<Boats> GetBoat(string name)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                //string sql = "call returnboat('" + name + "')";
                //var obj =  connection.Query<Boats>(sql).First();
                try
                {
                    return connection.Query<Boats>("call returnboat(@name)", new { name = name }).ToList();

                }
                catch (InvalidOperationException)
                {
                    return new List<Boats>();
                }
                //return obj;
                //return connection.Query<Boats>("returnboat @fullname", new { fullname = name }).First();
            }
        }

        public List<Boatsold> GetBoats()
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                //return connection.Query<Boats>("call returnboats(@dbname)", new { dbname = dbname }).ToList();
                return connection.Query<Boatsold>("call returnboats").ToList();

            }
        }
        public static void AddPerson(System.String Name)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                connection.Query("call enterperson(@name)", new { name = Name });
            }
        }
        public static void SQLAddboat(string name, string boat, int boatnumber)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                //connection.Query("call newboat('" + name + "', '" + boat + "', '" + boatnumber + "','" + noofboats + "')");
                connection.Query("call newboat(@name, @boat, @boatnumber)", new
                {
                    name = name,
                    boat = boat,
                    boatnumber = boatnumber
                });
            }
        }
        public static void AddBoat(Boatsold personboat)
        {
            /*
            Console.WriteLine("Would you like to add a new boat, Y/N?");
            string response1 = Console.ReadLine();
            if (response1 == "y" || response1 == "Y")
            {
                Console.WriteLine("Enter boatname");
                string boat = Console.ReadLine();
                Console.WriteLine("Enter boatnumber");
                int boatnumber = int.Parse(Console.ReadLine());

                using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
                {

                    try
                    {
                        var boat1 = connection.Query<Boatsold>("call returnboat(@name)", new { name = personboat.name }).First();
                        if (boat1.boat1 == "")
                        {
                            SQLAddboat(personboat.name, 0, boat, boatnumber);
                        }
                        else if (boat1.boat2 == "")
                        {
                            SQLAddboat(personboat.name, 1, boat, boatnumber);
                        }
                        else if (boat1.boat3 == "")
                        {
                            SQLAddboat(personboat.name, 2, boat, boatnumber);
                        }
                        else if (boat1.boat4 == "")
                        {
                            SQLAddboat(personboat.name, 3, boat, boatnumber);
                        }
                        else if (boat1.boat5 == "")
                        {
                            SQLAddboat(personboat.name, 4, boat, boatnumber);
                        }
                        else
                        {
                            Console.WriteLine("You have the max number of boats(5), would you like to remove one?");
                            Console.WriteLine("Here are your 5 boats");
                            displayboats(personboat);
                            if (Console.ReadLine() == "Y" || Console.ReadLine() == "y")
                            {
                                BoatsRacing boatsracing = new BoatsRacing();
                                Console.WriteLine("Which boat would you like to remove?");
                                var answer = Console.ReadLine();
                                if (answer == personboat.boat1)
                                {
                                    boatsracing.name = personboat.name;
                                    boatsracing.boatName = personboat.boat1;
                                    boatsracing.boatNumber = personboat.boatNumber1;
                                    LoadFullSQL.SQLremoveboat(personboat, boatsracing);

                                }
                                else if (answer == personboat.boat2)
                                {
                                    boatsracing.name = personboat.name;
                                    boatsracing.boatName = personboat.boat2;
                                    boatsracing.boatNumber = personboat.boatNumber2;
                                    LoadFullSQL.SQLremoveboat(personboat, boatsracing);

                                }
                                else if (answer == personboat.boat3)
                                {
                                    boatsracing.name = personboat.name;
                                    boatsracing.boatName = personboat.boat3;
                                    boatsracing.boatNumber = personboat.boatNumber3;
                                    LoadFullSQL.SQLremoveboat(personboat, boatsracing);

                                }
                                else if (answer == personboat.boat4)
                                {
                                    boatsracing.name = personboat.name;
                                    boatsracing.boatName = personboat.boat4;
                                    boatsracing.boatNumber = personboat.boatNumber4;
                                    LoadFullSQL.SQLremoveboat(personboat, boatsracing);

                                }
                                else if (answer == personboat.boat5)
                                {
                                    boatsracing.name = personboat.name;
                                    boatsracing.boatName = personboat.boat5;
                                    boatsracing.boatNumber = personboat.boatNumber5;
                                    LoadFullSQL.SQLremoveboat(personboat, boatsracing);

                                }
                                else
                                    Console.WriteLine("That is not one of the boats.");

                            }
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Your name is not in my database");
                    }


                }
            }
        */
        }
    }
}

