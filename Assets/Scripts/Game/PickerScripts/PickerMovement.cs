using System;
using UnityEngine;

public class PickerMovement : MonoBehaviour
{
    private bool _active;
    private Camera _pickerCamera;

    private float _forwardSpeed;
    private float _xSpeed;

    private Vector3 _mousePos;
    private float _distanceToScreen;


    public void Initialize(Camera pickerCamera)
    {
        _pickerCamera = pickerCamera;
        _forwardSpeed = 5f;
        _xSpeed = 10f;
        Activate();
    }

    public void Activate()
    {
        _active = true;
    }

    public void Deactivate()
    {
        _active = false;
    }
    // Start is called before the first frame update
    //void Start()
    //{
    //    _pickerCamera = Camera.main;
    //    _cameraOffset = _pickerCamera.transform.position - transform.position;

    //}

    private void FixedUpdate()
    {
        if (!_active)
            return;

        if (Input.GetMouseButton(0))
        {
            var position = Input.mousePosition;

            _distanceToScreen = _pickerCamera.WorldToScreenPoint(gameObject.transform.position).z;
            _mousePos = _pickerCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, _distanceToScreen));
            float direction = _xSpeed;
            direction = _mousePos.x > transform.position.x ? direction : -direction;

            if (Math.Abs(_mousePos.x - transform.position.x) > 0.5f)
                transform.Translate(Time.deltaTime * direction, 0, 0);
        }
        transform.Translate(0, 0, Time.deltaTime * _forwardSpeed);
    }


    //private void LateUpdate()
    //{
    //    if (_pickerCamera == null)
    //        return;

    //    _pickerCamera.transform.position = new Vector3(_pickerCamera.transform.position.x, _pickerCamera.transform.position.y,
    //        transform.position.z + _cameraOffset.z);
    //}
}
