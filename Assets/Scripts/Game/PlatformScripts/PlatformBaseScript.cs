using Assets.Data;
using UnityEngine;

namespace Assets.Scripts.Game.PlatformScripts
{
    public abstract class PlatformBaseScript : MonoBehaviour
    {
        public abstract PlatformTypeEnum PlatformType { get; }
        public bool IsActive;
        public virtual void Initialize()
        {
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            IsActive = false;
            gameObject.SetActive(false);
        }
    }
}
