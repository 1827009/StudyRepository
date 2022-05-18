using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using datadrivenTest.GameOctopus.ObjectClasss;

namespace datadrivenTest.GameOctopus.DrawClasss.sampleDraws
{
    class DrawTentacle
    {
        Tentacle tentacle;

        List<DrawBox> boxes;

        public Matrix matrix = Matrix.Identity;

        public DrawTentacle(Matrix matrix, Tentacle tentacle)
        {
            this.tentacle = tentacle;
            this.matrix = matrix;

            boxes = new List<DrawBox>(tentacle.maxStep);
            for (int i = 0; i < tentacle.maxStep; i++)
            {
                Matrix pos = Matrix.Identity;
                pos.Translation = new Vector3(0, (-DrawStage.BLOCK_SPACE * (5 / (float)tentacle.maxStep)) * i, 0);
                boxes.Add(new DrawBox(this.matrix, pos, Color.Black, new Vector2(1, (5 / (float)tentacle.maxStep))));
            }
        }
        public void Update(Matrix parent)
        {
            for (int i = 0; i < boxes.Count; i++)
            {

                boxes[i].Update(parent * matrix);
            }
        }
        public void Draw(Tentacle tentacle, GraphicsDevice graphics)
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                if (i < tentacle.Step)
                    boxes[i].ChengeColor(Color.Black);
                else
                    boxes[i].ChengeColor(new Color(100, 100, 100));
                boxes[i].Draw(graphics);
            }
        }
    }
}
