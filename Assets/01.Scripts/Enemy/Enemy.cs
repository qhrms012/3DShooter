using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public float speed; // ���� �ӵ�
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
        stateMachine.Update(dirVec); // �÷��̾� ������ ���¿� ����
    }
    public void ChasePlayer()
    {
            // ChaseState�� ��ȯ�Ͽ� �÷��̾� ���� ����
            stateMachine.SetState(new ChaseState(stateMachine, animator, speed, rigid));
    }

    private void OnEnable()
    {
        ChasePlayer();
    }
}
