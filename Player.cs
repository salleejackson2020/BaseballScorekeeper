using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballScorekeeper
{
    public class Player(string name) //Base class for Pitcher and Batter.
    {
        private string name = name;

        public string Name { get { return name; } }
    }
}
