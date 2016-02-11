using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
public class Scence1CatchRecog : MonoBehaviour {
	public TextAsset Atxt;//導入Txt
	public string TxtRecognize;
	public GameObject SceneControl;
	public bool WriteMessage;//設定要寫入的訊息是否成功
	void Start()
	{
		SceneControl=GameObject.Find("SceneControl");
	}
void FixedUpdate()
	{
		TxtRecognize = Atxt.text;//設定要辨識的字元來自於文字檔
	}
public void CheckRecog(string RecoText)//語音檢測
{
bool Status;
/*************************不管使用者說哪句都會通過*****************************/
if(TxtRecognize=="我要一間大")//我要一間大街風景房
    {
		Status = true;
		SceneControl.SendMessage ("ReturnCheck",Status);
    }
if(TxtRecognize=="我要一間日")//我要一間日月潭美景房
    {
		Status = true;
		SceneControl.SendMessage ("ReturnCheck",Status);
    }
if(TxtRecognize=="我要付現金")//我要一間日月潭美景房
    {
		Status = true;
		SceneControl.SendMessage ("ReturnCheck",Status);
    }
if(TxtRecognize=="我要刷卡請")//我要一間日月潭美景房
    {
		Status = true;
		SceneControl.SendMessage ("ReturnCheck",Status);
    }
if(TxtRecognize=="我要手機支")//我要一間日月潭美景房
    {
		Status = true;
		SceneControl.SendMessage ("ReturnCheck",Status);
    }

/*************************不管使用者說哪句都會通過*****************************/
if (RecoText == TxtRecognize)
	{
		Status = true;
		SceneControl.SendMessage ("ReturnCheck",Status);
	}
	
else
    {
		Status = false;
		SceneControl.SendMessage ("ReturnCheck",Status);
	}
	
}
}
