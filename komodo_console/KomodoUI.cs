using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komodo_console
{
    class KomodoUI
    {
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        

        public void Run()
        {
            //SeedDevTeamList();
            SeedDeveloperList();
            MainMenu();
        }

        //menu
        private void MainMenu()
        {
            bool mainMenu = true;
            while (mainMenu)
            {
                Console.WriteLine("Welcome To The Main Menu\n\n\n\n" +
                                  "1. Dev Teams Management Software\n\n" +
                                  "2. Developer Management Software\n\n" +
                                  "3. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        TeamsMenu();
                        break;
                    case "2":
                        DevMenu();
                        break;
                    case "3":
                        Console.WriteLine("GoodBye");
                        mainMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter A Valid Number");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void TeamsMenu()
        {
            Console.Clear();
            bool menuOn = true;
            while (menuOn)
            {
                Console.WriteLine("Welcome to Komodo's DevTeam Management Software\n\n\n\n\n" +
                                  "1. Create new Team\n\n" +
                                  "2. Add Developers To Teams\n\n" +
                                  "3. View All Teams\n\n" +
                                  "4. View Teams by ID\n\n" +
                                  "5. Update Teams\n\n" +
                                  "6. Delete Teams\n\n" +
                                  "7. Exit");
                string menuInput = Console.ReadLine();
                switch (menuInput)
                {
                    case "1":
                        AddTeams();
                        break;
                    case "2":
                        AddDevelopersToTeam();
                        break;
                    case "3":
                        ViewDevTeams();
                        break;
                    case "4":
                        ViewTeamsById();
                        break;
                    case "5":
                        UpdateTeams();
                        break;
                    case "6":
                        DeleteTeams();
                        break;
                    case "7":
                        Console.WriteLine("Have A Great Day!");
                        menuOn = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddTeams()
        {
            Console.Clear();
            DevTeam devTeam = new DevTeam();

            Console.WriteLine("Enter ID Number for the Developer");
            string idInputString = Console.ReadLine();
            devTeam.IddNumber = int.Parse(idInputString);
            Console.WriteLine("Enter Team Name");
            devTeam.GroupName = Console.ReadLine();

            Console.WriteLine("Enter Projects Name");
            devTeam.Projects = Console.ReadLine();

            Console.WriteLine("Enter Programming languages used");
            devTeam.Languages = Console.ReadLine();
        }
        private void AddDevelopersToTeam()
        {
            Console.Clear();
            ViewAllDevelopers();
            Console.WriteLine("Enter Developer ID to Add to Team");
            var line = Console.ReadLine();
            var data = line.Split(' ');
            var inputdev1 = int.Parse(data[0]); //first integer
            var inputdev2 = int.Parse(data[1]); //second integer

            //int inputDev = int.Parse(Console.ReadLine());
            Developer developer = _developerRepo.GetDeveloper(inputdev1, inputdev2);

            //double devInput = double.Parse(inputDev);
            ViewDevTeams();
            Console.WriteLine("\n" +
                "\n");
            Console.WriteLine("Please enter Development team ID");
            int inputTeamId = int.Parse(Console.ReadLine());
            DevTeam devTeam = _devTeamRepo.GetTeam(inputTeamId);
            devTeam.Developers.Add(developer);
            
        }

        private void ViewDevTeams()
        {
            Console.Clear();
            List<DevTeam> devTeams = _devTeamRepo.ListOfTeams();
            foreach(DevTeam devTeam in devTeams)
            {
                Console.WriteLine($"ID Number: {devTeam.IddNumber}\n" +
                                  $"Group Name: {devTeam.GroupName}\n" +
                                  $"Projects: {devTeam.Projects}\n" +
                                  $"Languages: {devTeam.Languages}");
               
                
            DisplayTeamMembers(devTeam);
            }
        }

        private void DisplayTeamMembers(DevTeam devTeam)
        {
            foreach (var developer in devTeam.Developers)
            {
                Console.WriteLine($"DEveloper ID Number{developer.IdNumber}\n" +
                                      $"Developer Name: {developer.FirstName} {developer.LastName}\n" +
                                      $"Developer specific language: {developer.SpecificLanguage}\n" +
                                      $"Developer has pluralsight: {developer.PluralSightLicense}\n" +
                                      $"*******************************************************");
                                
            }
        }
        private void ViewTeamsById()
        {
            Console.Clear();
            Console.WriteLine("Enter DevTeams Id");
            string idUser = Console.ReadLine();
            int teamId = int.Parse(idUser);
            DevTeam devTeam = _devTeamRepo.GetTeam(teamId);
            if(devTeam != null)
            {
                Console.WriteLine($"Id Number {devTeam.IddNumber}\n" +
                                  $"Team Name {devTeam.GroupName}\n" +
                                  $"Projects {devTeam.Projects}\n" +
                                  $"Programming Languages used {devTeam.Languages}");
                DisplayTeamMembers(devTeam);
            }
            else
            {
                Console.WriteLine("DevTeam Does Not Exist");
            }
        }
        private void UpdateTeams()
        {
            ViewDevTeams();
            Console.WriteLine("Enter the Id of the team you would like to update");
            string oldTeamID = Console.ReadLine();
            int devTeamID = int.Parse(oldTeamID);
            Console.Clear();

            DevTeam newDevTeam = new DevTeam();
            Console.WriteLine("Enter Team ID");
            string inputUser = Console.ReadLine();
            newDevTeam.IddNumber = int.Parse(inputUser);

            Console.WriteLine("Team Name");
            newDevTeam.GroupName = Console.ReadLine();

            Console.WriteLine("Projects");
            newDevTeam.Projects = Console.ReadLine();

            Console.WriteLine("Programming Languages used");
            newDevTeam.Languages = Console.ReadLine();

            bool teamUpdated = _devTeamRepo.UpdateExistingTeam(devTeamID, newDevTeam);
            if (teamUpdated)
            {
                Console.WriteLine("DevTeam Successfully Updated");
            }
            else
            {
                Console.WriteLine("DevTeam Failed To Update");
            }
        }
        private void DeleteTeams()
        {
            ViewDevTeams();
            Console.WriteLine("Enter The ID of the DevTeam you would like to remove");
            string teamRemove = Console.ReadLine();
            int idTeam = int.Parse(teamRemove);
            bool teamRemoved = _devTeamRepo.RemoveTeam(idTeam);
            if (teamRemoved)
            {
                Console.WriteLine("The DevTeam was Successfully Removed");
            }
            else
            {
                Console.WriteLine("Failed To Remove DevTeam");
            }
        }

        private void SeedDevTeamList()
        {
            //DevTeam Team1 = new DevTeam(4, "Team1", "Catalyst", "CSharp");
            //DevTeam Team2 = new DevTeam(5, "Team2", "Hindsight", "Python, cSharp");

            //_devTeamRepo.AddTeam(Team1);
            //_devTeamRepo.AddTeam(Team2);
        }
        private void DevMenu()
        {
            Console.Clear();
            bool alwaysOn = true;
            while (alwaysOn)
            {
                Console.WriteLine("Welcome To KDMS\n" +
                                  "Komodo's Developer Management Software\n" +
                                  "**************************************\n\n\n" +
                                  "Select a Menu Option\n\n\n" +
                                  "1. Add a New Developer\n\n" +
                                  "2. View All Developers\n\n" +
                                  "3. View Developer by ID Number\n\n" +
                                  "4. Update An Existing Developer\n\n" +
                                  "5. Delete An Existing Developer\n\n" +
                                  "6. Developers that need access to PluralSight\n\n" +
                                  "7. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddDeveloperToList();
                        break;
                    case "2":
                        ViewAllDevelopers();
                        break;
                    case "3":
                        ViewDevelopersByID();
                        break;
                    case "4":
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        RemoveDeveloper();
                        break;
                    case "6":
                       // plAccess
                        break;
                    case "7":
                        Console.WriteLine("Have a Great Day, Good Bye");
                        alwaysOn = false;
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
                              "1. Ruby\n" +
                              "2. Python\n" +
                              "3. CSharp\n" +
                              "4. Java\n" +
                              "5. JavaScript\n" +
                              "6. PHP\n" +
                              "7. SQL\n" +
                              "8. Kotlin");
            string numAsString = Console.ReadLine();
            int numAsInt = int.Parse(numAsString);
            developer.SpecificLanguage = (ProgrammingLanguage)numAsInt;

            Console.WriteLine("Does this developer have a PluralSight License?");
            string pluralSight = Console.ReadLine().ToLower();
            if (pluralSight == "y")
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
            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"ID Number: {developer.IdNumber}\n" +
                                  $"First Name: {developer.FirstName}\n" +
                                  $"Last Name: {developer.LastName}\n" +
                                  $"Company E-Mail: {developer.CompanyEmail}\n" +
                                  $"Specific Language: {developer.SpecificLanguage}\n" +
                                  $"******************************************************\n" +
                                  $"******************************************************");
            }
        }
        private void ViewDevelopersByID()
        {
            Console.Clear();
            Console.WriteLine("Enter The Developers ID Number");
            string idNumAsString = Console.ReadLine();
            int idNumber = int.Parse(idNumAsString);
            Developer developer = _developerRepo.GetDeveloper(idNumber);
            if (developer != null)
            {
                Console.WriteLine($"ID Number: {developer.IdNumber}\n" +
                                  $"First Name: {developer.FirstName}\n" +
                                  $"Last Name: {developer.LastName}\n" +
                                  $"Company E-mail: {developer.CompanyEmail}" +
                                  $"Proficient Language: {developer.SpecificLanguage}\n" +
                                  $"PluralSight License: {developer.PluralSightLicense}");
                
            }
            else
            {
                Console.WriteLine("Developer Does Not exist");
            }
        }

        private void UpdateExistingDeveloper()
        {
            ViewAllDevelopers();
            Console.WriteLine("Enter the ID of the developer you would like to update");
            string oldId = Console.ReadLine();
            int oldIdd = int.Parse(oldId);
            Console.Clear();
            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter First Name");
            newDeveloper.FirstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name");
            newDeveloper.LastName = Console.ReadLine();

            Console.WriteLine("Enter Company E-mail");
            newDeveloper.CompanyEmail = Console.ReadLine();

            Console.WriteLine($"Choose a Specific Language and enter the number\n\n" +
                              "1. Ruby\n" +
                              "2. Python\n" +
                              "3. CSharp\n" +
                              "4. Java\n" +
                              "5. JavaScript\n" +
                              "6. PHP\n" +
                              "7. SQL\n" +
                              "8. Kotlin");
            string select = Console.ReadLine();
            int selectAsInt = int.Parse(select);
            newDeveloper.SpecificLanguage = (ProgrammingLanguage)selectAsInt;

            Console.WriteLine("Does this developer have a PluralSight License?");
            string plLicense = Console.ReadLine();
            if (plLicense == "y")
            {
                newDeveloper.PluralSightLicense = true;
            }
            else
            {
                newDeveloper.PluralSightLicense = false;
            }

            bool updated = _developerRepo.UpdateExistingDeveloper(oldIdd, newDeveloper);
            if (updated)
            {
                Console.WriteLine("Developer Successfully Updated");
            }
            else
            {
                Console.WriteLine("Update Failure");
            }
        }

        private void RemoveDeveloper()
        {
            ViewAllDevelopers();
            Console.WriteLine("Enter The Id of the developer you want to remove");
            string uniqueID = Console.ReadLine();
            int userID = int.Parse(uniqueID);
            bool wasRemoved = _developerRepo.RemoveDeveloper(userID);
            if (wasRemoved)
            {
                Console.WriteLine("The developer was successfully removed");
            }
            else
            {
                Console.WriteLine("Deletion Unsuccessful");
            }
        }
        private void SeedDeveloperList()
        {
            Developer FredCurger = new Developer(1, "Fred", "Cruger", "Cruger@company.com", ProgrammingLanguage.Java, true);
            Developer JackFrost = new Developer(2, "Jack", "Frost", "jFrost@company.com", ProgrammingLanguage.CSharp, true);
            Developer HenryCalahann = new Developer(3, "Henry", "Calahann", "hCalahann@company.com", ProgrammingLanguage.Python, false);
            Developer JohnKulheim = new Developer(4, "John", "Kulheim", "jKulheim@company.com", ProgrammingLanguage.CSharp, true);
            Developer MichelleRollins = new Developer(5, "Michelle", "Rollins", "mRollins@company.com", ProgrammingLanguage.Java, true);
            Developer ShellyThompson = new Developer(6, "Shelly", "Thompson", "sThompson@company.com", ProgrammingLanguage.Ruby, true);
            Developer BradKinder = new Developer(7, "Brad", "Kinder", "bKinder@company.com", ProgrammingLanguage.SQL, false);

            _developerRepo.AddDeveloperToList(JackFrost);
            _developerRepo.AddDeveloperToList(FredCurger);
            _developerRepo.AddDeveloperToList(HenryCalahann);
            _developerRepo.AddDeveloperToList(JohnKulheim);
            _developerRepo.AddDeveloperToList(MichelleRollins);
            _developerRepo.AddDeveloperToList(ShellyThompson);
            _developerRepo.AddDeveloperToList(BradKinder);



            DevTeam Team1 = new DevTeam(4, "Team1", "Catalyst", "CSharp");
            DevTeam Team2 = new DevTeam(5, "Team2", "Hindsight", "Python, cSharp");

            _devTeamRepo.AddTeam(Team1);
            _devTeamRepo.AddTeam(Team2);

            Team1.Developers.Add(JackFrost);
            Team1.Developers.Add(HenryCalahann);
            Team1.Developers.Add(JohnKulheim);

            Team2.Developers.Add(MichelleRollins);
            Team2.Developers.Add(ShellyThompson);
            Team2.Developers.Add(BradKinder);

        }
        private Developer plAccess(bool pluralSightLicense, Developer developer)
        {
            if(pluralSightLicense == false)
            {
                return developer;
            }
            else
            {
                return null;
            }
        }
        
            
        
    }
}

