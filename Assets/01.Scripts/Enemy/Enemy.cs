using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public float speed; // 적의 속도
    public float health;
    public float maxHealth;
    public Rigidbody target;

    public RuntimeAnimatorController[] animCon;

    private Collider collider;
    private StateMachine stateMachine;
    private Animator animator;
    private Rigidbody rigid;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        stateMachine = new StateMachine();
    }
    private void Update()
    {
        Vector3 dirVec = target.position - rigid.position;
        stateMachine.Update(dirVec); // 플레이어 방향을 상태에 전달
    }
    public void ChasePlayer()
    {
            // ChaseState로 전환하여 플레이어 추적 시작
            stateMachine.SetState(new ChaseState(stateMachine, animator, speed, rigid));
    }

    private void OnEnable()
    {
        ChasePlayer();
    }
}
