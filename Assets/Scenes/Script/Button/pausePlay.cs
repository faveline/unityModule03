using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventTriggerPausePlay : EventTrigger
{
	public override void OnPointerClick(PointerEventData data)
	{
		Time.timeScale = 1;
		GameManager.Instance.pause.SetActive(false);
	}
}
