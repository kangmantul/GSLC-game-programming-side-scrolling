using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int jumlah_enemy;
    public int waktu_wave;
    public float jarak_muncul;
    public float jarak_minimal;
    public Transform player;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(waktu_wave);
            SpawnEnemies();
        }
    }
    void SpawnEnemies()
    {
        for (int i = 0; i < jumlah_enemy; i++)
        {
            Vector3 spawnPosition = GetValidSpawnPosition();
            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }
    Vector3 GetValidSpawnPosition()
    {
        float randomAngle = Random.Range(0f, 360f);
        float randomDistance = Random.Range(jarak_minimal, jarak_muncul);

        Vector3 offset = new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle)) * randomDistance;
        return player.position + offset;
    }

}
