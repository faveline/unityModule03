using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class turretBar : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
	private Image		img;
	public int			tmpE;
	public GameObject	thisTurret;
	private int			energyC;
	private GameObject	toDrag;
	private bool		canDrag;
	public GameObject	text;
	public GameObject	target;
	public GameObject	circleRange;

    void Start() {
		tmpE = GameManager.Instance.PlayerE;
		energyC = thisTurret.GetComponent<turrets>().energyCost;
        img = transform.GetComponent<Image>();
		toDrag = Instantiate(thisTurret, transform.position, transform.rotation);
		toDrag.gameObject.transform.parent = transform;
		toDrag.SetActive(false);
    }

    void Update() {
		if (GameManager.Instance.PlayerE >= energyC) {
			img.color = Color.white;
		} else if (tmpE != GameManager.Instance.PlayerE) {
			img.color = new Color(1f, 0f, 0f, 1f * GameManager.Instance.PlayerE / energyC);
			tmpE = GameManager.Instance.PlayerE;
		}
    }

	public void OnBeginDrag(PointerEventData eventData) {
		if (img.color == Color.white && Time.timeScale != 0) {
			toDrag.SetActive(true);
			canDrag = true;
			circleRange.transform.position = Camera.main.ScreenPointToRay(eventData.position).GetPoint(Vector3.Distance(toDrag.gameObject.transform.position, Camera.main.transform.position));
			circleRange.transform.position = new Vector3(circleRange.transform.position.x, circleRange.transform.position.y, -1);
			circleRange.SetActive(true);
		}
	}

	public void OnDrag(PointerEventData eventData) {
		if (canDrag) {
			toDrag.transform.position = Camera.main.ScreenPointToRay(eventData.position).GetPoint(Vector3.Distance(toDrag.gameObject.transform.position, Camera.main.transform.position));
			circleRange.transform.position = Camera.main.ScreenPointToRay(eventData.position).GetPoint(Vector3.Distance(toDrag.gameObject.transform.position, Camera.main.transform.position));
			circleRange.transform.position = new Vector3(circleRange.transform.position.x, circleRange.transform.position.y, -1);
		}
	}

	public void OnEndDrag(PointerEventData eventData) {
		if (!canDrag)
			return;
		GameObject	cpy;

		circleRange.SetActive(false);
		if (!GameManager.Instance.targetBool) {
			toDrag.SetActive(false);
			return ;
		}
		toDrag.SetActive(false);
		cpy = Instantiate(thisTurret, toDrag.transform.position, toDrag.transform.rotation);
		cpy.gameObject.transform.position = new Vector3(GameManager.Instance.target.transform.position.x, GameManager.Instance.target.transform.position.y, -1);
		GameManager.Instance.targetBool = false;	
		Destroy(GameManager.Instance.target);
		GameManager.Instance.target = null;
		cpy.gameObject.transform.parent = transform;
		canDrag = false;
		GameManager.Instance.PlayerE -= energyC;
		if (GameManager.Instance.PlayerE < energyC) {
			img.color = new Color(1f, 0f, 0f, energyC / GameManager.Instance.PlayerE);
		}
	}

	public void OnPointerEnter(PointerEventData eventData) {
		text.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
		text.SetActive(false);
    }
}
