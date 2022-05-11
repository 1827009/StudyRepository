using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace datadrivenTest.GameOctopus
{
    struct Transform
    {
        Matrix matrix;
        public Vector3 Position
        {
            get { return matrix.Translation; }
            set { matrix.Translation = value; }
        }
    }
}
