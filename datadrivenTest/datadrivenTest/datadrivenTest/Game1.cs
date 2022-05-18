﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using datadrivenTest.GameOctopus;
using datadrivenTest.GameOctopus.DrawClasss;
using datadrivenTest.GameOctopus.ObjectClasss;

namespace datadrivenTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BasicEffect effect;

        public static readonly int WINDOW_SIZE_X = 628;
        public static readonly int WINDOW_SIZE_Y = 378;

        public static float gameTime;

        Stage stage;
        SoundManager soundManager;
        DrawGame drawTextures;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = WINDOW_SIZE_X;
            _graphics.PreferredBackBufferHeight = WINDOW_SIZE_Y;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            InputManager.Initialize();

            if (stage == null)
                stage = new Stage(Initialize);
            else
                stage = stage.NextStage();

            drawTextures.Initialize(stage);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            effect = new BasicEffect(GraphicsDevice);
            effect.VertexColorEnabled = true;
            soundManager = new SoundManager(Content);
            drawTextures = new DrawGame(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            Game1.gameTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here7
            InputManager.Update();

            stage.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            Game1.gameTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
            }

            _spriteBatch.Begin();

            drawTextures.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
