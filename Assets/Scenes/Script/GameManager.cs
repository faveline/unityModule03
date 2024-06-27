using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
	public int			nbrEnmy;
	public GameObject	retryMenu;
	public GameObject	nextGame;
	public bool			menu;
	public GameObject	score;

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
		menu = true;
		Time.timeScale = 0;
		retryMenu.SetActive(true);
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape) && !menu) {
			if (Time.timeScale == 1) {
				Time.timeScale = 0;
				pause.SetActive(true);
			} else {
				Time.timeScale = 1;
				pause.SetActive(false);
			}
		}
		if (!gameOver && nbrEnmy == 0 && ennemies.transform.childCount == 0) {
			nbrEnmy = -1;
			menu = true;
			if (SceneManager.GetActiveScene().buildIndex == 1) {
				changeScore();
				Time.timeScale = 0;
				nextGame.SetActive(true);
			}
			else
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		if (SceneManager.GetActiveScene().name == "Ending" && !gameOver)
			changeScoreE();
	}

	private void changeScore() {
		if (PlayerHP == 5 && PlayerE == maxE)
			score.transform.GetComponent<Text>().text += "S Well played !";
		else if (PlayerHP == 5)
			score.transform.GetComponent<Text>().text += "A Good job !";
		else if (PlayerHP >= 3)
			score.transform.GetComponent<Text>().text += "B Job Done.";
		else
			score.transform.GetComponent<Text>().text += "C Meh.";
	}

	private void changeScoreE() {
		if (PlayerHP == 5 && PlayerE == maxE)
			GameObject.FindGameObjectsWithTag("scoreE")[0].transform.GetComponent<Text>().text += "S Well played !";
		else if (PlayerHP == 5)
			GameObject.FindGameObjectsWithTag("scoreE")[0].transform.GetComponent<Text>().text += "A Good job !";
		else if (PlayerHP >= 3)
			GameObject.FindGameObjectsWithTag("scoreE")[0].transform.GetComponent<Text>().text += "B Job Done.";
		else
			GameObject.FindGameObjectsWithTag("scoreE")[0].transform.GetComponent<Text>().text += "C Meh.";
		gameOver = true;
	}
}
