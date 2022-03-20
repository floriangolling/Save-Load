using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    private Rigidbody2D _playerRigidbody;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
    }
}
