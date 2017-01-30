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
        public static float x;
        public static float y;
        public static int x_speed_max = 5;
        public static int y_speed_max = 10;

        public static void Update()
        {
            //Debug
            Console.WriteLine(y_speed);

            //Add gravity
            if (!colliding(x, y + sprite.height / 2 + 1))
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
            else if (colliding(x, y + sprite.height / 2 + 1))
            {
                x_speed = 0;
            }
            if (state.IsKeyDown(Keys.Space))
            {
                jump();
            }

            //Do collision (to be moved to parent class)
            if (colliding(x, y + sprite.height / 2 + y_speed))
            {
                while (!colliding(x, y + sprite.height / 2 + Math.Sign(y_speed)))
                {
                    y += Math.Sign(y_speed);
                }
                y_speed = 0;
                Console.WriteLine("Colliding");
            }

            if (colliding(x + Math.Sign(x_speed) * (sprite.width / 2) + x_speed, y + sprite.height / 2))
            {
                while (!colliding(x + Math.Sign(x_speed) * (sprite.width / 2) + Math.Sign(x_speed), y + sprite.height / 2))
                {
                    x += Math.Sign(x_speed);
                }
                x_speed = 0;
                Console.WriteLine("Colliding");
            }

            //Add speed to position
            y += (float)y_speed;
            x += (float)x_speed;
        }

        public static bool colliding(double X, double Y)
        {

            if (Game1.floor.Rect.Contains((float)X, (float)Y) || Game1.hill.Rect.Contains((float)X, (float)Y))
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
            if (colliding(x, y + sprite.height / 2 + 1))
            {
                y_speed = -15;
            }
        }
    }
}
