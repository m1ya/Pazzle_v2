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
		case 1:
			AValue = "ヌキ";
			break;
		case 2:
			AValue = "";
			break;
		case 3:
			AValue = "マシ";
			break;
		case 4:
			AValue = "マシマシ";
			break;
		default:
			break;
		}
	}

}