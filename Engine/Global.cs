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
    public static class Global
    {
        public static Level currentLevel = Game1.level1;

        public static bool colliding(Rectangle hitbox)
        {
            bool succes = true;

            foreach (var ground in currentLevel.grounds)
            {
                if (ground.Rect.Intersects(hitbox))
                {
                    succes = true;
                }
                else
                {
                    succes = false;
                }
            }

            return succes;
        }
        public static bool colliding(int offsetx, int offsety, Rectangle hitbox, out Rectangle Rect)
        {
            bool succes = true;
            Rect = Rectangle.Empty;
            foreach (var ground in currentLevel.grounds)
            {
                Rectangle testRect = new Rectangle(ground.Rect.X + -offsetx, ground.Rect.Y + -offsety, ground.Rect.Width, ground.Rect.Height);

                if (testRect.Intersects(hitbox))
                {
                    succes = true;
                    Rect = ground.Rect;
                    break;
                }
                else
                {
                    succes = false;
                }
            }

            return succes;
        }
    }
}
