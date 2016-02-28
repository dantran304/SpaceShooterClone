using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
    public GameObject shot;
    public GameObject shotSpawn;
    public float fireRate;
    public float delay;

    public GameObject enemyExplosion; //hieu ung no cua enemy
    public int scoreValue; // so diem tuong ung voi enemy
    private GameController gameController;


    Rigidbody rigid;
    private float enemySpeed;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();

        //move
        enemySpeed = -5f;
        Move();

        //tham chieu den gameController
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        //thuc hien ham shot trong khoang delay, sau thoi gian rate
        InvokeRepeating("Fire", delay, fireRate);
	}
	
    void Fire()
    {
        Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
    }

    void Move()
    {
        rigid.velocity = transform.forward * enemySpeed;
    }

    // bi dinh dan.
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBolt")
        {
            Debug.Log("Bi player ban'");
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject asteroidVFX = Instantiate(enemyExplosion, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            Destroy(asteroidVFX, 1);

            //tang diem player
            gameController.AddScore(scoreValue);
            Debug.Log("Tang diem");
        }
    }

}
