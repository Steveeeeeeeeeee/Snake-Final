using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFoodSpawner : MonoBehaviour
{
    public BlueFood blueFoodPrefab;
    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 15f;
    private BlueFood currentBlueFood;

    void Start()
    {
        currentBlueFood = Instantiate(blueFoodPrefab, Vector3.zero, Quaternion.identity);
        StartCoroutine(SpawnBlueFood());
    }

    IEnumerator SpawnBlueFood()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(minSpawnInterval, maxSpawnInterval));

            if (!currentBlueFood.gameObject.activeInHierarchy)
            {
                currentBlueFood.gameObject.SetActive(true);
                currentBlueFood.RandomPosition();
            }
        }
    }
}
