using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAGAIN_
{
    public class IllegalSongLengthException : Exception
    {
        public IllegalSongLengthException():base("Song length cant have negative numbers") { }
    }
}
