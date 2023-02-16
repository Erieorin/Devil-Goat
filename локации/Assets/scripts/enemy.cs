using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack
}
public class enemy : MonoBehaviour
{
    public EnemyState currentstate;
    public int health;
    public string enemyname;
    public int baseAttack;
    public float movespeed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
