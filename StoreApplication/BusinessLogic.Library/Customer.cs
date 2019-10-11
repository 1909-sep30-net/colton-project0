using System;
using System.Linq;

namespace BusinessLogic.Library
{
    /// <summary>
    /// A class of customers with first and last names and Id's
    /// </summary>
    public class Customer
    {
        private string fname;
        private string lname;
        private int id;

 
        public string Fname 
        { 
            get => fname;
            set 
            { 
                fname = value; 
            } 
        }
        public string Lname 
        {
            get => lname;
            set
            {
                lname = value;
            }
        }

        public int Id 
        {
            get => id;
            set
            {
                id = value; 
            } 
        }
        
        private void CheckFname(string f)
        {
            if (f.Length == 0)
                throw new Exception("First name is empty");
            else if (f.Length > 20)
                throw new Exception("First name has too many characters");
            else if (!f.All(Char.IsLetter))
                throw new Exception("First name cannot include special characters");
        }

        private void CheckLname(string l)
        {
            if (l.Length == 0)
                throw new Exception("First name is empty");
            else if (l.Length > 20)
                throw new Exception("First name has too many characters");
            else if (!l.All(Char.IsLetter))
                throw new Exception("First name cannot include special characters");
        }
    }

}
