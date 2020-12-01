using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komodo_console
{
   
    class DeveloperRepo
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
        public bool UpdateExistingDeveloper(int idNumber, Developer newDeveloper)
        {
            //find a developer
            Developer oldData = GetDeveloper(idNumber);

            //update data
            if (oldData != null)
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
        public bool RemoveDeveloper(int idNumber)
        {
            Developer Developer = GetDeveloper(idNumber);
            {
                if (Developer == null)
                {
                    return false;
                }

                int initialCount = _developerDirectory.Count;
                _developerDirectory.Remove(Developer);

                if (initialCount > _developerDirectory.Count)
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
        public void GetDeveloper() { }
        public Developer GetDeveloper(int idNumber, int inputdev2)
        {
            foreach (Developer developer in _developerDirectory)
            {
                if (developer.IdNumber == idNumber)
                {
                    return developer;
                }
            }
            return null;
        }
        public Developer DevAccess(bool pluralSight)
        {
            foreach(Developer developer in _developerDirectory)
            {
                if(developer.PluralSightLicense == false)
                {
                    return developer;
                }
            }
            return null;
        }
    }
}
