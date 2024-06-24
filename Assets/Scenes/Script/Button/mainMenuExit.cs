using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerExit : EventTrigger
{
	public override void OnPointerClick(PointerEventData data)
	{
		Debug.Log("Exit called.");
		Application.Quit();
	}
}
