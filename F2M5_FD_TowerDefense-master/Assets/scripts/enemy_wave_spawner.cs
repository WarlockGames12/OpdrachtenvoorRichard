using System.Collections;
using UnityEngine;

public class enemy_wave_spawner : MonoBehaviour
{
    // the 3 functions of a wave
    public enum SpawnState { SPAWNING, WAITING, COUNTING };



    [System.Serializable]
    public class wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    // make an array for the waves
    public wave[] waves;
    private int NextWave = 0;


    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float Wavecountdown;

    private float searchCountDown = 1f;

    public SpawnState state = SpawnState.COUNTING;



    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("no spawn points");
        }

        Wavecountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (Wavecountdown <= 0)
        {
            if (state == SpawnState.WAITING)
            {
                if (!EnemyIsAlive())
                {
                    //Wave is completed
                    WaveCompleted();
                    Debug.Log("Completed");
                }
                else
                {
                    return;
                }
            }

            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[NextWave]));
                Debug.Log("next wave");
            }

            Wavecountdown = 3;
        }
        else
        {
            Wavecountdown -= Time.deltaTime;
        }

    }

    void WaveCompleted()
    {
        Debug.Log("Wave completed");

        state = SpawnState.COUNTING;
        Wavecountdown = timeBetweenWaves;

        if (NextWave + 1 > waves.Length - 1)
        {
            NextWave = 0;
            Debug.Log("all waves complete! looping");
        }
        else
        {
            NextWave++;
        }


    }
    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(wave _wave)
    {
        Debug.Log("spawning wave" + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("no spawn points");
        }

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, transform.position, transform.rotation);
    }
}
