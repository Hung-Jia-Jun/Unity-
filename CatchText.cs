using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
public class CatchText : MonoBehaviour {
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


public void WriteFile(string info)
   {
   	  //文件流訊息
	StreamWriter sw;
	string fileLocal="D:\\unity\\Unity_5.1_Project\\ChineseRecognize_5.3-2\\Speech recognition5.3\\Assets\\A.txt";
	FileInfo t = new FileInfo(fileLocal);
	sw = t.AppendText();
	//以行的形式寫入訊息
	sw.WriteLine(info);
	//關閉資料流
	sw.Close();
	//銷毀資料流
	sw.Dispose();
	WriteMessage=true;//已寫入資料
   }  
}
