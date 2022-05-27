using System;
using System.Collections.Generic;
using System.Text;

namespace My
{
    class BoneMatrix
    {
        public Action UpdateEvent;

        public List<BoneMatrix> childs = new List<BoneMatrix>();

        Matrix4x4 localTransform;
        Matrix4x4 transform;
        bool dirtyFlag;
        public Matrix4x4 LocalTransform
        {
            get { return localTransform; }
            set {
                dirtyFlag = true;
                localTransform = value;                
            }
        }
        public Vector3 Position
        {
            get { return LocalTransform.Translation; }
            set {
                Matrix4x4 matrix = LocalTransform;
                matrix.Translation = value;
                LocalTransform = matrix;
            }
        }
        public Matrix4x4 Transform
        {
            get { return transform; }
        }

        public BoneMatrix()
        {
            this.LocalTransform = Matrix4x4.Identity;
            this.transform = LocalTransform;
        }
        public BoneMatrix(BoneMatrix parent)
        {
            this.LocalTransform = Matrix4x4.Identity;
            this.transform = LocalTransform;
            parent.childs.Add(this);
        }
        public BoneMatrix(BoneMatrix parent, Matrix4x4 matrix)
        {
            this.LocalTransform = matrix;
            this.transform = LocalTransform;
            parent.childs.Add(this);
        }

        public void Update(BoneMatrix parent, bool dirty=false)
        {
            dirty |= dirtyFlag;

            if (dirty)
            {
                transform = localTransform * parent.transform;
                UpdateEvent?.Invoke();
                dirtyFlag = false;
            }

            // 子の更新
            foreach (var i in childs)
                i.Update(this, dirty);
        }
    }
}
