using UnityEngine;
using System.Collections;

public class PlayerSctipt : MonoBehaviour {
	//プレイヤーが発する玉
	public GameObject eater;
	bool rightMove;
	bool leftMove;
	//先頭かどうか
	public bool isLeader = false;
	//直進するかどうか
	bool isStraight = false;
	// Use this for initialization
	void Start () {
		rightMove = false;
		leftMove = false;
	}
	
	// Update is called once per frame
	void Update () {
		SwhichPlayer ();
		//全メソッドはこのインスタンスが先頭の場合のみ実行される
		if (!isLeader) return;
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
		//アタックボタン押さない限りこの下の処理は行われない
		if (!isStraight)return;

		transform.position += new Vector3 (0, 1.0f, 0) * Time.deltaTime;

	}

	//Rightボタンを押している間は右方向へ移動
	public void Right()
	{
		rightMove = !rightMove;
	}
	//Leftボタンを押している間は左方向へ移動
	public void Left()
	{
		leftMove = !leftMove;
	}


	//攻撃ボタンをおした時の処理を管理
	public void Attack()
	{
		//プレイヤーが直進する
		isStraight = true;
		//操作対象を後ろに並んでいるプレイヤーに変更
		SwhichPlayer();
	}

	//死亡を管理
	void Death(Collider collider)
	{
		Destroy (gameObject);
		Destroy (collider.gameObject);
		//満足度低下
		MiniGameManager.manzokudo--;
	}

	//衝突処理全体を管理
	void OnTriggerEnter(Collider collider){
		if (collider.tag == "EneAtt") {
			Death (collider);
			}
	}

	//背中からRayを飛ばして操作対象を切り替える
	void SwhichPlayer()
	{
		//Rayの作成
		Ray ray = new Ray (transform.position, new Vector3 (0, -1, 0));

		//Rayが当たったオブジェクトの情報を入れる箱
		RaycastHit hit;
		//Rayの飛ばせる距離
		int distance = 10;
		//Rayの可視化
		Debug.DrawLine (ray.origin, ray.direction * distance, Color.red);
		//もしRayにオブジェクトが衝突したら
		if (Physics.Raycast(ray,out hit,distance))
		{
			if (hit.collider.tag == "Player")
				Debug.Log ("当たった");
		}
	}

}
