using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] GameObject toSpawn;
	[SerializeField] float spawnFreq = 5;
    void Update()
    {
        float rnum = Random.Range(0f, 1000f);
		if (rnum <= spawnFreq) {
			Vector3 position = new Vector3(0,0,0);
			float rx = Random.Range(0.1f,0.9f);
			float ry = Random.Range(0.1f,0.9f);
			// Bound it to the World boundaries;
			position.x = rx; position.y = ry;
			position = Camera.main.ViewportToWorldPoint(position);
			position.z = 0;
			Instantiate(toSpawn, position, Quaternion.identity);
		}
    }
}
