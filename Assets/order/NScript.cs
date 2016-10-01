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
		case 1:
			NValue = "ヌキ";
			break;
		case 2:
			NValue = "";
			break;
		case 3:
			NValue = "マシ";
			break;
		case 4:
			NValue = "マシマシ";
			break;
		default:
			break;
		}
	}

}