using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class zoomControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ButtonPushPlus() {
		GameManager.zoom += 1;
		GameManager.lng += 0.00001f;
	}
	public void ButtonPushMinus() {
		GameManager.zoom -= 1;
		GameManager.lng += 0.00001f;
	}

}
