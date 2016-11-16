using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {


	private Rigidbody Erb;
	bool SiMo;
	Vector3 Position;
	float tmpX;

	// Use this for initialization
	void Start () {
		Erb = this.GetComponent<Rigidbody>();
		//前方向への速度付与
		Erb.velocity = transform.up * -0.5f;
		SiMo = true;


		}
	
	// Update is called once per frame
	void Update () {
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



	/*　　　　　できればまとめたかった
	    void EnemySideMove(){
		Rigidbody Obj = this.GetComponent<Rigidbody>();
		var Position = this.transform.position;
		float tmpX = Random.Range (-2.4f, 2.5f);
		Debug.Log (tmpX);
		Position.x = tmpX - Position.x;
		Debug.Log (Mathf.Sign (Position.x));
		if (Mathf.Sign (Position.x) == 1) {
			Obj.velocity += transform.right * 0.3f;
			if (Position.x <= tmpX) {
				Debug.Log ("Enter1");
				//EnemySideMove ();
				Obj.velocity -= transform.right * 0.3f;
			}
		} else if (Mathf.Sign (Position.x) == -1) {
			Obj.velocity -= transform.right * 0.3f;
			if (Position.x >= tmpX) {
				//EnemySideMove ();
				Debug.Log ("Enter2");
				Obj.velocity += transform.right * 0.3f;
			}
		}
	}
	*/
}
