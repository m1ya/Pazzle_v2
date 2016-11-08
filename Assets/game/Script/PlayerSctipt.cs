using UnityEngine;
using System.Collections;

public class PlayerSctipt : MonoBehaviour {
	//プレイヤーが発する玉
	public GameObject eater;
	bool rightMove;
	bool leftMove;
	// Use this for initialization
	void Start () {
		rightMove = false;
		leftMove = false;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	//移動全体を管理
	void Move()
	{
		if (rightMove) {
			transform.position += new Vector3(1.5f, 0f, 0f) * Time.deltaTime;
		}
		if (leftMove) {
			transform.position -= new Vector3(1.5f, 0f, 0f) * Time.deltaTime;
		}

	}
	//ボタンによって移動方向を決定
	public void Direction(string direction)
	{
		if (direction == "Right") {
			rightMove = !rightMove;
		}
		if (direction == "Left") {
			leftMove = !leftMove;
		}
	}


	//攻撃を管理
	public void Attack()
	{
		Instantiate (eater,this.transform.position,Quaternion.identity);
	}

	//死亡を管理
	void Death(Collider collider)
	{
		Destroy (gameObject);
		Destroy (collider.gameObject);
	}

	//衝突処理全体を管理
	void OnTriggerEnter(Collider collider){
		if (collider.tag == "EneAtt") {
			Death (collider);
			}
	}

}
