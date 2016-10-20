using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject eater;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate (eater,this.transform.position,this.transform.rotation);
		}
	}
}
