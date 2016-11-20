using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour {
	public static int manzokudo = 10;
	public Text manzokudoLabel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ShowManzokudo ();

	}

	void ShowManzokudo()
	{
		manzokudoLabel.text = "満足度：" + manzokudo.ToString();
	}
}
