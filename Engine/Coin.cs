using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Coin
    {
        public int x;
        public int y;
        public bool pickedUp = false;
        public Sprite sprite;
        public Rectangle hitbox;

        public Coin(int _x, int _y, Sprite _sprite)
        {
            x = _x;
            y = _y;
            sprite = _sprite;
            hitbox = new Rectangle((int)x - sprite.origin_x, (int)y - sprite.origin_y, sprite.width, sprite.height);
        }

        public void Update()
        {

            if (hitbox.Intersects(Player.hitbox))
            {
                pickedUp = true;
            }
        }

        public void Draw()
        {
            if (!pickedUp)
            {
                Game1.spriteBatch.Draw(sprite.texture, position: new Vector2(x, y));
            }
        }
    }
}
