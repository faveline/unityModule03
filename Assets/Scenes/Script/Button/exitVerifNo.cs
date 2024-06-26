using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventTriggerPauseExitNo : EventTrigger
{
	public override void OnPointerClick(PointerEventData data)
	{
		GameManager.Instance.verif.SetActive(false);
	}
}
