using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Engine
{
    public class Level
    {
        public List<Ground> grounds = new List<Ground>();
        public List<Coin> coins = new List<Coin>();

        public Level(params Ground[] groundsArray)
        {
            foreach (var ground in groundsArray)
            {
                grounds.Add(ground);
            }
        }

        public void Update()
        {
            foreach (var coin in coins)
            {
                coin.Update();
            }
        }

        public void Draw()
        {
            foreach(var ground in grounds)
            {
                ground.Draw();
            }

            foreach (var coin in coins)
            {
                coin.Draw();
            }
        }

        public void Add(Ground ground)
        {
            grounds.Add(ground);
        }

        public void Add(Coin coin)
        {
            coins.Add(coin);
        }

    }
}
