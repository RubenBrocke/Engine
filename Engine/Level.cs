using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Level
    {
        public Ground[] grounds;

        public Level(params Ground[] groundsArray)
        {
            this.grounds = groundsArray;
        }

        public void Draw()
        {
            foreach(var ground in grounds)
            {
                ground.Draw();
            }
        }

        public void Add(Ground ground)
        {
            grounds[grounds.Length] = ground;
        }

    }
}
