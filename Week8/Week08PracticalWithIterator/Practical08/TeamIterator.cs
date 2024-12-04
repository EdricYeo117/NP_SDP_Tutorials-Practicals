using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical08
{
    public class TeamIterator
    {
        private List<GameEntity> teams;
        private int position = 0;

        public TeamIterator(List<GameEntity> teams)
        {
            this.teams = teams;
        }
        public bool hasNext()
        {
            return position < teams.Count;
        }
        public Object next() { 
            return teams[position++];
        }
    }
}
