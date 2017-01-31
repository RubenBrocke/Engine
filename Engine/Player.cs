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
        public static Rectangle outRect;

        //---Current Level---//
        static Level currentLevel = Game1.level1;

        public static void Update()
        {
            //Debug
            Console.WriteLine(y_speed);

            //Update Hitbox
            hitbox.X = (int)x - sprite.origin_x;
            hitbox.Y = (int)y - sprite.origin_y;

            //Add gravity
            if (!colliding(0, 1, out outRect))
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
            else if (colliding(0, 1, out outRect))
            {
                x_speed = 0;
            }
            if (state.IsKeyDown(Keys.Space))
            {
                jump();
            }

            //Do collision (to be moved to parent class)
            if (colliding((int)x_speed, 0, out outRect))
            {
                if (x > outRect.Right)
                {
                    x = outRect.Right + hitbox.Width / 2;
                }
                else if (x < outRect.Left)
                {
                    x = outRect.Left - hitbox.Width / 2;
                }
                x_speed = 0;
            }
            if (colliding(0, (int)y_speed, out outRect)) {
                y = outRect.Top - hitbox.Height / 2;
                y_speed = 0;
            }



            //Add speed to position
            y += (float)y_speed;
            x += (float)x_speed;
        }

        public static bool colliding()
        {
            bool succes = true;

            foreach (var ground in currentLevel.grounds)
            {
                if (ground.Rect.Intersects(hitbox))
                {
                    succes =  true;
                }
                else
                {
                    succes =  false;
                }
            }

            return succes;
        }

        public static bool colliding(int offsetx, int offsety, out Rectangle Rect)
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

        public static void jump()
        {
            if (colliding(0, 1, out outRect))
            {
                y_speed = -15;
            }
        }
    }
}
