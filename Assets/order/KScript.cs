using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KScript : MonoBehaviour {

	public static string KValue;
	public static int Kselect = 0;
	void Start(){

	}

	public void ChangeValue(Dropdown dropdown)
	{	
		Kselect = dropdown.value;
		switch (dropdown.value){
		case 0:
			KValue = "";
			break;
		case 1:
			KValue = "カラメ";
			break;
		case 2:
			KValue = "カラメマシ";
			break;
		case 3:
			KValue = "カラメマシマシ";
			break;
		default:
			break;
		}
	}

}