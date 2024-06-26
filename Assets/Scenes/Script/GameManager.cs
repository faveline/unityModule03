using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

		
    }

	public int 			PlayerHP;
	public int			PlayerE;
	public int			maxE;
	public int			regenE;
	public GameObject	spawner;
	public GameObject	ennemies;
	public int			multiAtk;
	public bool			gameOver = false;
	public bool			targetBool = false;
	public Collider2D	target;
	public GameObject	pause;
	public GameObject	verif;

	public void DecreasePlayerHP(int hitPoints = 1)
	{
		PlayerHP -= hitPoints;
		Debug.Log("BaseHP: " +  PlayerHP);
		if (PlayerHP <= 0) {
			GameOver();
		}
	}

	private void GameOver() {
		gameOver = true;
		Debug.Log("Game Over !");
		Destroy(spawner);
		Destroy(ennemies);
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (Time.timeScale == 1) {
				Time.timeScale = 0;
				pause.SetActive(true);
			} else {
				Time.timeScale = 1;
				pause.SetActive(false);
			}
		}
	}
}
