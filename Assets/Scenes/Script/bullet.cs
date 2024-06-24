using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	public float 		speed;
	public float		atk;
	public float		atkTurret;
	public GameObject	target;
	private Vector3		cpy;

    void Start() {
		cpy = target.transform.position;
	}

    void Update() {
		if (!target)
			Destroy(gameObject);
		else
			cpy = target.transform.position;
        transform.position += (cpy - transform.position).normalized * speed;
		if (Vector3.Distance(transform.position, cpy) < 0.1) {
			ennemy tmp = target.GetComponent<ennemy>();
			tmp.HP -= atk * atkTurret * GameManager.Instance.multiAtk;
			if (tmp.HP <= 0) {
				GameManager.Instance.nbrEnn--;
				if (target)
					Destroy(target);
			}
			Destroy(gameObject);
		}
    }
}
