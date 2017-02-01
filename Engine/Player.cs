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
        static float gravity = 0.8f;
        public static double x_speed = 0f;
        public static double y_speed = 0.1f;

        //-----Ints-----//
        public static float x = 200;
        public static float y = 200;
        public static int x_speed_max = 5;
        public static int y_speed_max = 10;
        public static int health = 3;

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
            if (!Global.colliding(0, 1, hitbox, out outRect))
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
            else if (Global.colliding(0, 1, hitbox, out outRect))
            {
                x_speed = 0;
            }
            if (state.IsKeyDown(Keys.Space))
            {
                jump();
            }

            Game1.cameraMain.lookAt((int)x, (int)y);

            //Do collision (to be moved to parent class)
            if (Global.colliding(0, (int)y_speed, hitbox, out outRect)) {
                y = outRect.Top - hitbox.Height / 2;
                y_speed = 0;
            }
            if (Global.colliding((int)x_speed, 0, hitbox, out outRect))
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

            //Add speed to position
            y += (float)y_speed;
            x += (float)x_speed;
        }

        public static void takeDamage(int damage)
        {
            health -= damage;
        }

        public static void jump()
        {
            if (Global.colliding(0, 1, hitbox, out outRect))
            {
                y_speed = -15;
            }
        }
    }
}
