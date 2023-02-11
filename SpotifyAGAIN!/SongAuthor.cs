using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAGAIN_
{
    public class SongAuthor : Person
    {
        public SongAuthor(string firstName, string lastName) : base(firstName, lastName)
        {

        }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
