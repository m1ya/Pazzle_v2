using UnityEngine;
using System.Collections;

public class TestSousin : MonoBehaviour {
	GameObject scoreManager;
	Score sc;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.Find ("ScoreManager");
		sc = scoreManager.GetComponent<Score> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void PointUp()
	{
		sc.PointUp ();
	}
	public void Sousin()
	{
		sc.SendScore ();
	}
}
