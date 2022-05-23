using System;
using UnityEngine;

namespace Assets.Data
{
    [Serializable]
    public class PlatformData 
    {
        public Vector3 Position;
        public PlatformTypeEnum PlatformType;
        public int CheckPointCount;

    }
}
