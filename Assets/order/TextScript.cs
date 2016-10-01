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
		if (NScript.Nselect == 0 || YScript.Yselect == 0 || AScript.Aselect == 0 || KScript.Kselect == 0) {
			order.text = "未選択があります";
		}else if (NScript.Nselect == 3 && YScript.Yselect == 3 && AScript.Aselect == 3 && KScript.Kselect == 3) {
			order.text = "全マシ";
		} else if(NScript.Nselect == 4 && YScript.Yselect == 4 && AScript.Aselect == 4 && KScript.Kselect == 4){
			order.text = "全マシマシ";
		}else if(NScript.Nselect == 1 && YScript.Yselect == 1 && AScript.Aselect == 1 && KScript.Kselect == 1){
			order.text = "全ヌキ";
		}else{
			order.text = "ニンニク" + NScript.NValue + "ヤサイ" + YScript.YValue + "アブラ" + AScript.AValue + KScript.KValue;
		}
	}
}
