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
        public static Ground floor = new Ground(0, 480 - ground.height, 800, ground.height, ground);
        public static Ground hill = new Ground(300, 480 - 96, 256, 98, ground);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Player.sprite.texture = Content.Load<Texture2D>("Panda");
            ground.texture = Content.Load<Texture2D>("Ground");
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
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Azure);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(Player.sprite.texture, new Vector2(Player.x, Player.y), origin: new Vector2(Player.sprite.origin_x, Player.sprite.origin_y));

            floor.Draw();
            hill.Draw();

            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
