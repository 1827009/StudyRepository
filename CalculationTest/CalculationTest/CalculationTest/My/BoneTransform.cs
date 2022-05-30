using System;
using System.Collections.Generic;
using System.Text;

namespace My
{
    /// <summary>
    /// BoonMatrixのQuaternion実装版
    /// </summary>
    class BoneTransform
    {
        public Action UpdateEvent;

        public List<BoneTransform> childs = new List<BoneTransform>();

        bool dirtyFlag;
        Vector3 localPosition;
        public Vector3 LocalPosition
        {
            get { return localPosition; }
            set {
                dirtyFlag = true;
                localPosition = value;                
            }
        }
        Quaternion localQuaternion = Quaternion.Identity;
        public Quaternion LocalQuaternion
        {
            get { return localQuaternion; }
            set
            {
                dirtyFlag = true;
                localQuaternion = value;
            }
        }
        public Matrix4x4 LocalTransform
        {
            get
            {
                Matrix4x4 result = localQuaternion.ToMatrix;
                result.Translation = localPosition;
                return result;
            }
        }
        Matrix4x4 transform;
        public Matrix4x4 Transform
        {
            get {               
                return transform; 
            }
        }
        public Vector3 Position
        {
            get
            {
                return new Vector3(transform.M41, transform.M42, transform.M43);
            }
            set
            {
                transform.M41 = value.x;
                transform.M42 = value.y;
                transform.M43 = value.z;
            }
        }

        public BoneTransform()
        {
            this.transform = LocalTransform;
        }
        public BoneTransform(BoneTransform parent)
        {
            this.transform = LocalTransform;
            parent.childs.Add(this);
        }
        public BoneTransform(BoneTransform parent, Matrix4x4 matrix)
        {
            this.transform = LocalTransform;
            parent.childs.Add(this);
        }

        public void Update(BoneTransform parent, bool dirty=false)
        {
            dirty |= dirtyFlag;

            if (dirty)
            {
                transform = LocalTransform * parent.transform;
                UpdateEvent?.Invoke();
                dirtyFlag = false;
            }

            // 子の更新
            foreach (var i in childs)
                i.Update(this, dirty);
        }
    }
}
