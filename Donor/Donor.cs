using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donor
{
    internal class Donor
    {
        public string Name { get; set; }
        public string Birth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }
        public string Occupation { get; set; }

        public Donor(string name, string birth, string gender, string email, string phone, string address, string bloodgroup, string occupation)
        {
            Name = name;
            Birth = birth;
            Gender = gender;
            Email = email;
            Phone = phone;
            Address = address;
            BloodGroup = bloodgroup;
            Occupation = occupation;
        }
    }
}
