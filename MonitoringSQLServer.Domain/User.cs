using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        private DateTime RegistrationDate { get; set; }
        public List<UserGroup> UserGroups { get; set; }
        public User()
        {
            UserGroups = new List<UserGroup>();
        }

        public DateTime RegDate
        {
            get
            {
                return RegistrationDate;
            }

            set
            {
                RegistrationDate = value;
            }
        }
    }
}
