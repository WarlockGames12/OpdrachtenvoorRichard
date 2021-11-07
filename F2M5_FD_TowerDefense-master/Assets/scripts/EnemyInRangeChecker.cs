using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRangeChecker : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layer;
    public Enemy GetFirstEnemyInRange()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, _radius, _layer);
        if (cols.Length > 0)
        {
            return cols[0].GetComponent<Enemy>();
        }

        return null;
    }

    public Enemy[] GetAllEnemiesInRange()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, _radius, _layer);
        if (cols.Length > 0)
        {
            List<Enemy> enemiesInRange = new List<Enemy>();
            for (int i = 0; i < cols.Length; i++)
            {
                enemiesInRange.Add(cols[i].GetComponent<Enemy>());
            }
            return enemiesInRange.ToArray();
        }
        return null;
    }
        /*
        if (NormalGun == true)
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, _radius, _layer);
            foreach (Collider coll in cols)
            {
                Enemy enemy = coll.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Debug.Log("Found Enemy");
                    return enemy;
                }
            }

        }
        else if (PaintGun == true)
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, _radius, _layer);
            foreach (Collider coll in cols)
            {
                if (_layer == 3 && CompareTag("Enemy"))
                {
                    Enemy enemy = coll.GetComponent<Enemy>();
                }
            }

            return null;
        }
        else if (SlowGun == true)
        {
            GameObject[] AllEnemiesInRange = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
            ChangeSpeed = GetComponent<PathFollower>();
            foreach (GameObject go in AllEnemiesInRange)
            {
                if (go.layer == 3 && go.CompareTag("Enemy"))
                {
                    
                    Collider[] cols = Physics.OverlapSphere(transform.position, _radius, _layer);
                    foreach (Collider coll in cols)
                    {
                        Enemy enemy = coll.GetComponent<Enemy>();
                        if (enemy != null)
                        {
                            ChangeSpeed._speed = 0.5f;
                            Debug.Log("Found Enemy");
                            return enemy;
                        }
                        else
                        {
                            ChangeSpeed._speed = 2f;
                            return null;
                        }
                    }
                }
            }
            return null;
        }
        */

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
