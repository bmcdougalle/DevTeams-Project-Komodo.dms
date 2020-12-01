using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddDeveloperToList(Developer developer)
        {
            _developerDirectory.Add(developer);
        }

        //Developer Read
        public List<Developer> GetDevelopers()
        {
            return _developerDirectory;
        }

        //Developer Update
        public bool UpdateExistingDeveloper(double idNumber, Developer newDeveloper)
        {
            //find a developer
            Developer oldData = GetDeveloper(idNumber);

            //update data
            if(oldData != null)
            {
                oldData.IdNumber = newDeveloper.IdNumber;
                oldData.FirstName = newDeveloper.FirstName;
                oldData.LastName = newDeveloper.LastName;
                oldData.SpecificLanguage = newDeveloper.SpecificLanguage;
                oldData.PluralSightLicense = newDeveloper.PluralSightLicense;

                return true;
            }
            else
            {
                return false;
            }
        }           

        //Developer Delete
        public bool RemoveDeveloper(double idNumber)
        {
            Developer Developer = GetDeveloper(idNumber);
            {
                if(Developer == null)
                {
                    return false;
                }

                int initialCount = _developerDirectory.Count;
                _developerDirectory.Remove(Developer);

                if(initialCount > _developerDirectory.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloper(double idNumber)
        {
            foreach(Developer developer in _developerDirectory)
            {
                if(developer.IdNumber == idNumber)
                {
                    return developer;
                }
            }
            return null;
        }
    }
}
