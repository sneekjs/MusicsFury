using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _baseMoveSpeed;

    [SerializeField]
    private float _runningSpeed;

    private bool _isRunning = false;

    private float _gravity = 8f;

    private Vector3 _moveDirection = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //_isRunning = true;
        }

        float currentPlayerSpeed;
        if (_isRunning)
        {
            currentPlayerSpeed = _runningSpeed;
        }
        else
        {
            currentPlayerSpeed = _baseMoveSpeed;
        }

        CharacterController playerController = GetComponent<CharacterController>();

        if (playerController.isGrounded)
        {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection *= currentPlayerSpeed;
        }

        if (_moveDirection == Vector3.zero)
        {
            _isRunning = false;
        }

        _moveDirection.y -= _gravity * Time.deltaTime;
        playerController.Move(_moveDirection * Time.deltaTime);
    }
}
