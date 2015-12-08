using UnityEngine;
using System.Collections;

public class HTTPopen : MonoBehaviour 
{
	public string[] SourceCode;
	public bool isDone;

	public string FindString="[null,2,";// 設定字串特徵符

	void Start ()
	{

		Application.OpenURL ("http://ppt.cc/zXlGe");//先開啟Google 語音辨識的Api網頁

	
	}
	void Update()
	{


		StartCoroutine(GetWebData());//每個Frame都抓取網頁上的資訊

	}
	IEnumerator GetWebData()
	{
		WWW GetData = new WWW("https://docs.google.com/spreadsheets/d/1818QkfLUynh439hXVakcNcP3LgcxgLvYkKEJcmWRBwk/edit#gid=151856841");//宣告GetData="http://ppt.cc/zXlGe"
		yield return new WaitForSeconds(1);//等待1秒
		SourceCode[0]=GetData.text;//將網頁上的Data寫進SourceCode字串內

		if (GetData.error!=null)//如果讀取不到網頁資料
		{
			Debug.Log(GetData.error);//顯示錯誤

		}
		else 
		{
			Debug.Log (SourceCode);//印出網頁原始碼
		}
		//if (FindString in SourceCode)Debug.Log (SourceCode);
		

	}
	

	
}
