using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WareDotWolves
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        Texture2D pixelTex, factionsTex, tilesTex;
        GraphicsDeviceManager graphics;
        Camera camera;
        SpriteBatch spriteBatch;
        //Player player1, player2;
        Level lvl0;

        Color purple;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 720;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            //Window.IsBorderless = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            purple = new Color(114, 103, 134);

            camera = new Camera(GraphicsDevice.Viewport);

            pixelTex = new Texture2D(graphics.GraphicsDevice, 1, 1);
            pixelTex.SetData(new Color[] { Color.White });
            factionsTex = Content.Load<Texture2D>("gfx/factions");
            tilesTex = Content.Load<Texture2D>("gfx/tiles");

            Factory.Load(factionsTex, tilesTex, 32, graphics.GraphicsDevice.Viewport.Height);

            lvl0 = new Level(0, 32);
            lvl0.Load();

            //player1 = new Rosco(PlayerIndex.One, factionsTex, new Vector2(200, 200), graphics.GraphicsDevice.Viewport.Height);
            //player2 = new Kilroy(PlayerIndex.Two, factionsTex, new Vector2(320, 120), graphics.GraphicsDevice.Viewport.Height);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            camera.Update();
            lvl0.Update(gameTime);
            //player1.Update(gameTime);
            //player2.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(purple);

            // TODO: Add your drawing code here
            //spriteBatch.Begin();
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.Transform);
            lvl0.Draw(spriteBatch);
            //player1.Draw(spriteBatch, pixelTex);
            //player2.Draw(spriteBatch, pixelTex);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
