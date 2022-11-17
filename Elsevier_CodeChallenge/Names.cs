using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsevier_CodeChallenge
{
    /// <summary>
    /// Class of "raw data" objects, with only a getter and setter to be used in either layers/classes.
    /// </summary>
    public class Names
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Names(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}
