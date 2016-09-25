using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

	public Text order;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		order.text = "ニンニク"+ NScript.NValue +"ヤサイ" + YScript.YValue + "アブラ" + AScript.AValue;
	}
}
