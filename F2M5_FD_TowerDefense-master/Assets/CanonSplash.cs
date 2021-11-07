using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EnemyInRangeChecker))]
public class CanonSplash : MonoBehaviour
{
    [SerializeField] private float _shootCooldown = 0.8f;
    [SerializeField] private Transform _turret;
    private EnemyInRangeChecker enemyInRangeChecker;
    private float _nextShootTime = 0;
    private Enemy _target;

    public Enemy[] _hostilesInRange;

    private void Start()
    {
        enemyInRangeChecker = GetComponent<EnemyInRangeChecker>();
    }

    public void Update()
    {
        _hostilesInRange = enemyInRangeChecker.GetAllEnemiesInRange();

        if (_hostilesInRange != null)
        {
            Debug.Log("Found Enemy");
            //Enemy enemy1 = GetComponent<Renderer>().material.color = Color.red;
            foreach (var enemy in _hostilesInRange)
            {
                enemy.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            _nextShootTime = Time.time + _shootCooldown;
            
            /*_turret.LookAt(_target.transform);
            if (CanShoot())
            {
                Debug.Log("Found Enemy");
                //Enemy enemy1 = GetComponent<Renderer>().material.color = Color.red;
                _target.gameObject.GetComponent<Renderer>().material.color = Color.red;
                _nextShootTime = Time.time + _shootCooldown;
            }
            else
            {
                Debug.Log("White");
                //Enemy enemy1 = GetComponent<Renderer>().material.color = Color.white;
                _target.gameObject.GetComponent<Renderer>().material.color = Color.white;
            }*/
        }
    }
}
