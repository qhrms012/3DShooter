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
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        stateMachine = new StateMachine();
        stateMachine.SetState(new IdleState(stateMachine, animator));
    }

    public void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        playerVector = new Vector3(inputVector.x, 0, inputVector.y);
    }
    private void Update()
    {
        stateMachine.Update(playerVector);
    }
    private void FixedUpdate()
    {
        Vector3 move = playerVector.normalized * playerSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
        
    }
}
