using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;


namespace Engine
{
    public static class Player
    {
        public static Sprite sprite = new Sprite(32, 32, 1, 16, 16, "Panda");

        //-----Float-----//
        static float gravity = 1.03f;
        public static double x_speed = 0f;
        public static double y_speed = 0.1f;

        //-----Ints-----//
        public static float x = 200;
        public static float y = 200;
        public static int x_speed_max = 5;
        public static int y_speed_max = 10;

        //----Hitbox----//
        public static Rectangle hitbox = new Rectangle((int)x - sprite.origin_x, (int)y - sprite.origin_y, sprite.width, sprite.height);

        public static void Update()
        {
            //Debug
            Console.WriteLine(y_speed);

            //Update Hitbox
            hitbox.X = (int)x - sprite.origin_x;
            hitbox.Y = (int)y - sprite.origin_y;

            //Add gravity
            if (!colliding(Game1.floor.Rect, 0, -1) && !colliding(Game1.hill.Rect, 0, -1))
            {
                y_speed += gravity;
                Console.WriteLine("Acc");
            }

            //Limit vertical speed
            if (y_speed > y_speed_max)
            {
                y_speed = y_speed_max;
            }

            //Add movement
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.D))
            {
                x_speed = 4;
            }
            else if (state.IsKeyDown(Keys.A))
            {
                x_speed = -4;
            }
            else if (colliding(Game1.floor.Rect, 0, -1) || colliding(Game1.hill.Rect, 0, -1))
            {
                x_speed = 0;
            }
            if (state.IsKeyDown(Keys.Space))
            {
                jump();
            }

            //Do collision (to be moved to parent class)
            if (colliding(Game1.floor.Rect)){
                y = Game1.floor.Rect.Top - hitbox.Height / 2;
                y_speed = 0;
            }
            else if (colliding(Game1.hill.Rect) && y < Game1.hill.Rect.Y)
            {
                y = Game1.hill.Rect.Top - hitbox.Height / 2;
                y_speed = 0;
            }



            //Add speed to position
            y += (float)y_speed;
            x += (float)x_speed;
        }

        public static bool colliding(Rectangle Rect)
        {
            if (Rect.Intersects(hitbox) || Rect.Intersects(hitbox))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool colliding(Rectangle Rect, int offsetx, int offsety)
        {
            Rectangle testRect = new Rectangle(Rect.X + offsetx, Rect.Y + offsety, Rect.Width, Rect.Height);

            if (testRect.Intersects(hitbox) || testRect.Intersects(hitbox))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void jump()
        {
            if (colliding(Game1.floor.Rect, 0, -1) || colliding(Game1.hill.Rect, 0, -1))
            {
                y_speed = -15;
            }
        }
    }
}
