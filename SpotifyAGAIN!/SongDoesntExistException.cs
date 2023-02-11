using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAGAIN_
{
    public class SongDoesntExistException : Exception
    {
        public SongDoesntExistException() : base("Song does not exist!") 
        {
            
        }
    }
}
