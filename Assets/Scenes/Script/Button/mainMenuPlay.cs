using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventTriggerPlay : EventTrigger
{
	public override void OnPointerClick(PointerEventData data)
	{
		Debug.Log("Play called.");
		SceneManager.LoadScene(1);
	}
}
