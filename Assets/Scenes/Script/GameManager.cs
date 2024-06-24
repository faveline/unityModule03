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
	public GameObject	spawner;
	public GameObject	ennemies;
	public int			nbrEnn;
	public int			multiAtk;
	public bool			gameOver = false;

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
}
