using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komodo_console
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //DevTeam Create
        public void AddTeam(DevTeam devTeam)
        {
            _devTeams.Add(devTeam);

        }

        //DevTeam Read
        public List<DevTeam> ListOfTeams()
        {
            return _devTeams;
        }

        //DevTeam Update
        public bool UpdateExistingTeam(int idNumber, DevTeam newDevTeam)
        {
            DevTeam oldTeam = GetTeam(idNumber);
            if(oldTeam != null)
            {
                oldTeam.IddNumber = newDevTeam.IddNumber;
                oldTeam.GroupName = newDevTeam.GroupName;
                oldTeam.Projects = newDevTeam.Projects;
                oldTeam.Languages = newDevTeam.Languages;

                return true;
            }
            else
            {
                return false;
            }
        }
        //DevTeam Delete
        public bool RemoveTeam(int iddNumber)
        {
            DevTeam devTeam = GetTeam(iddNumber);
            {
                if (devTeam == null)
                {
                    return false;
                }

                int initialCount = _devTeams.Count;
                _devTeams.Remove(devTeam);

                if (initialCount > _devTeams.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
       
        //Generate devTeam Id
        //private static readonly Random _rdm = new Random();
        //private string IDGenerator(int digits)
        //{
        //    if (digits <= 1) return "";

        //    var _min = (int)Math.Pow(10, digits - 1);
        //    var _max = (int)Math.Pow(10, digits) - 1;
        //    return _rdm.Next(_min, _max).ToString();
        //}

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetTeam(int iddNumber)
        {
            foreach(DevTeam devTeam in _devTeams)
            {
                if(devTeam.IddNumber == iddNumber)
                {
                    return devTeam;
                }
            }
            return null;
        }

        public void AddMultipleDevsToTeam(int ID, List<Developer> developers)
        {
            var devTeam = GetTeam(ID);
            if(devTeam != null)
            {
                foreach (var developer in developers)
                {
                    devTeam.Developers.Add(developer);
                }
            }
        }

    }
}
