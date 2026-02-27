using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectUniteScript : MonoBehaviour {
    private Camera mainCamera;

    List<GameObject> selectedUnite = new List<GameObject>();
    public float moveSpeed = 5f;
    void Awake() {
        mainCamera = Camera.main;
    }

    void Update() {
        // left click logic
        if (Mouse.current.leftButton.wasPressedThisFrame) {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Unite")) {
                UnityEngine.Debug.Log("Unité cliquée : " + hit.collider.gameObject.name);

                selectedUnite.Add(hit.collider.gameObject);
            }
        }
        foreach (GameObject unite in selectedUnite) {
            unite.GetComponent<SpriteRenderer>().color = Color.blue;
        }

        // right click logic
        if (Mouse.current.rightButton.wasPressedThisFrame && selectedUnite.Count > 0) {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);


            foreach (GameObject unite in selectedUnite) {
                StartCoroutine(MoveUnit(unite, worldPosition));
            }
        }
    }

    private IEnumerator MoveUnit(GameObject unite, Vector2 targetPosition) {
        Vector3 target = new Vector3(targetPosition.x, targetPosition.y, unite.transform.position.z); // this is a 3d vector for keep the z position of the unite
        while (Vector3.Distance(unite.transform.position, target) > 0.1f) {
            unite.transform.position = Vector3.MoveTowards(
                unite.transform.position,
                target,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }
    }
}
