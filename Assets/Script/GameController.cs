using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValue;
    private float spawnWait = 0.5f; // thoi gian giua cac asteroid
    private float startWait = 1.0f; // thoi gian cho de bat dau`
    private float waveWait = 5.0f; // thoi gian giua cac wave
    private int hazardCount = 10;

    public Text scoreText;
    private int score;
    void Start()
    {
        StartCoroutine(SpawnWaves());
        UpdateScore();
    }


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
                Instantiate(hazard, spawmPosition, spawnRotation);
                //wait a while between hazard spawm
                yield return new WaitForSeconds(spawnWait);
            }
            Debug.Log("het 1 wave");
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
