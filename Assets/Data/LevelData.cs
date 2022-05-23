using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Level Datas/New Level", order = 1)]
    public class LevelData : ScriptableObject
    {
        public List<PlatformData> PlatformDatas;
        public List<BallPackData> BallPackDatas;
    }
}
