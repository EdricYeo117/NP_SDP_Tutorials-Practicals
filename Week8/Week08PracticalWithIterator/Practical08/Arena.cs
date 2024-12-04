using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical08
{
    public class Arena
    {
        private GameEntity gameEntity;

        public Arena(GameEntity ge)
        {
            this.gameEntity = ge;
        }
        public void addEntity(GameEntity ge)
        {
            gameEntity.add(ge);
        }
        public void removeEntity(GameEntity ge)
        {
            gameEntity.remove(ge);
        }
        public void print()
        {
            gameEntity.print();
        }
    }
}
