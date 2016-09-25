using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public Text label;
	public RawImage img;

	private LocationService GPS;
	private float lat, lng;
	private WWW dlImage;

	void Start () {
		GPS = Input.location;

		if (GPS.isEnabledByUser)
		{
			// GPSの測位を開始する
			GPS.Start();

			// 5秒おきにGPS情報を取得する
			InvokeRepeating("GetLocation", 0, 5);
		}
		else
		{
			// GPSにアクセスできない
			label.text = "GPS不許可";
		}

		// まずはダミー位置情報で読み込む
		lat = 35.655427f;
		lng = 139.693722f;
	
		StartCoroutine(GetMapImage());
	}
		
	void Update () {
	}


	//アプリ終了時に呼ばれるメソッド
	void onDisable()
	{
		// アプリ終了時にGPSを停止する（電池節約）
		GPS.Stop();
	}

	//位置情報更新用のメソッド
	void GetLocation()
	{
		switch (GPS.status)
		{
		case LocationServiceStatus.Failed:
			// GPS取得失敗
			label.text = "取得失敗";
			CancelInvoke("GetLocation");
			break;

		case LocationServiceStatus.Initializing:
			// まだ準備中
			label.text = "取得中…";
			break;

		case LocationServiceStatus.Running:
			// GPS利用可能
			var data = GPS.lastData;
			if (lat != data.latitude || lng != data.longitude)
			{
				// 前回と位置が違うなら地図更新
				lat = data.latitude;
				lng = data.longitude;
				StartCoroutine(GetMapImage());
			}
			break;
		}
	}

	//地図を取得するメソッド
	IEnumerator GetMapImage()
	{
		label.text = string.Format("緯度:{0:f6}\n経度:{1:f6}", lat, lng);

		// URLを生成
		var url = "http://maps.googleapis.com/maps/api/staticmap";
		url += string.Format("?center={0},{1}", lat, lng);
		url += "&zoom=14&size=400x300&scale=2&maptype=roadmap&sensor=true";
		url += string.Format("&markers={0},{1}", lat, lng);
		Debug.Log(url);

		// ダウンロード
		dlImage = new WWW(url);
		yield return dlImage;

		// 画像として読み込む
		img.texture = dlImage.texture;

		// 注意事項：Google Maps Static APIの頻度制限
		// 同一IPアドレスで、1分間に50回 or 1時間に1000回まで
	}
}