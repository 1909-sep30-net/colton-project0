using System;
using System.Linq;

namespace BusinessLogic.Library
{
    /// <summary>
    /// A class of customers with first and last names and Id's
    /// </summary>
    public class Customer
    {
        private string _fname;
        private string _lname;
        public int Id { get; set; }

 
        public string Fname 
        { 
            get => _fname;
            set 
            { 
                if(value.Length == 0)
                {
                    throw new ArgumentException("First Name must not be empty", nameof(value));
                }
                _fname = value; 
            } 
        }
        public string Lname 
        {
            get => _lname;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Last Name must not be empty", nameof(value));
                }
                _lname = value;
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
