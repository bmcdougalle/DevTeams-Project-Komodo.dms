using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    class KomodoUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
       
        public void Run()
        {

        }

        //menu
        private void Menu()
        {
            bool alwaysOn = true;
            while (alwaysOn)
            {
                Console.WriteLine("Welcome To KDMS\n" +
                                  "Komodo's Developer Management Software\n\n\n\n" +
                                  "Select a Menu Option\n" +
                                  "1. Add a New Developer\n" +
                                  "2. View All Developers\n" +
                                  "3. View Developer by ID Number\n" +
                                  "4. Update An Existing Developer\n" +
                                  "5. Delete An Existing Developer\n" +
                                  "6. PluralSight Licensed Developers\n" +
                                  "7. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //create new developer
                        break;
                    case "2":
                        //view all developers
                        break;
                    case "3":
                        //View Developer by idnumber
                        break;
                    case "4":
                        //update existing developer
                        break;
                    case "5":
                    //Delete Existing Developer
                    case "6":
                        //view plural sight licensed developers
                        break;
                    case "7":
                        //Exit
                        break;
                    default:
                        Console.WriteLine("Please Enter A Valid Number");
                        break;

                }
                Console.WriteLine("please Press Any Key To Continue");
                Console.ReadKey();
                Console.Clear();


            }
        }

        //add new developer
        private void AddDeveloperToList()
        {
            Console.Clear();
            Developer developer = new Developer();

            Console.WriteLine("Enter ID NUmber for the Developer");
            string idAsString = Console.ReadLine();
            developer.IdNumber = double.Parse(idAsString);

            Console.WriteLine("Enter The Developers First Name");
            developer.FirstName = Console.ReadLine();

            Console.WriteLine("Enter The Developer's Last Name");
            developer.LastName = Console.ReadLine();

            Console.WriteLine("Enter Developer's company E-mail");
            developer.CompanyEmail = Console.ReadLine();

            Console.WriteLine("Enter number for the Developer's Most Proficient Language\n" +
                              "Ruby\n" +
                              "Python\n" +
                              "CSharp\n" +
                              "Java\n" +
                              "JavaScript\n" +
                              "PHP\n" +
                              "SQL\n" +
                              "Kotlin");
            string numAsString = Console.ReadLine();
            int numAsInt = int.Parse(numAsString);
            developer.SpecificLanguage = (ProgrammingLanguage)numAsInt;

            Console.WriteLine("Does this developer have a PluralSight License?");
            string pluralSight = Console.ReadLine().ToLower();
            if(pluralSight == "y")
            {
                developer.PluralSightLicense = true;
            }
            else
            {
                developer.PluralSightLicense = false;
            }

            _developerRepo.AddDeveloperToList(developer);

        }
        private void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.GetDevelopers();
            foreach(Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"ID Number: {developer.IdNumber}\n" +
                                  $"First Name: {developer.FirstName}\n" +
                                  $"Last Name: {developer.LastName}\n" +
                                  $"Company E-Mail: {developer.CompanyEmail}\n" +
                                  $"Specific Language: {developer.SpecificLanguage}\n" +
                                  $"PluralSight License: {developer.PluralSightLicense}\n" +
                                  $"******************************************************");
            }
        }
    }
}
