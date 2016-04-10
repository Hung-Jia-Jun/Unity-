using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
public class TextControl : MonoBehaviour {
	public int PlayerTalk;//說話狀態
	public GameObject RecognizeTextObj;//語音辨識物件
	public GameObject German_SoundArray;
	public bool noChinese;
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
		German_SoundArray=GameObject.Find("German_SoundArray");//語音播放陣列
		CloseAllTextBox ();//關閉對話框以保持場面乾淨
		Timer=0.0f;
		PlayerTalk = 0;//直接跳轉到第x個switch
		CameraArray[0].gameObject.SetActive(true);//開啟櫃檯相機
		CameraArray[1].gameObject.SetActive(false);//關閉桌邊相機
	}

	void FixedUpdate () {
		Timer++;
		if (Input.GetKeyDown("s"))
			{
				PlayerTalk++;
			}
		switch (PlayerTalk) {

		case 0://顧客
			{
				if (noChinese==false)
				{
					MusicArrayNum=0;
					Call_Customer_Talk(/*顧客名*/"茉莉",/*要說的話*/"請問還有空位嗎??");
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					MolycustomerAni.SetBool ("StandIdle", true);//女角待命(站著)
					MolycustomerAni.SetBool ("HandShake", true);//女角揮手
					//---------------------------------------------------------------------------------------
					MolycustomerAni.SetBool ("HandShake", false);//女角揮手關閉
					break;
				}
				else
				{
					MusicArrayNum=27+0;
					Call_Customer_Talk(/*顧客名*/"茉莉",/*要說的話*/"Entschuldigung.Sind noch Plätze frei?");
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					MolycustomerAni.SetBool ("StandIdle", true);//女角待命(站著)
					MolycustomerAni.SetBool ("HandShake", true);//女角揮手
					//---------------------------------------------------------------------------------------
					MolycustomerAni.SetBool ("HandShake", false);//女角揮手關閉
					break;
				}
			}
		case 1://老闆
			{
				if (noChinese==false)
				{
					MusicArrayNum=1;
					Call_Customer_Talk(/*說話者*/"老闆",/*說話內容*/"有的，\n請問，您們是兩位用餐嗎?");
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					//---------------------------------------------------------------------------------------
					ChefAni.SetBool ("Mic", true);//接耳mic確認
					if (Timer > 300) {
						ChefAni.SetBool ("Mic", false);//接耳mic結束
					}

					break;
				}
				else
				{
					MusicArrayNum=27+1;
					Call_Customer_Talk(/*說話者*/"老闆",/*說話內容*/"Ja, sind Sie zu zweit?");
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					//---------------------------------------------------------------------------------------
					ChefAni.SetBool ("Mic", true);//接耳mic確認
					if (Timer > 300) {
						ChefAni.SetBool ("Mic", false);//接耳mic結束
					}

					break;
				}


			}
		case 2://彼得(需要辨識)
			{
				if (noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"是的，兩位");

					//---------------------------------------------------------------------------------------
					SwitchRecognizeOk(/*語音辨識內容*/"是的兩位",/*錯誤時需請使用者重復之語句*/"是的，兩位");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Ja, zu zweit.");

					//---------------------------------------------------------------------------------------
					SwitchRecognizeOk(/*語音辨識內容*/"Ja zu zweit",/*錯誤時需請使用者重復之語句*/"Ja, zu zweit.");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				
			}
		case 3://老闆
			{
				if (noChinese==false)
				{
					MusicArrayNum=2;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"好的，請往這邊。");
					ChefAni.SetBool ("PleaseFollowMe", true);//點頭鞠躬帶位true
					if (Timer > 300) {
						ChefAni.SetBool ("PleaseFollowMe", false);
					}
					break;

				}
				else
				{
					MusicArrayNum=27+2;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"Ja, hier bitte.");
					ChefAni.SetBool ("PleaseFollowMe", true);//點頭鞠躬帶位true
					if (Timer > 300) {
						ChefAni.SetBool ("PleaseFollowMe", false);
					}
					break;

				}

			}
		case 4://茱莉
			{
				if (noChinese==false)
				{
					MusicArrayNum=3;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
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
				else
				{
					MusicArrayNum=27+3;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"Haben Sie ein Menü?");
					/*會這樣做的原因就是因為要使用切換相機來達到切換場景的目的
					  因為切換場景的時候動畫會跑掉，只好這麼做了*/
					CameraArray[1].gameObject.SetActive(true);//開啟桌邊相機
					CameraArray[0].gameObject.SetActive(false);//關閉櫃檯相機
					Molycustomer.gameObject.SetActive(false);//關閉櫃檯旁邊的茉莉
					Petercustomer.gameObject.SetActive(false);//關閉櫃檯旁邊的彼得
					Chefman.gameObject.SetActive(false);//關閉在櫃檯的廚師
					break;

				}
			}
		case 5://老闆
			{
				if (noChinese==false)
				{
					MusicArrayNum=4;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"我們目前有四種套餐");
					break;

				}
				else
				{
					MusicArrayNum=27+4;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"Ja, wir haben vier verschiedene Menüs.");
					break;

				}
			}
		case 6://彼得
			{
				if(noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"對不起，\n讓我們討論一下。");
					SwitchRecognizeOk(/*語音辨識內容*/"對不起讓我們討論一下",/*錯誤時需請使用者重復之語句*/"對不起，\n讓我們討論一下。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Entschuldigung, Warten Sie mal.Lassen Sie uns Zeit zu diskutieren.");
					SwitchRecognizeOk(/*語音辨識內容*/"Entschuldigung Warten Sie mal Lassen Sie uns Zeit zu diskutieren",/*錯誤時需請使用者重復之語句*/"Entschuldigung Warten Sie mal Lassen Sie uns Zeit zu diskutieren");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容，並返回如果錯誤時需重復的內容
					break;
				}
			}
		case 7://老闆
			{
				if (noChinese==false)
				{
					MusicArrayNum=5;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"沒關係，稍後再為您服務。");
					TableChefAni.SetBool ("BackMove", true);//鞠躬後退
					if(TimerReset==false)
					{
						Timer=0.0f;//設定秒數為0
						TimerReset=true;//把偵測計時器是否歸零的bool物件回復原位，以便下次使用
					}
					if (Timer > 130)
					{
					TableChefAni.SetBool ("BackMove", false);//鞠躬後退
					}
					if (Timer < 100)
					{
						TableChef.transform.Translate (Vector3.forward * -Time.deltaTime);//桌邊老闆後退
					}
					break;

				}
				else
				{
					MusicArrayNum=27+5;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"Das macht nichts.");
					TableChefAni.SetBool ("BackMove", true);//鞠躬後退
					if(TimerReset==false)
					{
						Timer=0.0f;//設定秒數為0
						TimerReset=true;//把偵測計時器是否歸零的bool物件回復原位，以便下次使用
					}
					if (Timer > 130)
					{
					TableChefAni.SetBool ("BackMove", false);//鞠躬後退
					}
					if (Timer < 100)
					{
						TableChef.transform.Translate (Vector3.forward * -Time.deltaTime);//桌邊老闆後退
					}
					break;

				}
			}
		case 8://彼得
			{
				if(noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"你要吃什麼");
					SwitchRecognizeOk(/*語音辨識內容*/"你要吃什麼",/*錯誤時需請使用者重復之語句*/"你要吃什麼");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Was willst du essen");
					SwitchRecognizeOk(/*語音辨識內容*/"Was willst du essen",/*錯誤時需請使用者重復之語句*/"Was willst du essen");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
			}
		case 9://茱莉
			{
				if (noChinese==false)
				{
					MusicArrayNum=6;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"我要點一份A套餐。\n彼得你呢?")	;
					break;

				}
				else
				{
					MusicArrayNum=27+6;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"Ich werde das Menü A bestellen. Und du?")	;
					break;

				}
			}
		case 10://彼得
			{
				if(noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"我想要一份C套餐。\n它看起來不錯。");
					SwitchRecognizeOk(/*語音辨識內容*/"我想要一份C套餐它看起來不錯",/*錯誤時需請使用者重復之語句*/"我想要一份C套餐。\n它看起來不錯。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"我想要一份C套餐。\n它看起來不錯。");
					SwitchRecognizeOk(/*語音辨識內容*/"Ich werde ein Menü bestellen Es sieht gut aus",/*錯誤時需請使用者重復之語句*/"Ich werde ein Menü bestellen Es sieht gut aus");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
			}
		case 11://茱莉
			{
				if (noChinese==false)
				{
					MusicArrayNum=7;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"OK，那就這樣決定了。");
					break;

				}
				else
				{
					MusicArrayNum=27+7;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"In Ordnung. Es wird so entschieden.");
					break;

				}
			}
		case 12://彼得
			{
				if(noChinese==false)
				{
					StartCoroutine(WaiterMoveAni(2));//製作一個協程播放服務生走路動畫
					//TimerReset=false;
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"服務生，請幫我點餐");
					SwitchRecognizeOk(/*語音辨識內容*/"服務生請幫我點餐",/*錯誤時需請使用者重復之語句*/"服務生，請幫我點餐");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					TablePetercustomerAni.SetBool ("ShakeHand", true);//彼得揮手
					break;
				}
				else
				{
					StartCoroutine(WaiterMoveAni(2));//製作一個協程播放服務生走路動畫
					//TimerReset=false;
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Herr Ober, ich möchte bestellen.");
					SwitchRecognizeOk(/*語音辨識內容*/"Herr Ober ich möchte bestellen",/*錯誤時需請使用者重復之語句*/"Herr Ober, ich möchte bestellen.");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					TablePetercustomerAni.SetBool ("ShakeHand", true);//彼得揮手
					break;
				}
			}

		case 13://服務生
			{
				if (noChinese==false)
				{
					MusicArrayNum=8;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"好的，為您確認一下餐點。\n一份A餐和一份C餐");
					break;

				}
				else
				{
					MusicArrayNum=27+8;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"Gut, stellen Sie fest, was\n Sie bestellt haben.\nEin A Menü und ein C Menü.");
					break;

				}
			}
		case 14://服務生
			{
				if (noChinese==false)
				{
					MusicArrayNum=9;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"請問飲品要餐前上還是餐後上呢");
					break;

				}
				else
				{
					MusicArrayNum=27+9;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"Entschuldigen, wollen Sie \nzunächst trinken oder \nzunächst essen?");
					break;

				}
			}
		case 15://茱莉
			{
				if (noChinese==false)
				{
					MusicArrayNum=10;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"我想先上飲料，\n彼得你呢?");
					break;

				}
				else
				{
					MusicArrayNum=27+10;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"Wir trinken zunächst etwas. Wie denkst Du?");
					break;

				}
			}
		case 16://彼得
			{
				if(noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"好主意，天氣蠻熱的");
					SwitchRecognizeOk(/*語音辨識內容*/"好主意天氣蠻熱的",/*錯誤時需請使用者重復之語句*/"好主意，天氣蠻熱的");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Eine gute Idee Es ist sehr warm");
					SwitchRecognizeOk(/*語音辨識內容*/"Eine gute Idee Es ist sehr warm",/*錯誤時需請使用者重復之語句*/"Eine gute Idee Es ist sehr warm");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
			}
		case 17://服務生
			{
				if (noChinese==false)
				{
					MusicArrayNum=11;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"好的，稍後會為您上飲品。");
					StartCoroutine(WaiterLeaf(2));//呼叫服務生離開的協程
					break;

				}
				else
				{
					MusicArrayNum=27+11;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"Gut, wir bringen Ihnen zunächst das Getränke.");
					StartCoroutine(WaiterLeaf(2));//呼叫服務生離開的協程
					break;

				}
			}
		case 18://彼得
			{
				if(noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"這是你點的套餐嗎");
					SwitchRecognizeOk(/*語音辨識內容*/"這是你點的套餐嗎",/*錯誤時需請使用者重復之語句*/"這是你點的套餐嗎");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Ist das das Menü, was du bestellt hast?");
					SwitchRecognizeOk(/*語音辨識內容*/"Ist das das Menü was du bestellt hast",/*錯誤時需請使用者重復之語句*/"Ist das das Menü, was du bestellt hast?");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
			}
		case 19://茱莉
			{
				if (noChinese==false)
				{
					MusicArrayNum=12;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"不，我沒點這個套餐。");
					break;

				}
				else
				{
					MusicArrayNum=27+12;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"Nein, das Essen habe ich nicht bestellt.");
					break;

				}
			}
		case 20://彼得
			{
				if(noChinese==false)
				{
					StartCoroutine(WaiterMovetoCustomer(2));
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"我也沒點這個套餐");
					SwitchRecognizeOk(/*語音辨識內容*/"我也沒點這個套餐",/*錯誤時需請使用者重復之語句*/"我也沒點這個套餐");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					TablePetercustomerAni.SetBool ("ShakeHand", true);//彼得揮手開啟
					break;
				}
				else
				{
					StartCoroutine(WaiterMovetoCustomer(2));
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Ich habe das Essen auch nicht bestellt.");
					SwitchRecognizeOk(/*語音辨識內容*/"Ich habe das Essen auch nicht bestellt",/*錯誤時需請使用者重復之語句*/"Ich habe das Essen auch nicht bestellt.");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					TablePetercustomerAni.SetBool ("ShakeHand", true);//彼得揮手開啟
					break;
				}
			}
		//------------------------------舉手呼叫老闆&服務生靠近
		case 21://服務生
			{
				if (noChinese==false)
				{
					MusicArrayNum=13;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"請問有什麼需要呢");
					break;

				}
				else
				{
					MusicArrayNum=27+13;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"Mein lieber Kunde, wie kann ich Ihnen helfen?");
					break;

				}
			}
		case 22://彼得(需要辨識)
			{
				if (noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"我們沒有\n點這兩個套餐。");
					SwitchRecognizeOk(/*語音辨識內容*/"我們沒有點",/*錯誤時需請使用者重復之語句*/"我們沒有\n點這兩個套餐。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Diese beiden Menüs haben ");
					SwitchRecognizeOk(/*語音辨識內容*/"Diese beiden Menüs haben",/*錯誤時需請使用者重復之語句*/"Diese beiden Menüs haben ");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
			}
		case 23://服務生
			{
				if (noChinese==false)
				{
					MusicArrayNum=14;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"請稍後，我們確認一下餐點");
					break;

				}
				else
				{
					MusicArrayNum=27+14;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"Warten Sie mal, wir werden Ihre Bestellung feststellen.");
					break;

				}
			}
		case 24://服務生
			{
				if (noChinese==false)
				{
					MusicArrayNum=15;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"您們在這兩種套餐打上Ｘ的記號。");
					break;

				}
				else
				{
					MusicArrayNum=27+15;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"Die anderen beiden haben Sie\n nicht bestellt, denn Sie haben hier \nein Kreuz gemacht.");
					break;

				}
			}
		case 25://彼得
			{
				if (noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"對不起，\n我聽不懂。請您再說一次。");
					SwitchRecognizeOk(/*語音辨識內容*/"對不起我聽",/*錯誤時需請使用者重復之語句*/"對不起，\n我聽不懂。請您再說一次。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Es tut mir leid. Ich verstehe Sie nicht. Können Sie das noch einmal sagen?");
					SwitchRecognizeOk(/*語音辨識內容*/"Es tut mir leid Ich verstehe Sie nicht Können Sie das noch einmal sagen",/*錯誤時需請使用者重復之語句*/"Es tut mir leid. Ich verstehe Sie nicht. Können Sie das noch einmal sagen?");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
			}
		case 26://服務生
			{
				if (noChinese==false)
				{
					MusicArrayNum=16;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"打差表示不要。打勾表示需要。");
					break;

				}
				else
				{
					MusicArrayNum=27+16;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"Ein Kruz bedeutet, dass Sie \ndas Menü nicht haben \nwollen.Ein Haken bedeutet, \ndass Sie das Menü bestellen.");
					break;

				}
			}
		case 27://彼得
			{
				if (noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"啊！\n我們國家是用打差的記號，\n來表示我們的需要。");
					SwitchRecognizeOk(/*語音辨識內容*/"啊我們國家",/*錯誤時需請使用者重復之語句*/"啊！\n我們國家是用打差的記號，\n來表示我們的需要。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Ach?! Wir Deutsche machen auf der Speisekarte ein Kreuz, das heißt, wir wollen dieses Menü bestellen.");
					SwitchRecognizeOk(/*語音辨識內容*/"Ach Wir Deutsche machen auf der Speisekarte ein Kreuz das heißt wir wollen dieses Menü bestellen",/*錯誤時需請使用者重復之語句*/"Ach?! Wir Deutsche machen auf der Speisekarte ein Kreuz, das heißt, wir wollen dieses Menü bestellen.");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
			}
		case 28://服務生
			{
				if (noChinese==false)
				{
					MusicArrayNum=17;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"真的很抱歉，\n這是我們的疏失，\n我請廚師特別做了特餐，\n來補償你們。");
					break;

				}
				else
				{
					MusicArrayNum=27+17;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"Entschuldigung. Das ist unser \nFehler.Um diesen Fehler \nwieder gutzumachen, werde Ihnen \nunser Koch eine Spezialität kochen.");
					break;

				}
			}
		case 29://彼得
			{
				if (noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"真的!感謝您");
					SwitchRecognizeOk(/*語音辨識內容*/"真的感謝您",/*錯誤時需請使用者重復之語句*/"真的!感謝您");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Wirklich, vielen Dank.");
					SwitchRecognizeOk(/*語音辨識內容*/"Wirklich vielen Dank",/*錯誤時需請使用者重復之語句*/"Wirklich, vielen Dank.");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
			}
		case 30://服務生
			{
				if (noChinese==false)
				{
					MusicArrayNum=18;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"但是提醒您，\n下次請不要將需要餐點\n做打差的記號。");
					break;

				}
				else
				{
					MusicArrayNum=27+18;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"服務生",/*要說的話*/"Aber diesmal machen Sie \neinen Haken neben das Gericht, das Sie haben wollen. \nMachen Sie kein Kreuz.");
					break;

				}
			}
		case 31://彼得
			{
				if (noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"好。我懂了");
					SwitchRecognizeOk(/*語音辨識內容*/"好我懂了",/*錯誤時需請使用者重復之語句*/"好。我懂了");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"OK. Das habe ich verstanden.");
					SwitchRecognizeOk(/*語音辨識內容*/"OK Das habe ich verstanden",/*錯誤時需請使用者重復之語句*/"OK. Das habe ich verstanden.");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
			}
		case 32://茱莉
			{
				if (noChinese==false)
				{
					MusicArrayNum=19;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"這間店服務真好");
					break;

				}
				else
				{
					MusicArrayNum=27+19;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"Der Wirt ist sehr nett.");
					break;

				}
			}
		case 33://彼得
			{
				if (noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"還需要點菜嗎");
					SwitchRecognizeOk(/*語音辨識內容*/"還需要點菜嗎",/*錯誤時需請使用者重復之語句*/"還需要點菜嗎");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Willst du noch etwas bestellen?");
					SwitchRecognizeOk(/*語音辨識內容*/"Willst du noch etwas bestellen",/*錯誤時需請使用者重復之語句*/"Willst du noch etwas bestellen?");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
				break;	
				}
			}
		case 34://茱莉
			{
				if (noChinese==false)
				{
					MusicArrayNum=20;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"不，我已經很飽了");
					break;

				}
				else
				{
				MusicArrayNum=20;
				German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
				Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"Nein, ich bin schon satt.");
				break;

				}
			}
		case 35://彼得
			{
				if (noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"我也很飽了。\n可是我很渴。\n我想加點一杯飲料。");
					SwitchRecognizeOk(/*語音辨識內容*/"我也很飽了",/*錯誤時需請使用者重復之語句*/"我也很飽了。\n可是我很渴。\n我想加點一杯飲料。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Ich bin auch sehr satt. Aber ich habe einen großen Durst. Ich bestelle mir noch ein Getränk.");
					SwitchRecognizeOk(/*語音辨識內容*/"Ich bin auch sehr satt Aber ich habe einen großen Durst Ich bestelle mir noch ein Getränk",/*錯誤時需請使用者重復之語句*/"Ich bin auch sehr satt. Aber ich habe einen großen Durst. Ich bestelle mir noch ein Getränk.");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
			}
		case 36://茱莉
			{
				if (noChinese==false)
				{
					MusicArrayNum=21;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"我也很渴");
					break;

				}
				else
				{
					MusicArrayNum=27+21;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"Ich habe auch einen großen Durst.");
					break;

				}
			}
		case 37://彼得
			{
				if (noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"你要不要點飲料");
					SwitchRecognizeOk(/*語音辨識內容*/"你要不要點",/*錯誤時需請使用者重復之語句*/"你要不要點飲料");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Willst du dir nicht auch etwas zum Trinken bestellen?");
					SwitchRecognizeOk(/*語音辨識內容*/"Willst du dir nicht auch etwas zum Trinken bestellen",/*錯誤時需請使用者重復之語句*/"Willst du dir nicht auch etwas zum Trinken bestellen?");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
			}
		case 38://茱莉
			{
				if (noChinese==false)
				{
					MusicArrayNum=22;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"我不想點飲料。\n我想加點一碗湯");
					break;

				}
				else
				{
					MusicArrayNum=27+22;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"Ich bin auch sehr satt. \nAber ich habe einen großen Durst.Ich \nbestelle mir noch ein Getränk.");
					break;

				}
			}
		case 39://彼得
			{
				if (noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"好");
					SwitchRecognizeOk(/*語音辨識內容*/"好",/*錯誤時需請使用者重復之語句*/"好");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Gerne.");
					SwitchRecognizeOk(/*語音辨識內容*/"Gerne",/*錯誤時需請使用者重復之語句*/"Gerne.");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
				break;
				}
			}
		case 40://茱莉
			{
				if (noChinese==false)
				{
					MusicArrayNum=23;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"老闆，結帳");
					break;

				}
				else
				{
					MusicArrayNum=27+23;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"茱莉",/*要說的話*/"Herr Wirt, zahlen bitte.");
					break;

				}
			}
		case 41://彼得
			{
				if (noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"總共多少錢");
					SwitchRecognizeOk(/*語音辨識內容*/"總共多少錢",/*錯誤時需請使用者重復之語句*/"總共多少錢");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Wie viel macht es insgesamt?");
					SwitchRecognizeOk(/*語音辨識內容*/"Wie viel macht es insgesamt",/*錯誤時需請使用者重復之語句*/"Wie viel macht es insgesamt?");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}

				}
		case 42://老闆
			{
				if (noChinese==false)
				{
					MusicArrayNum=24;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"請稍後，讓我為您結算。");
					break;

				}
				else
				{
					MusicArrayNum=27+24;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"Ich rechne es mal zusammen.");
					break;

				}
			}
		case 43://彼得
			{
				if (noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"請問我可以刷卡嗎");
					SwitchRecognizeOk(/*語音辨識內容*/"請問我可以",/*錯誤時需請使用者重復之語句*/"請問我可以刷卡嗎");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Kann ich mit der Kreditkarte bezahlen?");
					SwitchRecognizeOk(/*語音辨識內容*/"Kann ich mit der Kreditkarte bezahlen",/*錯誤時需請使用者重復之語句*/"Kann ich mit der Kreditkarte bezahlen?");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				}
		case 44://老闆
			{
				if (noChinese==false)
				{
					MusicArrayNum=25;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"可以的。請給我你的信用卡。");
					break;

				}
				else
				{
					MusicArrayNum=27+25;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"Ja, gerne. Geben Sie mir bitte Ihre Kreditkarte.");
					break;

				}
			}
		case 45://彼得
			{
				if (noChinese==false)
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"請刷這張，謝謝。");
					SwitchRecognizeOk(/*語音辨識內容*/"請刷這張謝",/*錯誤時需請使用者重復之語句*/"請刷這張，謝謝。");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
				else
				{
					Call_Customer_Talk(/*說話者*/"彼得",/*要說的話*/"Hier ist die Karte. Vielen Dank.");
					SwitchRecognizeOk(/*語音辨識內容*/"Hier ist die Karte Vielen Dank",/*錯誤時需請使用者重復之語句*/"Hier ist die Karte. Vielen Dank.");//傳入語音辨識驗證使用者的話，並返回如果錯誤時需重復的內容
					break;
				}
			}
		case 46://老闆
			{
				if (noChinese==false)
				{
					MusicArrayNum=26;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"感謝您的惠顧，歡迎再次光臨。");
					break;

				}
				else
				{
					MusicArrayNum=27+26;
					German_SoundArray.SendMessage ("ChooseMusic",MusicArrayNum);//播放語音
					Call_Customer_Talk(/*說話者*/"老闆",/*要說的話*/"Vielen Dank für Ihr Kommen\n.Wir hoffen, dass Sie \nnoch zu uns kommen \nkönnen.");
					break;

				}
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

IEnumerator WaiterMoveAni(float waitTime)//服務生移動到顧客面前然後點餐的協程
    {
    	TableWaiterAni.SetBool ("Walk", true);//服務生走過來
        yield return new WaitForSeconds(waitTime);
        TableWaiterAni.SetBool ("Walk", false);//服務生行走停止
        TableWaiterman.transform.rotation = Quaternion.Euler (0, 270, 0);//轉身面對顧客
	    TablePetercustomerAni.SetBool ("ShakeHand", false);//彼得揮手關閉
    	TableWaiterAni.SetBool ("EatSome", true);//服務生點餐
        yield return new WaitForSeconds(1);
    	TableWaiterAni.SetBool ("EatSome", false);//服務生點餐
    }
IEnumerator WaiterLeaf(float waitTime)
    {
    	TableWaiterman.transform.rotation = Quaternion.Euler (0, 180, 0);//轉身面對顧客
    	TableWaiterAni.SetBool ("BackMove", true);//服務生離開
        yield return new WaitForSeconds(waitTime);
    	TableWaiterAni.SetBool ("BackMove", false);//服務生離開停止
    	PlayerTalk=18;
	}
IEnumerator WaiterMovetoCustomer(float waitTime)//因為點餐錯誤而走向顧客
    {
    	TableWaiterAni.SetBool ("Walk", true);//服務生走過來
        yield return new WaitForSeconds(waitTime);
        TableWaiterAni.SetBool ("Walk", false);//服務生行走停止
        TableWaiterman.transform.rotation = Quaternion.Euler (0, 270, 0);//轉身面對顧客
	    TablePetercustomerAni.SetBool ("ShakeHand", false);//彼得揮手關閉
    	PlayerTalk=21;//進入下一個Switch:詢問顧客需求
    }
}
