using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventTriggerPauseExitYes : EventTrigger
{
	public override void OnPointerClick(PointerEventData data)
	{
		Destroy(GameManager.Instance.gameObject);
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}
}
