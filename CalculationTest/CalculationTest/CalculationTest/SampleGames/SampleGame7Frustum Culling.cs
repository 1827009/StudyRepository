using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using MyXNA;

namespace CalculationTest.SampleGames
{
    class SampleGame7Frustum_Culling : SampleGame
    {
        My.BoneTransform root;
        Camera_Transform camera;



        SampleGame7Frustum_Culling(Camera_Transform camera, My.BoneTransform root)
        {
            this.root = root;
            this.camera = camera;
        }

        public override void Update(GameTime time)
        {
            throw new NotImplementedException();
        }
    }
}
