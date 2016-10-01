using UnityEngine;
using System.Collections;

public class LogInButton : MonoBehaviour {
	LogInManager logInManager;
	public GameObject LogObj;

	// Use this for initialization
	void Start () {
		LogObj = GameObject.Find ("LogInManager");
		logInManager = GetComponent<LogInManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LogIn()
	{
		logInManager.logInButton = true;
	}

	public void GoToSignUp()
	{
		logInManager.signUpMenuButton = true;
	}
	public void SinUp()
	{
		logInManager.signUpButton = true;
	}
	public void GoToLogIn()
	{
		logInManager.backButton = true;
	}
}
