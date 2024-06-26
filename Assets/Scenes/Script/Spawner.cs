using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float		timeSpawn;
	private	float		nextSpawn;
	public GameObject	ennemy;
	public GameObject	ennemyParent;

    void Start() {
        nextSpawn = 0f;
    }

    void Update() {
		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + timeSpawn;
			Spawn();
		}
    }

	void Spawn() {
		GameObject	cpy;

		cpy = Instantiate(ennemy, transform.position + Vector3.back, ennemy.gameObject.transform.rotation);
		cpy.gameObject.transform.parent = ennemyParent.transform;
	}
}
