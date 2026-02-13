using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectUniteScript : MonoBehaviour
{
    private Camera mainCamera;

    List<gameObject> selectedUnite;

    void Awake() {
        mainCamera = Camera.main;
    }

    void Update() {
        if (Mouse.current.leftButton.wasPressedThisFrame) {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Unite")) {
                UnityEngine.Debug.Log("Unité cliquée : " + hit.collider.gameObject.name);

                selectedUnite.Add(gameObject);
            }
        }
    }
}
