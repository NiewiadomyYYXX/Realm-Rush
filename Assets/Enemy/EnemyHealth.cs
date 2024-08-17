using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    int HP = 0;

    Enemy enemy;

    void OnEnable()
    {
        HP = maxHP;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        HP--;
        if (HP <= 0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
