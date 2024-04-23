using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] GameObject toSpawn;
	[SerializeField] Transform spawnLocation;
	[SerializeField] float spawnFreq = 5;
    void Update()
    {
        float rnum = Random.Range(0, 1000);
		if (rnum <= spawnFreq) {
			Vector3 position = spawnLocation.position;
			float rx = Random.Range(-11.5f, 11.5f);
			float ry = Random.Range(-11.5f, 11.5f);
			position.x = rx; position.y = ry;
			Instantiate(toSpawn, position, spawnLocation.rotation);
		}
    }
}
