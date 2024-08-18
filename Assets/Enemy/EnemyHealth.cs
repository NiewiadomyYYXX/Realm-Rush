using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    [SerializeField] int difficultyRamp = 1;

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
            maxHP += difficultyRamp;
        }
    }
}
