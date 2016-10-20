using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3(1.5f, 0f, 0f) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position -= new Vector3(1.5f, 0f, 0f) * Time.deltaTime;
		}


	}
}
