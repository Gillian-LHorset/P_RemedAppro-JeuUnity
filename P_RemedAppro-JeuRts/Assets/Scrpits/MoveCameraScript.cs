using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        float _cameraSpeed = 0.1f;
        float _horizontal = 0.0f;
        int _moveCameraDistance = 50;

        Vector3 mousePos = Mouse.current.position.ReadValue();

        if (Keyboard.current.leftArrowKey.isPressed 
            || Keyboard.current.aKey.isPressed
            || mousePos.x < _moveCameraDistance) {
            _horizontal -= _cameraSpeed;
        } else if (Keyboard.current.rightArrowKey.isPressed 
            || Keyboard.current.dKey.isPressed
            || mousePos.x > Screen.width - _moveCameraDistance) {
            _horizontal += _cameraSpeed;
        }

        float vertical = 0.0f;
        if (Keyboard.current.upArrowKey.isPressed 
            || Keyboard.current.wKey.isPressed
            || mousePos.y > Screen.height - _moveCameraDistance) {
            vertical += _cameraSpeed;
        } else if (Keyboard.current.downArrowKey.isPressed 
            || Keyboard.current.sKey.isPressed
            || mousePos.y < _moveCameraDistance) {
            vertical -= _cameraSpeed;
        }



        Vector2 position = transform.position;
        position.x = position.x + 0.1f * _horizontal;
        position.y = position.y + 0.1f * vertical;
        transform.position = position;
    }
}
