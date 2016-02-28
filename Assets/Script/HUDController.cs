using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {
    public GameObject gameOverPanel; // panel game Over
    public Text scoreTextGO; // hien score khi game over

    GameController gameController;

    // Use this for initialization
    void Start () {
        //lay du lieu tu GameController
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

    }
	
    public void HUD_Game_Over()
    {
        gameOverPanel.SetActive(true);
        scoreTextGO.text = "Score: " + gameController.score;
    }

    public void Btn_Restart()
    {
        gameController.Game_Restart();
        gameOverPanel.SetActive(false);
    }

    public void Btn_Quit()
    {
        Application.LoadLevel("StartScene");
    }

   
}
