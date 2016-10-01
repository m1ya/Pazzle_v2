using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NScript : MonoBehaviour {

	public static string NValue;
	public static int Nselect = 0;
	void Start(){

	}

	public void ChangeValue(Dropdown dropdown)
	{
		Nselect = dropdown.value;
		switch (dropdown.value){
		case 0:
			NValue = "ヌキ";
			break;
		case 1:
			NValue = "";
			break;
		case 2:
			NValue = "マシ";
			break;
		case 3:
			NValue = "マシマシ";
			break;
		default:
			break;
		}
	}

}