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
    public class Enemy
    {
        Sprite sprite;

        //-----Float-----//
        static float gravity = 1.03f;
        public static double x_speed = 0f;
        public static double y_speed = 0.1f;
        public static float x = 200;
        public static float y = 200;

        //-----Ints-----//
        public static int x_speed_max = 5;
        public static int y_speed_max = 10;
        public static int direction = 1;
        public static int deathTimer = 0;

        //----Boolean---//
        public static bool isAlive = true;
        public static bool damageGiven = false;

        //----Hitbox----//
        public static Rectangle hitbox;
        public static Rectangle outRect;

        public Enemy(int xpos, int ypos, Sprite spriteEnemy)
        {
            x = xpos;
            y = ypos;
            sprite = spriteEnemy;
            hitbox = new Rectangle((int)x - sprite.origin_x, (int)y - sprite.origin_y, sprite.width, sprite.height);
        }

        public void Update()
        {
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

            //Move
            x_speed = 3 * direction;

            if (Global.colliding(0, (int)y_speed, hitbox, out outRect))
            {
                y = outRect.Top - hitbox.Height / 2;
                y_speed = 0;
            }
            if (Global.colliding((int)x_speed, 0, hitbox, out outRect))
            {
                if (x > outRect.Right)
                {
                    x = outRect.Right + hitbox.Width / 2;
                    direction = 1;
                }
                else if (x < outRect.Left)
                {
                    x = outRect.Left - hitbox.Width / 2;
                    direction = -1;
                }
                x_speed = 0;
            }

            //Check for collision with player
            if (hitbox.Intersects(Player.hitbox))
            {
                if (hitbox.Center.Y > Player.hitbox.Bottom && Player.y_speed > 0)
                {
                    isAlive = false;
                }
                else if (hitbox.Center.Y < Player.hitbox.Bottom)
                {
                    if (!damageGiven)
                    {
                        Player.takeDamage(1);
                        damageGiven = true;
                    }
                }
            }
            else
            {
                damageGiven = false;
            }


            //Add speed to position
            y += (float)y_speed;
            x += (float)x_speed;

            //update timer and check for respawn
            if (!isAlive){
                deathTimer++;
            }
            if (deathTimer == 600)
            {
                Respawn();
            }

        }

        public void Respawn()
        {
            isAlive = true;
            x = 400;
            y = 200;
            direction = 1;
            deathTimer = 0;
        }

        public void Draw()
        {
            if (isAlive)
            {
                Game1.spriteBatch.Draw(sprite.texture, position: new Vector2(x, y), origin: new Vector2(sprite.origin_x, sprite.origin_y));
            }
        }
    }
}
