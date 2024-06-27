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
		if (target)
			cpy = target.transform.position;
		else
			Destroy(gameObject);
	}

    void Update() {
		if (!target)
			Destroy(gameObject);
        transform.position += (cpy - transform.position).normalized * speed * Time.deltaTime;
		if (Vector3.Distance(transform.position, cpy) < 0.05) {
			ennemy tmp = target.GetComponent<ennemy>();
			tmp.HP -= atk * atkTurret * GameManager.Instance.multiAtk;
			if (tmp.HP <= 0) {
				if (target)
					Destroy(target);
			}
			Destroy(gameObject);
		}
    }
}
