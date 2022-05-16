using System;
using System.Collections.Generic;
using System.Text;

namespace My
{
    class BoneMatrix
    {
        public Action UpdateEvent;

        public List<BoneMatrix> childs = new List<BoneMatrix>();

        Matrix4x4 localMatrix;
        Matrix4x4 matrix;
        bool dirtyFlag;
        public Matrix4x4 LocalMatrix
        {
            get { return localMatrix; }
            set {
                dirtyFlag = true;
                localMatrix = value;                
            }
        }
        public Matrix4x4 Matrix
        {
            get { return matrix; }
        }

        public BoneMatrix(int dimension)
        {
            this.LocalMatrix = Matrix4x4.Identity;
            this.matrix = LocalMatrix;
        }
        public BoneMatrix(BoneMatrix parent)
        {
            this.LocalMatrix = Matrix4x4.Identity;
            this.matrix = LocalMatrix;
            parent.childs.Add(this);
        }
        public BoneMatrix(BoneMatrix parent, Matrix4x4 matrix)
        {
            this.LocalMatrix = matrix;
            this.matrix = LocalMatrix;
            parent.childs.Add(this);
        }

        public void Update(BoneMatrix parent, bool dirty=false)
        {
            dirtyFlag |= dirty;

            if (dirtyFlag)
            {
                matrix = parent.matrix * localMatrix;
                dirtyFlag = false;

                UpdateEvent?.Invoke();
            }

            // 子の更新
            foreach (var i in childs)
                i.Update(this, dirty);
        }
    }
}
