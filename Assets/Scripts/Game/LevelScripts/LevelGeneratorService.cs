using Assets.Scripts.Game.PlatformScripts;
using Game.GameEvents;
using UnityEngine;

namespace Assets.Scripts.Game.LevelScripts
{
    public class LevelGeneratorService : MonoBehaviour
    {
        private int _levelIndex;
        public LevelManager _levelManager;
        public PickerBaseScript _pickerBase;
        private Vector3 _pickerStartPosition;


        private void Start()
        {
            _pickerStartPosition = new Vector3(0, 0.6f, 2.5f);
            _levelIndex = 1;

            GameEventBus.SubscribeEvent(GameEventType.FINISHED, () =>
            {
                Timer.Instance.TimerWait(2f, () =>
                {
                    _levelManager.DeactivateWholeGame();
                    _levelIndex++;
                    GenerateLevel();
                });
            });

            GameEventBus.SubscribeEvent(GameEventType.FAIL, () =>
            {
                _levelManager.DeactivateWholeGame();
                GenerateLevel();
            });
        }

        public void GenerateLevel()
        {
            var levelData = AssetManager.Instance.LoadLevel(_levelIndex);
            if (levelData == null)
            {
                _levelIndex = 1;
                levelData = AssetManager.Instance.LoadLevel(_levelIndex);
            }

            var platformList = levelData.PlatformDatas;
            foreach (var platformData in platformList)
            {
                var platform = _levelManager.GetPlatformForActivate(platformData.PlatformType);
                platform.transform.position = platformData.Position;

                if (platform.PlatformType == Data.PlatformTypeEnum.CHECKPOINT)
                    platform.GetComponent<CheckPointPlatform>()?.SetTarget(platformData.CheckPointCount);
            }

            var ballPacks = levelData.BallPackDatas;
            foreach (var ballPack in ballPacks)
            {
                var ball = _levelManager.GetBallPackForActivate(ballPack.BallPackType);
                ball.transform.position = ballPack.Position;
            }

            _pickerBase.transform.position = _pickerStartPosition;


        }
    }
}
