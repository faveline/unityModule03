using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventTriggerPauseExit : EventTrigger
{
	public override void OnPointerClick(PointerEventData data)
	{
		GameManager.Instance.menu = true;
		GameManager.Instance.verif.SetActive(true);
	}
}
