using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemy : MonoBehaviour
{
	public float		speed;
	public int			atk;
	private GameObject	dest;
	private Vector3		basePos;
	public float		HP;

	void Start() {
		var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
		for (var i = 0; i < goArray.Length; i++)
		{
			if (goArray[i].layer == 6) { 
				dest = (GameObject)goArray[i];
				break;
			}
		}
		basePos = dest.gameObject.transform.position;
	}
	
    void Update()
    {
        transform.position += (basePos - transform.position).normalized * speed;
		if (Vector3.Distance(transform.position, basePos) < 0.1) {
			GameManager.Instance.DecreasePlayerHP(atk);
			GameManager.Instance.nbrEnn--;
			Destroy(gameObject);
		}
    }
}
