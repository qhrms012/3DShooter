using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public float speed; // ���� �ӵ�
    public float health;
    public float maxHealth;

    public RuntimeAnimatorController[] animCon;

    
}
