using DG.Tweening;
using Game.GameEvents;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.View
{
    public class CheckPointProgression : MonoBehaviour
    {
        public PickerBaseScript _pickerBase;
        private List<CheckItem> _checkItems;
        public Point _pointClaim;
        private int _point;

        private void Start()
        {
            Initialize();

        }

        private void Initialize()
        {
            _checkItems = GetComponentsInChildren<CheckItem>().ToList();
            foreach (var checkItem in _checkItems)
            {
                checkItem.Initialize();
            }
            _pointClaim.Initialize();
            
            GameEventBus.SubscribeEvent(GameEventType.CHECKPOINT, ActiveCheckPointItem);
            GameEventBus.SubscribeEvent(GameEventType.FINISHED, () =>
            {
                DeActivateCheckPointItem();
                _pointClaim.ChangePoint(0);
                _point = 0;
            });
            GameEventBus.SubscribeEvent(GameEventType.FAIL, () =>
            {
                DeActivateCheckPointItem();
                _pointClaim.ChangePoint(0);
                _point = 0;
            });

            _pickerBase.OnPointGained += ChangePoint;
        }

        private void ChangePoint(int total)
        {
            var temp = _point;
            _point += total;
            DOVirtual.Float(temp, _point, 1f, value =>
            {
                _pointClaim.ChangePoint(Mathf.RoundToInt(value));
            });
        }
        
        private void DeActivateCheckPointItem()
        {
            foreach (var item in _checkItems)
            {
                item.Deactive();
            }
        }

        private void ActiveCheckPointItem()
        {
            foreach (var item in _checkItems)
            {
                if (!item.IsActive)
                {
                    item.Active();
                    break;
                }
            }
        }
    }
}
