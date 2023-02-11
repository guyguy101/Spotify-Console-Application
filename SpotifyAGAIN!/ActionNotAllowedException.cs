using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAGAIN_
{
    public class ActionNotAllowedException : Exception
    {
        public ActionNotAllowedException() :base($"You cannot like more than 10 songs because you are account type is {ClientType.Regular}"){ }
    }
}
