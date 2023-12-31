using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    [SerializeField] float playerSpeed = 1f;
    [SerializeField] float padding = 5f;

    Shooter shooter;
    private void Awake()
    {
        shooter = FindObjectOfType<Shooter>();
    }

    private void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move()
    {
        Vector2 delta = rawInput * Time.deltaTime * playerSpeed;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + padding, maxBounds.x - padding);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + padding, maxBounds.y - padding);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
