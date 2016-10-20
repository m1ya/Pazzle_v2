using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {

	public GameObject enemy; //敵のオブジェクト
	public float interval = 5; //何秒に一回敵を発生させるか
	float timer = 0; //タイマー
	float RanRange = 0;

	void Update () {
		timer -= Time.deltaTime; //タイマーを減らす
		if (timer < 0) { //タイマーがゼロより小さくなったら
			Spawn (); // Spawnメソッドを呼ぶ
			timer = interval; // タイマーをリセットする
		}
	}
	// 敵を生成するメソッド
	void Spawn(){
		RanRange = Random.Range (-2.5f, 2.5f);
		Vector3 pos = transform.position;
		pos.x += RanRange;
		Instantiate (enemy,pos, transform.rotation);
		pos.x -= RanRange;
	}
}

