using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DDScript : MonoBehaviour {


	void Start(){
		
	}

	public void ChangeValue(Dropdown dropdown)
	{
		switch (dropdown.value){
		case 0:
			Debug.Log ("0");
			break;
		case 1:
			Debug.Log ("1");
			break;
		case 2:
			Debug.Log ("2");
			break;
		default:
			break;
		}
	}

}