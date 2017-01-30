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
    public class Sprite
    {
        public Texture2D texture;
        public int width;
        public int height;
        public int scale;
        public int origin_x;
        public int origin_y;
        public string name;

        public Sprite(int W, int H, int S, int x_origin, int y_origin, string sprite_name)
        {
            width = W;
            height = H;
            scale = S;
            origin_x = x_origin;
            origin_y = y_origin;
            name = sprite_name;
        }

        
    }
}
