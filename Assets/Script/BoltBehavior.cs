using UnityEngine;
using System.Collections;

public class BoltBehavior : MonoBehaviour {

    private Rigidbody rigid;
    public float boltSpeed;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * boltSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
