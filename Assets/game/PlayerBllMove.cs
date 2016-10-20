using UnityEngine;
using System.Collections;

public class PlayerBllMove : MonoBehaviour {
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
		rb.velocity = transform.forward * 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
