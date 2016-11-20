using UnityEngine;
using System.Collections;

public class PlayerSctipt : MonoBehaviour {
	
	//先頭かどうか
	public bool isLeader = false;
	//直進するかどうか
	bool isStraight = false;


	
	void Update () {
		//まず列の先頭でない限り何も始まらない
		if (!isLeader) return;
		Move ();

		//先頭でも、左クリックしない限り何も始まらない
		if (!Input.GetMouseButtonDown (0)) return;
		SwhichPlayer ();
		isStraight = true;
	}

	//移動全体を管理
	void Move()
	{
		//左クリックしない限りこのメソッドは何も始まらない
		if (!isStraight)return;
		//横移動
		SideMove ();
	    
		//縦移動
		StraightMove();
	}

	//横の移動を管理
	void SideMove()
	{
		//傾きを検知して横移動
		float speed = 5.0f;
		var dir = Vector3.zero;
		dir.x = Input.acceleration.x;
		dir.y = Input.acceleration.y;

		if(dir.sqrMagnitude > 1){
			dir.Normalize();
		}
		dir *= Time.deltaTime;
		transform.Translate(dir * speed);
	}

	//縦の移動を管理
	void StraightMove()
	{
		transform.position += new Vector3 (0, 1.0f, 0) * Time.deltaTime;
	}


	//死亡を管理
	void Death(Collider collider)
	{
		//衝突したオブジェクトを消滅させる
		Destroy (collider.gameObject);

		//満足度低下
		DownManzokudo();

		//自分を消滅させる
		Destroy (gameObject);
	}

	void Eat(Collider collider)
	{
		//衝突したオブジェクトを消滅させる
		Destroy (collider.gameObject);

		//満足度増加
		UpManzokudo ();

		//自分を消滅させる
		Destroy (gameObject);
	}

	//衝突処理全体を管理
	void OnTriggerEnter(Collider collider){

		//敵の玉（たまねぎ）に当たったら
		if (collider.tag == "EneAtt") Death (collider);

		//敵（二郎）に当たったら
		if (collider.tag == "Enemy") Eat (collider);
	}

	//背中からRayを飛ばして2列目のプレイヤーに次の操作権限を与える
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

		//Rayにオブジェクトが衝突しない限りここで返る
		if (!Physics.Raycast(ray,out hit,distance)) return;

		//当たったオブジェクトがのtagがPlayerだったら
		if (hit.collider.tag == "Player") {
			Debug.Log ("当たった");
			hit.collider.gameObject.SendMessage ("NextPlayer");
		}
	}

	//先頭のプレイヤーから指名されるメソッド
	public void NextPlayer()
	{
		isLeader = true;
	}

	//満足度増加メソッド
	void UpManzokudo()
	{
		MiniGameManager.manzokudo++;
	}

	//満足度低下メソッド
	void DownManzokudo()
	{
		MiniGameManager.manzokudo--;
	}


	//	//Rightボタンを押している間は右方向へ移動
	//	public void Right()
	//	{
	//		rightMove = !rightMove;
	//	}
	//	//Leftボタンを押している間は左方向へ移動
	//	public void Left()
	//	{
	//		leftMove = !leftMove;
	//	}


	//	//攻撃ボタンをおした時の処理を管理
	//	public void Attack()
	//	{
	//		//プレイヤーが直進する
	//		isStraight = true;
	//		//操作対象を後ろに並んでいるプレイヤーに変更
	//		SwhichPlayer();
	//	}


}
