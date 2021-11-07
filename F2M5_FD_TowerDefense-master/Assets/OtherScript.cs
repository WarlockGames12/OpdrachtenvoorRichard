using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EnemyInRangeChecker))]
public class OtherScript : MonoBehaviour
{
    [SerializeField] private float _damageAmount = 8;
    [SerializeField] private float _shootCooldown = 0.8f;
    [SerializeField] private Transform _turret;
    private EnemyInRangeChecker enemyInRangeChecker;
    private float _nextShootTime = 0;

    private void Start()
    {
        enemyInRangeChecker = GetComponent<EnemyInRangeChecker>();
    }

    private void Update()
    {
        Enemy enemy = enemyInRangeChecker.GetFirstEnemyInRange();
        if(enemy != null)
        {
            _turret.LookAt(enemy.transform);
            if (CanShoot())
            {
                enemy.GetHealthOponent().TakeDamage(_damageAmount);
                _nextShootTime = Time.time + _shootCooldown;
            }
        }
    }

    private bool CanShoot()
    {
        return Time.time >= _nextShootTime;
    }
}
