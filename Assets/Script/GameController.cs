using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazard;
    public GameObject enemyShip;
    public GameObject player;
    public Vector3 spawnValue;

    private float spawnWait = 0.5f; // thoi gian giua cac asteroid
    private float startWait = 1.0f; // thoi gian cho de bat dau`
    private float waveWait = 5.0f; // thoi gian giua cac wave
    private int hazardCount = 10;

    public Text scoreText; // hien score  ingame
    [HideInInspector] public int score;

    HUDController hudController;

    void Start()

    {

        GameObject hudControllerObject = GameObject.FindGameObjectWithTag("HUDController");
        hudController = hudControllerObject.GetComponent<HUDController>();

        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnEnemy());
        UpdateScore();
    }

    #region create hazzard and enemy
    IEnumerator SpawnWaves()
    {
        // wait 1s for starting
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawmPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard[Random.Range(0,3)], spawmPosition, spawnRotation);
                //wait a while between hazard spawm
                yield return new WaitForSeconds(spawnWait);
            }
            Debug.Log("het 1 wave");
            yield return new WaitForSeconds(waveWait);
        }
    }

    IEnumerator SpawnEnemy()
    {
        //cho 1s de bat dau
        yield return new WaitForSeconds(1);
        while (true)
        {
            Vector3 spawmPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(enemyShip, spawmPosition, spawnRotation);

            //cu 2 giay ra 1 con quai
            yield return new WaitForSeconds(2);
        }
        
    }

    #endregion

    #region player score

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    #endregion

    public void Game_Restart()
    {
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnEnemy());
        Debug.Log("Khoi tao player game moi!");
        score = 0;
        UpdateScore();
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
    }


}

