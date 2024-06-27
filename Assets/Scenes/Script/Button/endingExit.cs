using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventTriggerPauseEndingExit : EventTrigger
{
	public override void OnPointerClick(PointerEventData data)
	{
		SceneManager.LoadScene(0);
	}
}
