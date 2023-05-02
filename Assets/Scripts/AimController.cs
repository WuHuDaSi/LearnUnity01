using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    private Camera _mainCamera;
    private void Awake()
    {
        _mainCamera = Camera.main;
        if (_mainCamera == null)
        {
            Debug.Log("Main camera not found.");
        }
    }

    private void Update()
    {
        Vector3 position = _mainCamera.WorldToScreenPoint(transform.position);
        Vector3 direction = Input.mousePosition - position;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(direction.x,direction.y);
        transform.rotation = Quaternion.AngleAxis(-angle,Vector3.forward);
    }
}
