using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerBehavior : MonoBehaviour {

    private Rigidbody rigid;
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 movement;
    private float playerSpeed;
    public float tilt;

    public Boundary boundary; // gioi han vung di chuyen

    public GameObject shotSpawn; // vi tri ban dan.
    public GameObject bolt; // dan. cua player
    private float fireRate = 0.2f;
    private float nextFire = 0.0f;
    public GameObject playerExplosion; // hieu ung no cua player
    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();
        playerSpeed = 5.0f;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1")&& Time.time > nextFire)
        {
            Debug.Log("time " + Time.time);
            nextFire = Time.time + fireRate;
            Debug.Log("next fire" + nextFire);
            shootingShot();
        }
	}

    void FixedUpdate()
    {
        //di chuyen player
         moveHorizontal = Input.GetAxis("Horizontal");
         moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigid.velocity = movement*playerSpeed;

        //gioi han vung di chuyen
        rigid.position = new Vector3(
            Mathf.Clamp(rigid.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigid.position.z, boundary.zMin, boundary.zMax));

        // xoay doi tuong khi di chuyen
        rigid.rotation = Quaternion.Euler(0.0f, 0.0f, rigid.velocity.x * -tilt);
    }


   // va phai asteroid
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Asteroid")
        {
            Debug.Log("cham vao player");
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject playerVFX = Instantiate(playerExplosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(playerVFX, 1);
        }
    }

    public AudioClip playerShootAudio;
    public AudioClip playerExplosionAudio;
    void shootingShot()
    {   
        GameObject boltClone = Instantiate(bolt, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
        Debug.Log("Ban' dan. ");
        // play am thanh dan.
        
    }

}
