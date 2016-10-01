using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void GameStart()
	{
		SceneManager.LoadScene ("LogIn");
	}

	public void GoRanking()
	{
		SceneManager.LoadScene ("LeaderBoard");
	}

	public void Order()
	{
		SceneManager.LoadScene ("order");
	}
	public void GoMap()
	{
		SceneManager.LoadScene("Map");
	}
	public void GoGame()
	{
		SceneManager.LoadScene ("game");
	}

}
