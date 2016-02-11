using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;  
public class TextControl : MonoBehaviour {
	public int PlayerTalk;//說話狀態
	public GameObject RecognizeTextObj;//語音辨識物件
	public GameObject SoundArray;
/*************(櫃檯)角色動畫藍圖**************************/
	public Animator WaiterAni;//服務生動畫藍圖
	public Animator ChefAni;//老闆動畫藍圖
	public Animator PetercstomerAni;//彼得動畫藍圖
	public Animator MolycustomerAni;//茉莉動畫藍圖
/**************(櫃檯)角色動畫藍圖*************************/

	public Camera[] CameraArray;//相機陣列

/******************櫃檯角色動畫藍圖***********************/
	public GameObject Chef;//老闆
	public GameObject Waiterman;//服務生
	public GameObject Petercustomer;//彼得
	public GameObject Molycustomer;//茉莉
/******************櫃檯角色動畫藍圖***********************/


/**************(桌邊)角色動畫藍圖*************************/
	public Animator TableWaiterAni;//服務生動畫藍圖
	public Animator TableChefAni;//老闆動畫藍圖
	public Animator TablePetercustomerAni;//彼得動畫藍圖
	public Animator TableMolycustomerAni;//茉莉動畫藍圖
/**************(桌邊)角色動畫藍圖*************************/


/******************桌邊角色動畫藍圖***********************/
	public GameObject TableChef;//老闆
	public GameObject TableWaiterman;//服務生
	public GameObject TablePetercustomer;//彼得
	public GameObject TableMolycustomer;//茉莉
/******************桌邊角色動畫藍圖***********************/




	/**************對話框*********************************/
	public GameObject ChefTextObj;//老闆要講的話
	public GameObject Chefman;//老闆的角色物件
	public GameObject Customer;//顧客對話框標題
	public GameObject CustomerTextObj;//顧客要講的話
	/**************對話框*********************************/

	/***************服務生********************************/
	public GameObject Waiter;//服務生對話框標題
	public GameObject WaiterTextObj;//服務生要講的話
	/***************服務生********************************/
	public float Timer;
	public GameObject NextButton;//下一步按鈕
	public GameObject BackButton;//上一步按鈕
	public GameObject ExitButton;//退出按鈕
	public bool RecgStatus;//語音辨識狀態
	public int MusicArrayNum;//聲音陣列
	bool TimerReset;//用這個bool值偵測計時器是不是歸零了，因為要做Do Once一次
	void Start () {
		
		Chefman=GameObject.Find("廚師");//老闆的角色物件
		Chef=GameObject.Find("ChefTextObj");//老闆對話框標題
		ChefTextObj= GameObject.Find("ChefTalk");//老闆要講的話

		Customer=GameObject.Find("CustomerTextObj");//顧客對話框標題
		CustomerTextObj=GameObject.Find("CustomerTalk");//顧客要講的話

		Waiterman=GameObject.Find("服務生");//服務生的角色物件
		Waiter=GameObject.Find("WaiterTextObj");//服務生對話框標題
		WaiterTextObj=GameObject.Find("WaiterTalk");//服務生要講的話

		Petercustomer=GameObject.Find("Peter");
		Molycustomer=GameObject.Find("Moly");
		Chefman=GameObject.Find("Chef");//老闆的角色物件

		TableChef=GameObject.Find("Chef(Table)");
		TablePetercustomer=GameObject.Find("Peter(Table)");
		TableMolycustomer=GameObject.Find("Moly(Table)");


		NextButton=GameObject.Find("NextButton");//下一步
		BackButton=GameObject.Find("BackButton");//上一步
		ExitButton=GameObject.Find("ExitButton");//離開
		RecognizeTextObj=GameObject.Find("RecognizeText");//載入語音辨識物件
		SoundArray=GameObject.Find("SoundArray");//語音播放陣列
		CloseAllTextBox ();//關閉對話框以保持場面乾淨
		Timer=0.0f;
		PlayerTalk = 0;//直接跳轉到第x個switch
		CameraArray[0].gameObject.SetActive(true);//開啟櫃檯相機
		CameraArray[1].gameObject.SetActive(false);//關閉桌邊相機
	}

	void FixedUpdate () {
		Timer++;
		if (Input.GetKeyDown("space"))
			{
				PlayerTalk++;
			}
		switch (PlayerTalk) {
		
		case 0://顧客
			{
				MusicArrayNum=0;
				Call_Customer_Talk(/*顧客名*/"茉莉",/*要說的話*/"請問還有空位嗎??");
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				MolycustomerAni.SetBool ("StandIdle", true);//女角待命(站著)
				MolycustomerAni.SetBool ("HandShake", true);//女角揮手
				//---------------------------------------------------------------------------------------
				MolycustomerAni.SetBool ("HandShake", false);//女角揮手關閉
				break;
			}
		case 1://老闆
			{
				MusicArrayNum=1;
				Call_Customer_Talk(/*說話者*/"老闆",/*說話內容*/"有的，\n請問，您們是兩位用餐嗎?");
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				//---------------------------------------------------------------------------------------
				ChefAni.SetBool ("Mic", true);//接耳mic確認	
				if (Timer > 300) {
					ChefAni.SetBool ("Mic", false);//接耳mic結束
				}
			
				break;
			}

		case 2://彼得(需要辨識)
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"是的，兩位");
				
				//---------------------------------------------------------------------------------------
				SwitchRecognizeOk(/*語音辨識內容*/"是的兩位",/*錯誤時需請使用者重復之語句*/"是的，兩位");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		case 3://老闆
			{
				MusicArrayNum=2;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"好的，請往這邊。");
				ChefAni.SetBool ("PleaseFollowMe", true);//點頭鞠躬帶位true
				if (Timer > 300) {
					ChefAni.SetBool ("PleaseFollowMe", false);
				}



				break;
			}
		case 4://茱莉
			{
				MusicArrayNum=3;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"請問，\n你們有沒有套餐?");
				/*會這樣做的原因就是因為要使用切換相機來達到切換場景的目的
				  因為切換場景的時候動畫會跑掉，只好這麼做了*/
				CameraArray[1].gameObject.SetActive(true);//開啟桌邊相機
				CameraArray[0].gameObject.SetActive(false);//關閉櫃檯相機

				Molycustomer.gameObject.SetActive(false);//關閉櫃檯旁邊的茉莉
				Petercustomer.gameObject.SetActive(false);//關閉櫃檯旁邊的彼得
				Chefman.gameObject.SetActive(false);//關閉在櫃檯的廚師
				break;
			}
		case 5://老闆
			{
				MusicArrayNum=4;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"我們目前有四種套餐");
				break;
			}
		case 6://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"對不起，\n讓我們討論一下。");
				SwitchRecognizeOk(/*語音辨識內容*/"對不起讓我們討論一下",/*錯誤時需請使用者重復之語句*/"對不起，\n讓我們討論一下。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容，並返回如果錯誤時需重復的內容
				
				break;
			}
		case 7://老闆
			{
				
				MusicArrayNum=5;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"沒關係，稍後再為您服務。");
				TableChefAni.SetBool ("BackMove", true);//鞠躬後退
				if(TimerReset==false)
				{
					Timer=0.0f;//設定秒數為0
					TimerReset=true;//把偵測計時器是否歸零的bool物件回復原位，以便下次使用
				}

				if (Timer < 100) {
					TableChef.transform.Translate (Vector3.forward * -Time.deltaTime);//桌邊老闆後退
				}
				if (Timer > 120) {
					TableChefAni.SetBool ("BackMove", false);//鞠躬後退
				}
				break;
			}
		case 8://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"你要吃什麼");	
				SwitchRecognizeOk(/*語音辨識內容*/"你要吃什麼",/*錯誤時需請使用者重復之語句*/"你要吃什麼");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
				break;
			}
		case 9://茱莉
			{
				MusicArrayNum=6;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"我要點一份A套餐。\n彼得你呢?")	;			
				break;
			}
		case 10://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"我想要一份C套餐。\n它看起來不錯。");	
				SwitchRecognizeOk(/*語音辨識內容*/"我想要一份",/*錯誤時需請使用者重復之語句*/"我想要一份C套餐。\n它看起來不錯。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容			
				break;
			}
		case 11://茱莉
			{
				MusicArrayNum=7;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"OK，那就這樣決定了。");
				break;
			}
		case 12://彼得
			{
				TimerReset=false;
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"服務生，請幫我點餐");
				SwitchRecognizeOk(/*語音辨識內容*/"服務生請幫",/*錯誤時需請使用者重復之語句*/"服務生，請幫我點餐");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容			
				TablePetercustomerAni.SetBool ("ShakeHand", true);//彼得揮手

				if(TimerReset==false)
				{
					Timer=0.0f;//設定秒數為0
					TimerReset=true;//把偵測計時器是否歸零的bool物件回復原位，以便下次使用
					RecgStatus=true;
				}
				if (RecgStatus == true) 
				{
					TablePetercustomerAni.SetBool ("ShakeHand", false);//彼得揮手關閉
					TableWaiterAni.SetBool ("Walk", true);//服務生走過來
					if (Timer > 100) 
					{
						TableWaiterAni.SetBool ("Walk", false);//服務生行走停止
						Waiterman.transform.rotation = Quaternion.Euler (0, 270, 0);
						TableWaiterAni.SetBool ("EatSome", true);//服務生點餐
					}
					if (Timer > 30) 
					{
						TablePetercustomerAni.SetBool ("ShakeHand", false);//彼得揮手
					}
				}

				break;
			}
				
		case 13://服務生
			{
				MusicArrayNum=8;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"好的，為您確認一下餐點。\n一份A餐和一份C餐");
				break;
			}
		case 14://服務生
			{
				MusicArrayNum=9;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"請問飲品要餐前上還是餐後上呢");
				break;
			}
		case 15://茱莉
			{
				MusicArrayNum=10;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"我想先上飲料，\n彼得你呢?");
				break;
			}
		case 16://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"好主意，天氣蠻熱的");
				SwitchRecognizeOk(/*語音辨識內容*/"好主意天氣",/*錯誤時需請使用者重復之語句*/"好主意，天氣蠻熱的");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容			
				break;
			}
		case 17://服務生
			{
				MusicArrayNum=11;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"好的，稍後會為您上飲品。");
				break;
			}
		case 18://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"這是你點的套餐嗎");
				SwitchRecognizeOk(/*語音辨識內容*/"這是你點的",/*錯誤時需請使用者重復之語句*/"這是你點的套餐嗎");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容			
				break;
			}
		case 19://茱莉
			{
				MusicArrayNum=12;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"不，我沒點這個套餐。");
				break;
			}
		case 20://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"我也沒點這個套餐");
				SwitchRecognizeOk(/*語音辨識內容*/"我也沒點這",/*錯誤時需請使用者重復之語句*/"我也沒點這個套餐");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		//------------------------------舉手呼叫老闆&服務生靠近
		case 21://服務生
			{
				MusicArrayNum=13;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"請問有什麼需要呢");
				break;
			}
		case 22://彼得(需要辨識)
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"我們沒有\n點這兩個套餐。");
				SwitchRecognizeOk(/*語音辨識內容*/"我們沒有點",/*錯誤時需請使用者重復之語句*/"我們沒有\n點這兩個套餐。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		case 23://服務生
			{
				MusicArrayNum=14;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"請稍後，我們確認一下餐點");
				break;
			}
		case 24://服務生
			{
				MusicArrayNum=15;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"您們在這兩種套餐打上Ｘ的記號。");
				break;
			}
		case 25://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"對不起，\n我聽不懂。請您再說一次。");
				SwitchRecognizeOk(/*語音辨識內容*/"對不起我聽",/*錯誤時需請使用者重復之語句*/"對不起，\n我聽不懂。請您再說一次。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		case 26://服務生
			{
				MusicArrayNum=16;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"打差表示不要。打勾表示需要。");
				break;
			}
		case 27://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"啊！\n我們國家是用打差的記號，\n來表示我們的需要。");
				SwitchRecognizeOk(/*語音辨識內容*/"啊我們國家",/*錯誤時需請使用者重復之語句*/"啊！\n我們國家是用打差的記號，\n來表示我們的需要。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		case 28://服務生
			{
				MusicArrayNum=17;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"真的很抱歉，\n這是我們的疏失，\n我請廚師特別做了特餐，\n來補償你們。");
				break;
			}
		case 29://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"真的!感謝您");
				SwitchRecognizeOk(/*語音辨識內容*/"真的感謝您",/*錯誤時需請使用者重復之語句*/"真的!感謝您");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		case 30://服務生
			{
				MusicArrayNum=18;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"但是提醒您，\n下次請不要將需要餐點\n做打差的記號。");
				break;
			}
		case 31://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"好。我懂了");
				SwitchRecognizeOk(/*語音辨識內容*/"好我懂了",/*錯誤時需請使用者重復之語句*/"好。我懂了");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		case 32://茱莉
			{
				MusicArrayNum=19;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"這間店服務真好");
				break;
			}
		case 33://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"還需要點菜嗎");
				SwitchRecognizeOk(/*語音辨識內容*/"還需要點菜嗎",/*錯誤時需請使用者重復之語句*/"還需要點菜嗎");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		case 34://茱莉
			{
				MusicArrayNum=20;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"不，我已經很飽了");
				break;
			}
		case 35://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"我也很飽了。\n可是我很渴。\n我想加點一杯飲料。");
				SwitchRecognizeOk(/*語音辨識內容*/"我也很飽了",/*錯誤時需請使用者重復之語句*/"我也很飽了。\n可是我很渴。\n我想加點一杯飲料。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		case 36://茱莉
			{
				MusicArrayNum=21;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"我也很渴");
				break;
			}
		case 37://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"你要不要點飲料");
				SwitchRecognizeOk(/*語音辨識內容*/"你要不要點",/*錯誤時需請使用者重復之語句*/"你要不要點飲料");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		case 38://茱莉
			{
				MusicArrayNum=22;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"我不想點飲料。\n我想加點一碗湯");
				break;
			}
		case 39://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"好");
				SwitchRecognizeOk(/*語音辨識內容*/"好",/*錯誤時需請使用者重復之語句*/"好");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		case 40://茱莉
			{
				MusicArrayNum=23;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"老闆，結帳");
				break;
			}
		case 41://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"總共多少錢");
				SwitchRecognizeOk(/*語音辨識內容*/"總共多少錢",/*錯誤時需請使用者重復之語句*/"總共多少錢");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		case 42://老闆
			{
				MusicArrayNum=24;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"請稍後，讓我為您結算。");
				break;
			}
		case 43://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"請問我可以刷卡嗎");
				SwitchRecognizeOk(/*語音辨識內容*/"請問我可以",/*錯誤時需請使用者重復之語句*/"請問我可以刷卡嗎");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		case 44://老闆
			{
				MusicArrayNum=25;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"可以的。請給我你的信用卡。");
				break;
			}
		case 45://彼得
			{
				Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"請刷這張，謝謝。");
				SwitchRecognizeOk(/*語音辨識內容*/"請刷這張謝",/*錯誤時需請使用者重復之語句*/"請刷這張，謝謝。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容	
				break;
			}
		case 46://老闆
			{
				MusicArrayNum=26;
				SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"感謝您的惠顧，歡迎再次光臨。");
				break;
			}

		}
	}


public void	Call_Customer_Talk(string CustomerTitle,string CustomerText)//顧客要說的話
{
	Customer.gameObject.SetActive (true);//開啟顧客對話框
	CustomerTextObj.gameObject.SetActive (true);//顯示顧客要講話的物件
	Customer.GetComponentInChildren<Text> ().text = CustomerTitle;//說話者:顧客
	CustomerTextObj.GetComponentInChildren<Text> ().text = CustomerText;//說話內容	
}
	



public void CloseAllTextBox()//關閉所有對話框
	{
		Chef.gameObject.SetActive(false);
		ChefTextObj.gameObject.SetActive(false);
		Customer.gameObject.SetActive(false);
		CustomerTextObj.gameObject.SetActive(false);
		Waiter.gameObject.SetActive(false);
		WaiterTextObj.gameObject.SetActive(false);
	}

void ButtonUI(bool ShowNext,bool ShowBack,bool ShowExit)//按鈕控制
	{
		NextButton.gameObject.SetActive(ShowNext);//顯示下一步按鈕
		BackButton.gameObject.SetActive(ShowBack);//顯示上一步按鈕
		ExitButton.gameObject.SetActive(ShowExit);//顯示退出按鈕
	}
public void NextButtonClick()//下一步
	{
		PlayerTalk++;//玩家對話狀態+1
		CloseAllTextBox();//每次畫面刷新都先關閉所有物件
	}
public void BackButtonClick()//上一步
	{
		PlayerTalk--;//玩家對話狀態-1
		CloseAllTextBox();//每次畫面刷新都先關閉所有物件


	}
public void ExitButtonClick()//退出
	{

		PlayerTalk = 27;//離開鍵的狀態釋放區
		CloseAllTextBox();//每次畫面刷新都先關閉所有物件
	}


public void resettime()//計時器歸零
	{
		Timer=0.0f;
	}
public void ReturnCheck(bool ReturnValue)//偵測辨識結果
	{
		if (ReturnValue==true)
		{
			RecgStatus=true;
		}

		else 
		{
			RecgStatus=false;
			ButtonUI(/*顯示下一步按鈕*/false,/*顯示上一步按鈕*/true,/*顯示離開按鈕*/true);
		}

	}
public void DeleteTextMessage()//刪除所有顯示內容
{
	Call_Customer_Talk(/*說話者*/"",/*要說的話*/"");
}
public void SwitchRecognizeOk(string message,string messageContent)//比對結果
{
	RecognizeTextObj.SendMessage ("CheckRecog",message);
	if(RecgStatus==true)
	{
		Customer.GetComponentInChildren<Text> ().text ="辨識成功!!!";
		CustomerTextObj.GetComponentInChildren<Text> ().text = "";
		DeleteTextMessage ();//關閉所有對話框訊息
		PlayerTalk++;//下一步
		ButtonUI(/*顯示下一步按鈕*/true,/*顯示上一步按鈕*/true,/*顯示離開按鈕*/true);
		RecgStatus=false;
	}
	else
	{
		DeleteTextMessage ();
		Customer.GetComponentInChildren<Text> ().text ="辨識失敗，請再說一次下列語句:";
		CustomerTextObj.GetComponentInChildren<Text> ().text = messageContent;
	}
}
}


