using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float playerSpeed = 1f;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput;
        transform.position += delta * Time.deltaTime * playerSpeed;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
