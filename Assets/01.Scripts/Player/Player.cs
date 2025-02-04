using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private StateMachine stateMachine;
    private Rigidbody rb;

    public Vector3 playerVector;
    [SerializeField]
    private float playerSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        stateMachine = new StateMachine();
    }

    public void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        playerVector = new Vector3(inputVector.x, 0, inputVector.y);
    }

    private void FixedUpdate()
    {
        Vector3 move = playerVector.normalized * playerSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
        
    }
}
