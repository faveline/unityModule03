using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrets : MonoBehaviour
{
	public float		fireRate;
	private float		nextFire;
	public float		damage;
	public float		range;
	private float		distMin;
	private int			iMin;
	private float		tmp;
	public GameObject	bullet;
	public int			energyCost;

    void Start() {
		nextFire = 0f;
    }

	void Update() {
		if (GameManager.Instance.gameOver)
			return;
		if (Time.time < nextFire) {
			return ;
		}
		nextFire = Time.time + fireRate;
		distMin = 1000;
        for (int i = 0; i < GameManager.Instance.ennemies.transform.childCount; i++) {
			tmp = Vector3.Distance(transform.position, GameManager.Instance.ennemies.transform.GetChild(i).gameObject.transform.position);
			if (tmp < distMin) {
				distMin = tmp;
				iMin = i;
			}

		}
		if (distMin < range)
			shoot(iMin);
    }				

	void shoot(int i) {
		GameObject	cpy;

		cpy = Instantiate(bullet, transform.position, transform.rotation);
		cpy.GetComponent<bullet>().target = GameManager.Instance.ennemies.transform.GetChild(i).gameObject;
		cpy.GetComponent<bullet>().atkTurret = damage;
		cpy.gameObject.transform.parent = transform;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer != 9)
			return ;
		GameManager.Instance.targetBool = true;
		GameManager.Instance.target = other;
    }

	private void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.layer != 9)
			return ;
		GameManager.Instance.targetBool = false;
	}
}
