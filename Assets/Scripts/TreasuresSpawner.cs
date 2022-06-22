using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasuresSpawner : MonoBehaviour
{
    [SerializeField] private int _frequency;
    [SerializeField] private Treasure _template;

    private Transform[] _spawnPoints;

    void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
        StartCoroutine(SpawnTreasure(_frequency));    
    }

    private IEnumerator SpawnTreasure(int frequency)
    {
        var waitingTime = new WaitForSeconds(frequency);

        while (true)
        {         
            Transform currentSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            if (currentSpawnPoint.childCount == 0)
            {
                Instantiate(_template, currentSpawnPoint);
            }

            yield return waitingTime;
        }  
    }
}
