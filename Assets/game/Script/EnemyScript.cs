using UnityEngine;
using System.Collections;


public class EnemyScript : MonoBehaviour {

	float MoveNum = 0;
	public float BallCount;
	//敵の発する玉
	public GameObject Ball;
	//敵の発する玉をまとまるフォルダー
	GameObject BallFolder;


	private Rigidbody Erb;
	bool SiMo;
	Vector3 Position;
	float tmpX;
	// Use this for initialization
	void Start () {

		InvokeRepeating ("Shot", 1.5f,1.5f);
		BallFolder = GameObject.Find ("BallFolder");

		Erb = this.GetComponent<Rigidbody>();
		//前方向への速度付与
		Erb.velocity = transform.up * -0.5f;
		SiMo = true;
	}

	
	// Update is called once per frame
	void Update () {
		Move ();
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

	//移動を管理
	void Move()
	{
		Position = this.transform.position;
		//目標の座標を指定し、その方向への速度付与
		if (SiMo) {
			tmpX = Random.Range (-2.4f, 2.5f);
			Position.x = tmpX - Position.x;
			Erb.velocity += transform.right * Mathf.Sign (Position.x) * 0.3f;
			SiMo = false;
		} else{
			//目標座標と現在座標の差がしきい値以下になれば付与した速度をなくす
			if (Mathf.Abs(tmpX - Position.x) <= 0.3) {
				Erb.velocity -= transform.right * Mathf.Sign (Position.x) * 0.3f;
				SiMo = true;
			}

		}
	}
	//衝突を管理
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
			Death ();
	}

	//死亡を管理
	void Death()
	{
		Destroy (gameObject);
		MiniGameManager.manzokudo++;
	}

}
