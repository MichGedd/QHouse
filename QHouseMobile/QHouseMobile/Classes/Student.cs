using System;
using System.Collections.Generic;
using System.Text;

namespace QHouseMobile.Classes
{
    class Student
    {
        private int id;
        private string email;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Name { get => name; set => name = value; }
    }
}
