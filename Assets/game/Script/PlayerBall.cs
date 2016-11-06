using UnityEngine;
using System.Collections;

public class PlayerBall : MonoBehaviour {
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();

	}
	void Move()
	{
		transform.Translate (new Vector3 (0,1,0) * Time.deltaTime * 2.0f);
	}
}
