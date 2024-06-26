using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy : MonoBehaviour
{
	private int		regenE;
	private int		maxE;
	private float	wait, nextWait;
	private float	tmp1, tmp2;
	private float	width, height;

    void Start()
    {
		nextWait = 0f;
		wait = 0.1f;
		maxE = GameManager.Instance.maxE;
		regenE = GameManager.Instance.regenE;
		tmp1 = maxE;
		tmp2 = regenE;
		transform.position += transform.parent.position;
		width = transform.parent.GetComponent<RectTransform>().rect.width;
		height = transform.parent.GetComponent<RectTransform>().rect.height;
		transform.localScale = new Vector3(GameManager.Instance.PlayerE / tmp1, 1f, 1f);
		transform.position = new Vector3(-GameManager.Instance.PlayerE / tmp1 / 2 + width, -height / 2, 0f);
    }

    void Update()
    {
		if (Time.time < nextWait)
			return ;
		nextWait = Time.time + wait;
		if (GameManager.Instance.PlayerE == maxE)
			return ;
		if (GameManager.Instance.PlayerE + regenE > maxE) {
			GameManager.Instance.PlayerE = maxE;

		} else {
			GameManager.Instance.PlayerE += regenE;
		}
		transform.localScale = new Vector3(GameManager.Instance.PlayerE / tmp1, 1f, 1f);
		transform.position = new Vector3(-GameManager.Instance.PlayerE / tmp1 / 2 + width, -height / 2, 0f);
    }
}
