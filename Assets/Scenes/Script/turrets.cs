using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrets : MonoBehaviour
{
	public int			speed;
	private int			iSpeed;
	public float		damage;
	public float		range;
	private float		distMin;
	private int			iMin;
	private float		tmp;
	public GameObject	bullet;

    void Start() {
		iSpeed = 0;
    }

	void Update() {
		if (GameManager.Instance.gameOver)
			return;
		if (iSpeed > 0) {
			iSpeed--;
			return ;
		}
		distMin = 1000;
        for (int i = 0; i < GameManager.Instance.ennemies.transform.childCount; i++) {
			tmp = Vector3.Distance(transform.position, GameManager.Instance.ennemies.transform.GetChild(i).gameObject.transform.position);
			if (tmp < distMin) {
				distMin = tmp;
				iMin = i;
			}

		}
		if (distMin < range) {
			shoot(iMin);
			iSpeed = speed;
		}
    }				

	void shoot(int i) {
		GameObject	cpy;

		cpy = Instantiate(bullet, transform.position, transform.rotation);
		cpy.GetComponent<bullet>().target = GameManager.Instance.ennemies.transform.GetChild(i).gameObject;
		cpy.GetComponent<bullet>().atkTurret = damage;
		cpy.gameObject.transform.parent = transform;
	}
}
