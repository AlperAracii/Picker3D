using Game.GameEvents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerBaseScript : MonoBehaviour
{
    public Action<int> OnPointGained;

    private Camera _pickerCamera;
    private Vector3 _cameraOffset;

    private PickerManager _pickerManager;

    public PickerScript _pickerScript;
    public PickerMovement _pickerMovement;

    public void Initialize()
    {
        _pickerCamera = _pickerCamera == null ? Camera.main : _pickerCamera;
        _cameraOffset = _pickerCamera.transform.position - transform.position;

        _pickerManager = new PickerManager();

        _pickerMovement.Initialize(_pickerCamera);
        _pickerScript.Initialize(_pickerManager, _pickerMovement);

        GameEventBus.SubscribeEvent(GameEventType.CHECKPOINT, () => _pickerMovement.Activate());
        GameEventBus.SubscribeEvent(GameEventType.FAIL, () => _pickerMovement.Activate());
    }

    private void LateUpdate()
    {
        if (_pickerCamera == null)
            return;

        _pickerCamera.transform.position = new Vector3(_pickerCamera.transform.position.x, _pickerCamera.transform.position.y,
            transform.position.z + _cameraOffset.z);
    }
}
