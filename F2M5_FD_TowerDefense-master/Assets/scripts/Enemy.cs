using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealthComponent))]
public class Enemy : MonoBehaviour
{
    private HealthOponent _healthComponent;

    private void Start()
    {
        _healthComponent = GetComponent<HealthOponent>();
    }

    public HealthOponent GetHealthOponent()
    {
        return _healthComponent;
    }
}
