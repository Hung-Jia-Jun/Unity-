using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextControl : MonoBehaviour {
	public int TalkSwitch;//說話狀態
	public GameObject[] TalkBox;//宣告說話的陣列
	// Use this for initialization
	void Start () {

		TalkBox[0] = GameObject.Find("ChefTextObj");//老闆對話框標題
		TalkBox[1] = GameObject.Find("CustomerTextObj");//顧客對話框標題
		TalkBox[2] = GameObject.Find("WaiterTextObj");//服務生對話框標題
		TalkBox[3] = GameObject.Find("ChefTalk");//老闆要講的話
		TalkBox[4] = GameObject.Find("CustomerTalk");//顧客要講的話
		TalkBox[5] = GameObject.Find("WaiterTalk");//服務生要講的話
		CloseAllTextBox ();//關閉對話框以保持場面乾淨
	}
	
	// Update is called once per frame
	void Update () {
		switch (TalkSwitch)
		{
			case 0:
			{
				TalkBox[1].gameObject.SetActive(true);//開啟顧客對話框
				TalkBox[4].gameObject.SetActive(true);//開啟顧客要講話的物件
				TalkBox[1].GetComponentInChildren<Text>().text="茉莉";
				TalkBox[4].GetComponentInChildren<Text>().text="請問還有空位嗎??";
				break;
			}
			case 1:
			{
				TalkBox[1].gameObject.SetActive(true);//開啟顧客對話框
				TalkBox[4].gameObject.SetActive(true);//開啟顧客要講話的物件
				TalkBox[1].GetComponentInChildren<Text>().text="茉莉";
				TalkBox[4].GetComponentInChildren<Text>().text="請問還有空位嗎??";
				break;
			}
			
			
		}

	}
	void CloseAllTextBox()//關閉所有對話框
	{
		for (int i = 0; i <= 6;i++ )
		{
			TalkBox[i].gameObject.SetActive(false);
			
			// TextBox[i].gameObject.SetActive(false);//關閉所有對話框
			//   Currect.SetActive(false);//關閉正確的Text字樣
			// False.SetActive(false);//關閉錯誤的Text字樣
		}
		
	}








}
