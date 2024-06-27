using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float		timeSpawn;
	private	float		nextSpawn;
	public GameObject	ennemy;
	public GameObject	ennemyParent;
	public int			palierEnmy1;
	public int			palierEnmy2;
	public int			nbrEnmy;

    void Start() {
        nextSpawn = 0f;
    }

    void Update() {
		if (GameManager.Instance.nbrEnmy > nbrEnmy)
			return ;
		if (GameManager.Instance.nbrEnmy == palierEnmy1) {
			timeSpawn = 2 * timeSpawn / 3;
			palierEnmy1 = -1;
		}
		if (GameManager.Instance.nbrEnmy == palierEnmy2) {
			timeSpawn = 2 * timeSpawn / 3;
			palierEnmy2 = -1;
		}
		if (Time.time > nextSpawn && GameManager.Instance.nbrEnmy > 0) {
			nextSpawn = Time.time + timeSpawn;
			Spawn();
		}
    }

	void Spawn() {
		GameObject	cpy;

		cpy = Instantiate(ennemy, transform.position + Vector3.back, ennemy.gameObject.transform.rotation);
		cpy.gameObject.transform.parent = ennemyParent.transform;
		GameManager.Instance.nbrEnmy--;
	}
}
