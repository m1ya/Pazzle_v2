using UnityEngine;
using System.Collections;


public class EnemyScript : MonoBehaviour {

	float MoveNum = 0;
	public float BallCount;
	public GameObject Ball;
	private Rigidbody Erb;
	GameObject BallFolder;
	// Use this for initialization
	void Start () {
		Erb = this.GetComponent<Rigidbody>();
		Erb.velocity = transform.up * -0.5f;
		InvokeRepeating ("Shot", 1.5f,1.5f);
		BallFolder = GameObject.Find ("BallFolder");
	}

	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -3) {
			Destroy (gameObject);
		}

	}
	//玉の生成を管理
	void Shot(){
		for(int i = 0;i <= BallCount; i++){
			GameObject GO = Instantiate (Ball,this.transform.position,this.transform.rotation)as GameObject;
			//生成したBallをフォルダーにまとめる
			GO.transform.parent = BallFolder.transform;
			GO.transform.Rotate(0,0,i / BallCount * 360);
	}
}
}
