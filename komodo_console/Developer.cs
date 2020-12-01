using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komodo_console
{
    public enum ProgrammingLanguage
    {
        Ruby = 1,
        Python,
        CSharp,
        Java,
        JavaScript,
        PHP,
        SQL,
        Kotlin
    }
    public class Developer
    {
        public double IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyEmail { get; set; }
        public ProgrammingLanguage SpecificLanguage { get; set; }
        public bool PluralSightLicense { get; set; }


        public Developer() { }
        public Developer(double idNumber, string firstName, string lastName, string companyEmail, ProgrammingLanguage language, bool pluralSightLicense)
        {
            IdNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            CompanyEmail = companyEmail;
            SpecificLanguage = language;
            PluralSightLicense = pluralSightLicense;

        }






    }
    
}
