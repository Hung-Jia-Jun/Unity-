using UnityEngine;
using System.Collections;

public class CatchText : MonoBehaviour {
	public TextAsset Atxt;//導入Txt
	public string TxtRecognize;
	void Start () 
	{
		TxtRecognize = Atxt.text;//設定要辨識的字元來自於文字檔
	}
	public void CheckRecog(string RecoText)
	{
		if (RecoText==TxtRecognize)
			{
			Debug.Log("True");
			}
		else
		{
			Debug.Log ("false");
		}
	}
}
