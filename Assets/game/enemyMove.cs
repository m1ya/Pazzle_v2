using UnityEngine;
using System.Collections;


public class enemyMove : MonoBehaviour {

	float MoveNum = 0;
	public float BallCount;
	public GameObject Ball;
	private Rigidbody Erb;
	// Use this for initialization
	void Start () {
		Erb = this.GetComponent<Rigidbody>();
		Erb.velocity = transform.up * -0.5f;
		InvokeRepeating ("enemyShot", 1.5f,1.5f);
	}

	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -3) {
			Debug.Log ("AAA");
			Destroy (gameObject);
		}

	}

	void enemyShot(){
		for(int i = 0;i <= BallCount; i++){
			GameObject GO = Instantiate (Ball,this.transform.position,this.transform.rotation)as GameObject;
			GO.transform.Rotate(0,0,i / BallCount * 360);
	}
}
}
