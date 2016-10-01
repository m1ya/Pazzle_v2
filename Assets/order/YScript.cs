using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YScript : MonoBehaviour {

	public static string YValue;
	public static int Yselect = 0;
	void Start(){

	}

	public void ChangeValue(Dropdown dropdown)
	{
		Yselect = dropdown.value;
		switch (dropdown.value){
		case 1:
			YValue = "ヌキ";
			break;
		case 2:
			YValue = "";
			break;
		case 3:
			YValue = "マシ";
			break;
		case 4:
			YValue = "マシマシ";
			break;
		default:
			break;
		}
	}

}