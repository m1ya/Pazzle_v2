using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AllGameManager : MonoBehaviour {
	public static AllGameManager instance = null;
	//メニューボタン達
	public GameObject MenuCanvas;
	//シーン名
	string sceneName;

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}


	// Use this for initialization
	void Start () {
		MenuCanvas.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		sceneName = SceneManager.GetActiveScene ().name;
		//特定のシーン開始時にメニューを表示
		if (sceneName == "Map") {
			MenuCanvas.SetActive (true);
		}
	
	}
}
