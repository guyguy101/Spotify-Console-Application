using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAGAIN_
{
    public class IleegalChoiceException : Exception
    {
        public IleegalChoiceException():base("Choice Is Not Available!") 
        {
        
        }
    }
}
