using UnityEngine;
using System.Collections;


public class enemyMove : MonoBehaviour {

	float MoveNum = 0;
	public float BallCount;
	public GameObject Ball;

	// Use this for initialization
	void Start () {
		for(int i = 0;i <= BallCount; i++){
			GameObject GO = Instantiate (Ball,this.transform.position,this.transform.rotation)as GameObject;
			GO.transform.Rotate(0,0,i / BallCount * 360);
	}
	}
	
	// Update is called once per frame
	void Update () {
		//MoveNum += Random.Range (-0.03f, 0.03f);
		this.transform.Translate (0, -0.03f, 0);

	}
}
