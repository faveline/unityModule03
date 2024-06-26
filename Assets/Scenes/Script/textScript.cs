using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textScript : MonoBehaviour
{
	public GameObject	turret;
	public turrets		turretS;
	
    void Start()
    {
		turretS = turret.transform.GetComponent<turrets>();
        transform.GetComponent<Text>().text = "Atk: " + turretS.damage + "\n";
		transform.GetComponent<Text>().text += "Fire rate: " + turretS.fireRate + "\n";	
		transform.GetComponent<Text>().text += "Range: " + turretS.range + "\n";
		transform.GetComponent<Text>().text += "Cost: " + turretS.energyCost;
		gameObject.SetActive(false);
    }
}
