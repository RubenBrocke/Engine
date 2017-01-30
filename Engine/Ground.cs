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
    public class Ground
    {
        public Rectangle Rect;
        public Sprite sprite;

        public Ground(int X, int Y, int Width, int Height, Sprite Ground_sprite)
        { 
            Rect = new Rectangle(X, Y, Width, Height);
            sprite = Ground_sprite;
            
        }

        public void Draw()
        {
            for (int i = Rect.X; i < Rect.Width + Rect.X; i += sprite.width)
            {
                for (int y = Rect.Y; y < Rect.Height + Rect.Y; y += sprite.height)
                {
                    Game1.spriteBatch.Draw(sprite.texture, position: new Vector2(i, y));
                }
            }
        }

    }
}

