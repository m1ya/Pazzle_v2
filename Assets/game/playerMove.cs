using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			this.transform.Translate (0, 0.1f, 0);
		}

	void OnCollisionEnter(Collision collison){
		Destroy (this.gameObject);
		Destroy (collison.gameObject);
	}
	}
