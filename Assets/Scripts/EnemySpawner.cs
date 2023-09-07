using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = true;
    WaveConfig currentWave;

    private void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }

    private IEnumerator SpawnEnemyWaves()
    {
        do
        {
            for (int i = 0; i < waveConfigs.Count; i++)
            {
                // get current wave
                currentWave = waveConfigs[i];
                for (int j = 0; j < currentWave.GetEnemyCount(); j++)
                {

                    Instantiate(currentWave.GetEnemyPrefab(j),
                        currentWave.GetStartingWaypoint().position,
                        Quaternion.Euler(0, 0, 180), // rotate object 180 degree
                        transform);
                    // wait time beetween each enemy
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                // wait for a few second before the new wave
                yield return new WaitForSeconds(timeBetweenWaves);

            }
        }
        while (isLooping);


    }
}
