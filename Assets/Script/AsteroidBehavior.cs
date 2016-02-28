using UnityEngine;
using System.Collections;

public class AsteroidBehavior : MonoBehaviour {

    private Rigidbody rigid;
    private float tumble = 5;
    public GameObject asteroidExplosion; // hieu ung no cua asteroid
    private float asteroidSpeed; // toc do 

    public int scoreValue;          //so diem tuong ung voi asteroid
    private GameController gameController;  
    // Use this for initialization
	void Start () {
        asteroidSpeed = -5f;
        rigid = GetComponent<Rigidbody>();
        rotateOvertime();
        Move();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }


    void Move()
    {
        rigid.velocity = transform.forward * asteroidSpeed;
    }
    void rotateOvertime()
    {
        rigid.angularVelocity = Random.insideUnitSphere * tumble;
    }

    // bi dinh dan.
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerBolt")
        {
            Debug.Log("Bi player ban'");
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject asteroidVFX = Instantiate(asteroidExplosion, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            Destroy(asteroidVFX,1);

            //tang diem player
            gameController.AddScore(scoreValue);
            Debug.Log("Tang diem");
        }
    }
}

