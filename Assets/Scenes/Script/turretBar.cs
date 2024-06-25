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

    void Start()
    {
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
		if (img.color == Color.white) {
			toDrag.SetActive(true);
			canDrag = true;
		}
	}

	public void OnDrag(PointerEventData eventData) {
		if (canDrag)
			toDrag.transform.position = Camera.main.ScreenPointToRay(eventData.position).GetPoint(Vector3.Distance(toDrag.gameObject.transform.position, Camera.main.transform.position));
	}

	public void OnEndDrag(PointerEventData eventData) {
		if (!canDrag)
			return;
		GameObject	cpy;

		toDrag.SetActive(false);
		cpy = Instantiate(thisTurret, toDrag.transform.position, toDrag.transform.rotation);
		cpy.gameObject.transform.position = new Vector3(cpy.gameObject.transform.position.x, cpy.gameObject.transform.position.y, -1);
		cpy.gameObject.transform.parent = transform;
		canDrag = false;
		GameManager.Instance.PlayerE -= energyC;
		if (GameManager.Instance.PlayerE < energyC) {
			img.color = new Color(1f, 0f, 0f, energyC / GameManager.Instance.PlayerE);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
    }
}
