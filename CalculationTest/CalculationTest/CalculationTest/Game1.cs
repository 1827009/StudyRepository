using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyXNA;

namespace CalculationTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        BasicEffect effect;

        My.BoneMatrix root;
        DrawBox[] box;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            root = new My.BoneMatrix(3);

            box = new DrawBox[5];
            box[0] = new DrawBox(new My.BoneMatrix(root), Color.Red, Vector3.One);
            for (int i = 1; i < 5; i++)
            {
                Matrix matrix = Matrix.Identity;
                matrix.Translation = new Vector3(0, 0.21f, 0);
                box[i] = new DrawBox(new My.BoneMatrix(box[i-1].matrix, ChangeXNA.MatrixXNAToMy(matrix)), Color.Red, Vector3.One);
            }

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
            root.Update(root);


            for (int i = 1; i < 5; i++)
            {
                box[i].matrix.LocalMatrix *= My.Matrix4x4.CreateRotation(MathHelper.ToRadians(5));
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                foreach (var item in box)
                {
                    item.Draw(_graphics.GraphicsDevice);
                }
            }

            base.Draw(gameTime);
        }
    }
}
