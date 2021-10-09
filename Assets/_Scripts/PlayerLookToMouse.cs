using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookToMouse : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private float _dashRange;

    private Camera _mainCam;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray mousePos = _mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mousePos, out hit, 100f))
        {
            Vector3 playerLookAtPos = new Vector3(hit.point.x, _player.position.y, hit.point.z);
            _player.LookAt(playerLookAtPos);
        }
    }

    private void Dash()
    {
        Ray castPoint = _mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            if (Vector3.Distance(transform.position, hit.point) < _dashRange)
            {
                transform.position = hit.point;
                Debug.Log("CloseDash");
            }
            else
            {
                transform.position -= (transform.position - hit.point).normalized * _dashRange;
                Debug.Log("LongDash");
            }
        }
        Debug.Log((transform.position - hit.point).normalized);
    }
}
