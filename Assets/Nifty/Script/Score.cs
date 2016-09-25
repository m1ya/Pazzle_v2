using UnityEngine;
using System.Collections;
using NCMB;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
	// スコアを表示するGUIText
	//public GUIText scoreGUIText;
	public Text scoreLabel;
	// ハイスコアを表示するGUIText
	//public GUIText highScoreGUIText;

	// ハイスコアを表示するGUIText
	//public GUIText saveScoreGUIText = null;

	// スコア
	private int score;

	// ハイスコア
	private NCMB.HighScore highScore;
	//このisNewRecordがtrueの時、スコアがサーバーに送信される
	private bool isNewRecord;


	// PlayerPrefsで保存するためのキー
	//private string highScoreKey = "highScore";
	// PlayerPrefsで保存するためのキー
	private string ScoreKey = "Score";
	//public static bool isSend;
	//public static bool isPoint;

	void Start ()
	{
		Initialize ();
		// ハイスコアを取得する。保存されてなければ0点。
		string name = FindObjectOfType<UserAuth>().currentPlayer();
		highScore = new NCMB.HighScore( 0, name );
		highScore.fetch();

	}

	//変更点ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー

	//スコアを同期
	public void FetchScore()
	{
		score = highScore.score;

	}

	void Update ()
	{
		
		// スコア・ハイスコアを表示する
		scoreLabel.text = "あなたのスコアは" + score.ToString ();
		//highScoreGUIText.text = "HighScore : " + highScore.ToString ();

	}
	//スコアを追加
	public void PointUp()
	{
		score += 1;
		Debug.Log (score);
	}
	//スコアをサーバーに送信
	public void SendScore()
	{
		isNewRecord = true;
		highScore.score = score;
		Save ();
	}

	//ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー

	// ゲーム開始前の状態に戻す
	private void Initialize ()
	{
		//変更点ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
		// スコアを0に戻す必要がないためけした
		//score = 0;
		//ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
		isNewRecord = false;
		// ハイスコアを取得する。保存されてなければ0を取得する。
		// highScore = PlayerPrefs.GetInt (highScoreKey, 0);
	}

	// ポイントの追加
	public void AddPoint (int point)
	{
		score = score + point;
	}

	// ハイスコアの保存
	public void Save ()
	{
		// ハイスコアを保存する
		if (isNewRecord) {
			highScore.save ();
		}
		// ゲーム開始前の状態に戻す
		Initialize ();
	}


}