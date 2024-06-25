using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
	private int	hp;
	private int	max;
	private Vector3 scaleChange, positionChange;

	void Start() {
		max = GameManager.Instance.PlayerHP;
		hp = GameManager.Instance.PlayerHP;
        scaleChange = new Vector3(0.2f, 0f, 0f);
        positionChange = new Vector3(0.1f, 0f, 0f);
	}

    void Update() {
		if (hp != GameManager.Instance.PlayerHP) {
			hp--;
			transform.localScale -= scaleChange;
			transform.position -= positionChange;
		}
    }
}
