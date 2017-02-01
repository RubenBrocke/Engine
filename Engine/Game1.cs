using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        //-----Ints------//

        //-----Sprites-----//
        public static Sprite ground = new Sprite(32, 32, 1, 0, 0, "Ground");
        public static Sprite goomba = new Sprite(32, 32, 1, 16, 16, "Goomba");
        public static Sprite coin = new Sprite(32, 32, 1, 16, 16, "Coin");
        public static Ground floor = new Ground(0, 480 - ground.height, 1200, ground.height, ground);
        public static Ground hill = new Ground(300, 480 - 96, 256, 98, ground);
        public static Ground wall = new Ground(1200 - 32, 0, 32, 480, ground);
        public static Level level1 = new Level(floor, hill, wall);
        public static Enemy Goomba = new Enemy(400, 200, goomba);
        public static Camera cameraMain;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            cameraMain = new Camera(GraphicsDevice.Viewport);
            level1.Add(new Coin(500, 300, coin));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Player.sprite.texture = Content.Load<Texture2D>("Panda");
            ground.texture = Content.Load<Texture2D>("Ground");
            goomba.texture = Content.Load<Texture2D>("Goomba");
            coin.texture = Content.Load<Texture2D>("Coin");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            // TODO: Add your update logic here
            Player.Update();
            Goomba.Update();
            level1.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (Player.health <= 2)
            {
                GraphicsDevice.Clear(Color.OrangeRed);
            }
            else
            {
                GraphicsDevice.Clear(Color.Azure);
            }

            // TODO: Add your drawing code here
            spriteBatch.Begin(transformMatrix: cameraMain.getMatrix());

            spriteBatch.Draw(Player.sprite.texture, new Vector2(Player.x, Player.y), origin: new Vector2(Player.sprite.origin_x, Player.sprite.origin_y));
            level1.Draw();
            Goomba.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
