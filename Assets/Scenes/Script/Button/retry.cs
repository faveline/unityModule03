using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventTriggerRetry : EventTrigger
{
	public override void OnPointerClick(PointerEventData data)
	{
		Time.timeScale = 1;
		GameManager.Instance.retryMenu.SetActive(false);
		Destroy(GameManager.Instance.gameObject);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
