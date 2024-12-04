using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical08
{
    public abstract class GameEntity
    {
        public virtual void add(GameEntity ge)
        {
            throw new NotSupportedException();
        }
        public virtual void remove(GameEntity ge)
        {
            throw new NotSupportedException();
        }
        public virtual GameEntity getChild(int index)
        {
            throw new NotSupportedException();
        }
        public virtual void print()
        {
            throw new NotSupportedException();
        }
        public virtual string getDescription()
        {
            throw new NotSupportedException();
        }

        public virtual string Name
        {
            get
            {
                throw new NotSupportedException();
            }
        }
        public virtual string Profession
        {
            get
            {
                throw new NotSupportedException();
            }
        }

    }
}
