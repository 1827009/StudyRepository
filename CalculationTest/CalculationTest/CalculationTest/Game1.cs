using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyXNA;
using CalculationTest.SampleGames;

namespace CalculationTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static readonly int WINDOW_SIZE_X=900;
        public static readonly int WINDOW_SIZE_Y=900;
        BasicEffect effect;

        My.BoneTransform rootWorld = new My.BoneTransform();
        Camera_Transform camera;

        SampleGame game;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = WINDOW_SIZE_X;
            _graphics.PreferredBackBufferHeight = WINDOW_SIZE_Y;

            camera = new Camera_Transform(rootWorld);
            camera.Position = new My.Vector3(0, 1, 2);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            InputManager.Initialize();

            game = new SampleGame6CameraView(camera, rootWorld);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            effect = new BasicEffect(GraphicsDevice);
            effect.VertexColorEnabled = true;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            InputManager.Update();
            TimeManager.Update(gameTime);
            rootWorld.Update(rootWorld, false);

            //if (InputManager.IsKeyDown(Keys.Space))
                game.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            effect.View = camera.View;
            effect.Projection = camera.Projection;
            effect.World = MyXNA.ChangeXNA.Change(rootWorld.Transform);
            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                game.Draw(GraphicsDevice, gameTime);
            }

            _spriteBatch.Begin();

            game.Draw(_spriteBatch, gameTime);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
