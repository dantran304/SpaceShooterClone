using UnityEngine;
using System.Collections;

public class BoltBehavior : MonoBehaviour {

    private Rigidbody rigid;
    private float boltSpeed;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        boltSpeed = 20f;
        rigid.velocity = transform.forward * boltSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
