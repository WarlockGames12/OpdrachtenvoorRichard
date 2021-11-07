using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyInRangeChecker))]
public class TowerLookAtEnemyatCertainRange : MonoBehaviour
{
    [SerializeField] private float _shootCooldown = 0.8f;
    [SerializeField] private Transform _turret;
    private EnemyInRangeChecker enemyInRangeChecker;
    private float _nextShootTime = 0;
    public Enemy[] _hostilesInRange;

    private void Start()
    {
        enemyInRangeChecker = GetComponent<EnemyInRangeChecker>();
    }

    private void Update()
    {
        _hostilesInRange = enemyInRangeChecker.GetAllEnemiesInRange();
        if (_hostilesInRange != null)
        {
            Debug.Log("Found Enemy");
            foreach (var enemy in _hostilesInRange)
            {
                enemy.gameObject.GetComponent<PathFollower>()._speed = .5f;
            }
            _nextShootTime = Time.time + _shootCooldown;
        }
    }



    private bool CanShoot()
    {
        return Time.time >= _nextShootTime;
    }
}
