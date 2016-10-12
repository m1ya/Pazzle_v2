using UnityEngine;
using System.Collections;

public class EnemyBall : MonoBehaviour {

	//Rigidbody rb;
	public Rigidbody rb;
	void Start(){
		rb = this.GetComponent<Rigidbody>();
		rb.velocity = transform.right * 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
