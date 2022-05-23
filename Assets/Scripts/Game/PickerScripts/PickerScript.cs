using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerScript : MonoBehaviour
{
    public PickerManager _pickerManager;
    public PickerMovement _pickerMovement;
    public CollectableBaseScript _collactableBaseScript;

    public void Initialize(PickerManager pickerPhysicsManager, PickerMovement pickerMovement)
    {
        _pickerManager = pickerPhysicsManager;
        _pickerMovement = pickerMovement;
    }

    public void PushCollectables()
    {
        _pickerMovement.Deactivate();
        foreach (var collectable in _pickerManager.GetCollectables())
        {
            collectable.Push();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var collectable = _collactableBaseScript;
        if (collectable != null)
        {
            _pickerManager.AddCollectable(collectable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var collectable = _collactableBaseScript;
        if (collectable != null)
        {
            _pickerManager.RemoveCollectable(collectable);
        }
    }
}
