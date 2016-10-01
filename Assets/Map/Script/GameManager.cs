using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public Text label;
	public RawImage img;
	public static int zoom = 13;
	public static float lat, lng;

	public Text Nearest;
	private float ND;
	public GameObject Button;

	private LocationService GPS;
	private float[] lati = new float[40];
	private float[] lngi = new float[40];
	private float[] dis = new float[40];
	private string[] name = new string[40];
	private WWW dlImage;

	void Start () {
		GPS = Input.location;

		if (GPS.isEnabledByUser)
		{
			// GPSの測位を開始する
			GPS.Start();

			// 秒おきにGPS情報を取得する
			InvokeRepeating("GetLocation", 0, 1);
		}
		else
		{
			// GPSにアクセスできない
			label.text = "GPS不許可";
		}

		// ジロッカソン会場
		lat = 35.655427f;
		lng = 139.693722f;

		//ラーメン二郎 三田本店
		lati[1] = 35.648080f;
		lngi[1] = 139.74161f;
		name[1] = "三田本店";
		// 目黒店
		lati[2] = 35.634192f;
		lngi[2] = 139.707051f;
		//仙川店
		lati[3] = 35.661771f;
		lngi[3] = 139.583891f;
		//鶴見店
		lati[4] = 35.497077f;
		lngi[4] = 139.661272f;
		//歌舞伎町店
		lati[5] = 35.695807f;
		lngi[5] = 139.701919f;
		//品川店
		lati[6] = 35.623913f;
		lngi[6] = 139.743029f;
		//新宿小滝橋通店
		lati[7] = 35.696328f;
		lngi[7] = 139.698338f;
		//環七新代田店
		lati[8] = 35.661973f;
		lngi[8] = 139.660427f;
		//八王子野猿街道店２
		lati[9] = 35.629515f;
		lngi[9] = 139.401367f;
		//池袋東口店
		lati[10] = 35.728281f;
		lngi[10] = 139.713856f;
		//新小金井街道店
		lati[11] = 35.708436f;
		lngi[11] = 139.496208f;
		//亀戸店
		lati[12] = 35.701934f;
		lngi[12] = 139.826678f;
		//京急川崎店
		lati[13] = 35.534902f;
		lngi[13] = 139.705734f;
		//府中店
		lati[14] = 35.672048f;
		lngi[14] = 139.477253f;
		//高田馬場店
		lati[15] = 35.715480f;
		lngi[15] = 139.706601f;
		//松戸駅前店
		lati[16] = 35.786002f;
		lngi[16] = 139.899416f;
		//めじろ台法政大学前店
		lati[17] = 35.629483f;
		lngi[17] = 139.310357f;
		//荻窪店
		lati[18] = 35.703593f;
		lngi[18] = 139.626289f;
		//上野毛店
		lati[19] = 35.612421f;
		lngi[19] = 139.638978f;
		//京成大久保店
		lati[20] = 35.691485f;
		lngi[20] = 140.049615f;
		//環七一之江店
		lati[21] = 35.684088f;
		lngi[21] = 139.881951f;
		//相模大野店
		lati[22] = 35.529931f;
		lngi[22] = 139.432934f;
		//横浜関内店
		lati[23] = 35.442139f;
		lngi[23] = 139.630704f;
		//神田神保町店
		lati[24] = 35.696378f;
		lngi[24] = 139.756470f;
		//小岩店
		lati[25] = 35.734954f;
		lngi[25] = 139.880010f;
		//ひばりヶ丘駅前店
		lati[26] = 35.750010f;
		lngi[26] = 139.543796f;
		//桜台駅前店
		lati[27] = 35.738807f;
		lngi[27] = 139.661859f;
		//栃木街道店
		lati[28] = 36.422875f;
		lngi[28] = 139.794880f;
		//立川店
		lati[29] = 35.696508f;
		lngi[29] = 139.409527f;
		//大宮店
		lati[30] = 35.903440f;
		lngi[30] = 139.626285f;
		//千住大橋駅前店
		lati[31] = 35.742594f;
		lngi[31] = 139.797004f;
		//茨城守谷店
		lati[32] = 35.924050f;
		lngi[32] = 140.000579f;
		//湘南藤沢店
		lati[33] = 35.742594f;
		lngi[33] = 139.797004f;
		//西台駅前店
		lati[34] = 35.786884f;
		lngi[34] = 139.674810f;
		//中山駅前店
		lati[35] = 35.513074f;
		lngi[35] = 139.538620f;
		//新橋店
		lati[36] = 35.665626f;
		lngi[36] = 139.750571f;
		//仙台店
		lati[37] = 38.261696f;
		lngi[37] = 140.866129f;
		//赤羽店
		lati[38] = 35.779820f;
		lngi[38] = 139.720836f;

		StartCoroutine(GetMapImage());
	}
		
	void Update () {
		Debug.Log(zoom);
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

				//二郎と自分の距離を測る
				for(int i = 1; i < 40 ; i++){
					dis[i] = distance(lat,lati[i],lng,lngi[i]);
				}

				//最短距離の店舗を探索
				int prei = 1;
				for (int i = 1; i < 40; i++) {
						if (dis[prei] > dis [i]) {
							prei = i;
						}
				}

				//最短距離の店舗名を表示
				string Near = name[prei];
				Nearest.text = "最寄りは" + Near;

				//距離の判定(50m以内にあれば)
				if (dis [prei] <= 50) {
					Button.GetComponent<Button> ().enabled = true;
				} else {
					Button.GetComponent<Button> ().enabled = false;
				}

			}
			break;
		}
	}

	float distance (float P1,float P2,float R1,float R2){
		float Pa = (P1 + P2) / 2;               				//２点の平均緯度
		float dP=P1-P2;  			   							//２点の緯度差
		float dR=R1-R2;								        	//２点の経度差
		float M=6334834/ Mathf.Sqrt(((1-0.006674f* Mathf.Sin(Pa))*(1-0.006674f* Mathf.Sin(Pa)))*((1-0.006674f* Mathf.Sin(Pa))*(1-0.006674f* Mathf.Sin(Pa)))*((1-0.006674f* Mathf.Sin(Pa))*(1-0.006674f* Mathf.Sin(Pa))));	//子午線曲率半径 
		float N=6377397/ Mathf.Sqrt((1-0.006674f* Mathf.Sin(Pa))*(1-0.006674f* Mathf.Sin(Pa)));	    //卯酉線曲率半径 

		float S = Mathf.Sqrt (((M * dP)*(M * dP) + (N *  Mathf.Cos (Pa) * dR))*((M * dP)*(M * dP) + (N *  Mathf.Cos (Pa) * dR)));
		return S;
	}


	//地図を取得するメソッド
	IEnumerator GetMapImage()
	{
		label.text = string.Format("緯度:{0:f6}\n経度:{1:f6}", lat, lng);

		// URLを生成
		var url = "http://maps.googleapis.com/maps/api/staticmap";
		url += string.Format("?center={0},{1}", lat, lng);
		url += "&zoom=" + zoom.ToString ();
		url += "&size=750x1334&scale=2&maptype=roadmap&sensor=true";
		url += string.Format("&markers={0},{1}", lat, lng);
		url += string.Format("&markers={0},{1}", lati[1], lngi[1]);
		url += string.Format("&markers={0},{1}", lati[2], lngi[2]);
		url += string.Format("&markers={0},{1}", lati[3], lngi[3]);
		url += string.Format("&markers={0},{1}", lati[4], lngi[4]);
		url += string.Format("&markers={0},{1}", lati[5], lngi[5]);
		url += string.Format("&markers={0},{1}", lati[6], lngi[6]);
		url += string.Format("&markers={0},{1}", lati[7], lngi[7]);
		url += string.Format("&markers={0},{1}", lati[8], lngi[8]);
		url += string.Format("&markers={0},{1}", lati[9], lngi[9]);
		url += string.Format("&markers={0},{1}", lati[10], lngi[10]);
		url += string.Format("&markers={0},{1}", lati[11], lngi[11]);
		url += string.Format("&markers={0},{1}", lati[12], lngi[12]);
		url += string.Format("&markers={0},{1}", lati[13], lngi[13]);
		url += string.Format("&markers={0},{1}", lati[14], lngi[14]);
		url += string.Format("&markers={0},{1}", lati[15], lngi[15]);
		url += string.Format("&markers={0},{1}", lati[16], lngi[16]);
		url += string.Format("&markers={0},{1}", lati[17], lngi[17]);
		url += string.Format("&markers={0},{1}", lati[18], lngi[18]);
		url += string.Format("&markers={0},{1}", lati[19], lngi[19]);
		url += string.Format("&markers={0},{1}", lati[20], lngi[20]);
		url += string.Format("&markers={0},{1}", lati[21], lngi[21]);
		url += string.Format("&markers={0},{1}", lati[22], lngi[22]);
		url += string.Format("&markers={0},{1}", lati[23], lngi[23]);
		url += string.Format("&markers={0},{1}", lati[24], lngi[24]);
		url += string.Format("&markers={0},{1}", lati[25], lngi[25]);
		url += string.Format("&markers={0},{1}", lati[26], lngi[26]);
		url += string.Format("&markers={0},{1}", lati[27], lngi[27]);
		url += string.Format("&markers={0},{1}", lati[28], lngi[28]);
		url += string.Format("&markers={0},{1}", lati[29], lngi[29]);
		url += string.Format("&markers={0},{1}", lati[30], lngi[30]);
		url += string.Format("&markers={0},{1}", lati[31], lngi[31]);
		url += string.Format("&markers={0},{1}", lati[32], lngi[32]);
		url += string.Format("&markers={0},{1}", lati[33], lngi[33]);
		url += string.Format("&markers={0},{1}", lati[34], lngi[34]);
		url += string.Format("&markers={0},{1}", lati[35], lngi[35]);
		url += string.Format("&markers={0},{1}", lati[36], lngi[36]);
		url += string.Format("&markers={0},{1}", lati[37], lngi[37]);
		url += string.Format("&markers={0},{1}", lati[38], lngi[38]); 
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