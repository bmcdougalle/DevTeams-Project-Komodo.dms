using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komodo_console
{
    public class DevTeam
    {
        public int IddNumber { get; set; }
        public string GroupName { get; set; }
        public string Projects { get; set; }
        public string Languages { get; set; }
        public List<Developer> Developers { get; set; } 

        public DevTeam() { }
        
        public DevTeam(int iddNumber, string groupName, string projects, string languages)
        {
            IddNumber = iddNumber;
            GroupName = groupName;
            Projects = projects;
            Languages = languages;
            Developers = new List<Developer>();
            
        }

       
    }
}
