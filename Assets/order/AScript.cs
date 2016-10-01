using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AScript : MonoBehaviour {

	public static string AValue;
	public static int Aselect = 0;
	void Start(){

	}

	public void ChangeValue(Dropdown dropdown)
	{
		Aselect = dropdown.value;
		switch (dropdown.value){
		case 0:
			AValue = "ヌキ";
			break;
		case 1:
			AValue = "";
			break;
		case 2:
			AValue = "マシ";
			break;
		case 3:
			AValue = "マシマシ";
			break;
		default:
			break;
		}
	}

}