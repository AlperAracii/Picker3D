using Assets.Data;
using Game.GameEvents;
using UnityEngine;

namespace Assets.Scripts.Game.PlatformScripts
{
    public class FinalPlatform : PlatformBaseScript
    {
        public override PlatformTypeEnum PlatformType => PlatformTypeEnum.FINAL;

        private void OnTriggerEnter(Collider other)
        {
            var picker = other.GetComponent<PickerScript>();
            if (picker != null)
            {
                Debug.Log("Finished!");

                Timer.Instance.TimerWait(2f, () => GameEventBus.InvokeEvent(GameEventType.FINISHED));
            }
        }

    }
}
