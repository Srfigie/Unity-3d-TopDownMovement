using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterMover : MonoBehaviour
{
    private InputHandler _input;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private bool rotateTowardsMouse;

    [SerializeField]
    private Camera camera;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }


    // Update is called once per frame
    void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        var movementVector = MoveTowardTarget(targetVector);
        if (!rotateTowardsMouse)
            RotateTowardMovementVector(movementVector);
        else
            RotateTowardMouseVector();
    }

    private void RotateTowardMouseVector()
    {
        Ray ray = camera.ScreenPointToRay(_input.MousePosition);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if(movementVector.magnitude == 0) { return; }

        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }
}
