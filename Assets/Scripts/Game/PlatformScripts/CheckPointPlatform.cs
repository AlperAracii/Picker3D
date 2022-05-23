using Assets.Data;
using DG.Tweening;
using Game.GameEvents;
using UnityEngine;

namespace Assets.Scripts.Game.PlatformScripts
{
    public class CheckPointPlatform : PlatformBaseScript
    {
        public override PlatformTypeEnum PlatformType => PlatformTypeEnum.CHECKPOINT;
        private int _target;

        private CheckPointCounterScript _checkPointCounter;
        private Transform _gate1;
        private Transform _gate2;

        private Vector3 _firstPos;

        public override void Initialize()
        {
            base.Initialize();
            _checkPointCounter = GetComponentInChildren<CheckPointCounterScript>(true);
            _gate1 = transform.Find("Gate1");
            _gate2 = transform.Find("Gate2");

            GameEventBus.SubscribeEvent(GameEventType.FINISHED, Reset);
            GameEventBus.SubscribeEvent(GameEventType.FAIL, Reset);

        }

        public void SetTarget(int aim)
        {
            _target = aim;
            _checkPointCounter.Initialize(_target);
        }

        private void CheckContinue(PickerBaseScript picker)
        {
            var counter = _checkPointCounter.GetCounter();
            if (counter >= _target)
            {
                _checkPointCounter.SuccesfulAction();
                _gate1.transform.DORotate(new Vector3(-60, 90, 90), 1f);
                _gate2.transform.DORotate(new Vector3(60, 90, 90), 1f).OnComplete(() =>
                {
                    GameEventBus.InvokeEvent(GameEventType.CHECKPOINT);
                });
                picker.OnPointGained.SafeInvoke(counter * 5);
            }
            else
            {
                Debug.Log("Fail");
                GameEventBus.InvokeEvent(GameEventType.FAIL);
            }
        }

        private void Reset()
        {
            _gate1.transform.eulerAngles = new Vector3(0, 90, 90);
            _gate2.transform.eulerAngles = new Vector3(0, 90, 90);
        }

        private void OnTriggerEnter(Collider other)
        {
            var picker = other.GetComponent<PickerScript>();
            if (picker != null)
            {
                picker.PushCollectables();
                Timer.Instance.TimerWait(2f, () => CheckContinue(picker.GetComponent<PickerBaseScript>()));
            }
        }

    }
}
