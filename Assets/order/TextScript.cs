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
		//order.text = "ニンニク"+ NScript.NValue +"ヤサイ" + YScript.YValue + "アブラ" + AScript.AValue + KScript.KValue;
	}

	public void OnClick(){
		if (NScript.Nselect == 2 && YScript.Yselect == 2 && AScript.Aselect == 2 && KScript.Kselect == 2) {
			order.text = "全マシ";
		} else if(NScript.Nselect == 3 && YScript.Yselect == 3 && AScript.Aselect == 3 && KScript.Kselect == 3){
			order.text = "全マシマシ";
		}else{
			order.text = "ニンニク" + NScript.NValue + "ヤサイ" + YScript.YValue + "アブラ" + AScript.AValue + KScript.KValue;
		}
	}
}
