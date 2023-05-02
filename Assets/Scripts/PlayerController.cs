using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 12.0f;

    private Vector2 _moveDirection;
    private Rigidbody2D _rigidBody2D;
    private Animator _animator;


    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        _moveDirection *= moveSpeed;

        _animator.SetFloat(AnimatorHash.MoveSpeed, Mathf.Abs(_moveDirection.x)+Mathf.Abs(_moveDirection.y));
    }

    private void FixedUpdate()
    {
        _rigidBody2D.AddForce(_moveDirection,ForceMode2D.Impulse);
    }
}
