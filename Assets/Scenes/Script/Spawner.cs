using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public int			time_spawn;
	private	int			i_spawn;
	public GameObject	ennemy;
	public GameObject	ennemyParent;

    void Start() {
        i_spawn = time_spawn;
    }

    void Update() {
		i_spawn--;
		if (i_spawn == 0) {
			i_spawn = time_spawn;
			Spawn();
		}
    }

	void Spawn() {
		GameObject	cpy;

		cpy = Instantiate(ennemy, transform.position + Vector3.back, ennemy.gameObject.transform.rotation);
		cpy.gameObject.transform.parent = ennemyParent.transform;
		GameManager.Instance.nbrEnn++;
	}
}
