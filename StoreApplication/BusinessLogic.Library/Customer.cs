using System;

namespace BusinessLogic.Library
{
    public class Customer
    {
        private string fname;
        private string lname;
        private int id;

        //private string Location;
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
        //public string location { get;}
        public int Id 
        {
            get => id;
            set
            {
                id = value; 
            } 
        }
        //public Customer(string Fname, string Lname, string Location)
        //{
        //    this.Fname = Fname;
        //    this.Lname = Lname;
        //   // this.Location = Location;

        //}

    }

}
