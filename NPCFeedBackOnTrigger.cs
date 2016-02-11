using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NPCFeedBackOnTrigger : MonoBehaviour {
	public Camera[] CameraArray;//相機陣列
	public Animator Waiter;//服務生的動畫控制器
	public bool PlayerTalkText;//玩家說話框
	public bool WaiterTalkText;//服務生說話控制
    public GUIStyle btnStyle;//宣告上下一步按鈕style
    public int PlayerSwitch=1;//每次要說的話都放在這邊
    public GameObject[] TextBox;
    public GameObject NextButton;//下一步按鈕是否顯示
    public GameObject BackButton;//上一步按鈕是否顯示
    public GameObject ExitButton;//上一步按鈕是否顯示
    public GameObject RecognizeTextObj;//語音辨識的物件
    public GameObject RecogTextBox;//語音辨識結果
    GameObject Currect = GameObject.Find("正確");
    GameObject False = GameObject.Find("錯誤");
    public float Timer = 0f;
    public bool RecgStatus;//偵測辨識結果
	void Start () {
    RecogTextBox.GetComponentInChildren<Text> ().text ="";
    RecognizeTextObj=GameObject.Find("RecognizeTextObj");//語音辨識之比對物件       
    RecogTextBox=GameObject.Find("RecogTextBox");//語音辨識結果顯示窗
    TextBox[0] = GameObject.Find("NPCTalkText");
    TextBox[1] = GameObject.Find("PlayerTalkText");
    TextBox[2] = GameObject.Find("系統提示:");
    TextBox[3] = GameObject.Find("下列句子按錄音鍵後，請說出");
    TextBox[4] = GameObject.Find("歡迎光臨，您好，很高興為您服務！");
    TextBox[5] = GameObject.Find("請問，還有空房嗎?");
    TextBox[6] = GameObject.Find("有的。請問您要單人房或者雙人房?");
    TextBox[7] = GameObject.Find("我要一間單人房");
    TextBox[8] = GameObject.Find("請問，您要住幾天?");
    TextBox[9] = GameObject.Find("我住一晚，明早退房");
    TextBox[10] = GameObject.Find("請等一下。我確認一下房間狀況");
    TextBox[11] = GameObject.Find("我們目前還剩三間單人房一間日月潭美景房，兩間大街風景房");
    TextBox[12] = GameObject.Find("我要一間大街風景房  我要一間日月潭美景房  (二擇一)");
    TextBox[13] = GameObject.Find("好的，請問還有什麼需要嗎?");
    TextBox[14] = GameObject.Find("請問，有附早餐嗎?");
    TextBox[15] = GameObject.Find("有的。早餐有中式和西式早餐");
    TextBox[16] = GameObject.Find("好的，請幫我辦理入住手續");
    TextBox[17] = GameObject.Find("稍等一下，讓我為您核對資料。  請問，您的姓氏是「林」還是「得」呢?");
    TextBox[18] = GameObject.Find("我姓為林，名為彼得");
    TextBox[19] = GameObject.Find("提醒您，中文先寫姓，再寫名。  西文先寫名，再寫姓");
    TextBox[20] = GameObject.Find("我這樣填寫有要更改的地方嗎?");
    TextBox[21] = GameObject.Find("資料填寫無誤。您姓林? 請問您是混血兒嗎?");
    TextBox[22] = GameObject.Find("我是德裔，所以有些特別");
    TextBox[23] = GameObject.Find("原來如此，這邊我需要核對身分，請問您的護照號碼是?");
    TextBox[24] = GameObject.Find("我的護照號碼是  767741233");
    TextBox[25] = GameObject.Find("確認完畢，這是您的房間鑰匙，1 0 2 0。");
    TextBox[26] = GameObject.Find("請問能讓我結帳嗎?");
    TextBox[27] = GameObject.Find("可以的，請問您的附費方式是?");
    TextBox[28] = GameObject.Find("我要付現金，請你點一下 我要刷卡，請你刷這張我要手機支付，請讓我掃  QRCode。(三擇一)");
    TextBox[29] = GameObject.Find("感謝您的入住，祝您旅途愉快");

            


        
            CloseAllTextBox();//關閉所有對話框

            

	}

	void Update () {
        Timer = Timer + Time.deltaTime;
    }

	void OnTriggerEnter (Collider other)
	{
		if(other.name == "FPSController")
		{
            CameraArray[0].gameObject.SetActive(false);//主角相機關
            CameraArray[1].gameObject.SetActive(true);//NPC相機開
            Waiter.SetBool("Hellow", true);//宣告hellow動畫播放
            PlayerSwitch = 1;
		}
	}
	void OnGUI()
	{
     
        
     switch (PlayerSwitch)
        {
            case 0:
                {
					Timer = 0;//設定計時器為0
                    CloseAllTextBox();
                   
                    break;
                }
            case 1:
                {
					
                        TextBox[0].gameObject.SetActive(true);//NPC Talk Box Open
                        TextBox[4].gameObject.SetActive(true);//歡迎光臨，您好，很高興為您服務！
                        ButtonUI(/*ShowNext*/false,/*ShowBack*/false,/*ShowExit*/false);//UIButton顯示設定
                    if (Timer > 5)
                    {
                        PlayerSwitch++;
                        Timer = 0f;
                    }
                    break;
                }
            case 2:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[5].gameObject.SetActive(true);//玩家:請問，還有空房嗎?
                    if (Timer > 10)
                    {
					   SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"請問還有空");//傳入語音辨識驗證使用者的話
                    }
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//玩家可返回上一步

                    break;
                }
            case 3:
                {
                    
                    TextBox[0].gameObject.SetActive(true);//開啟NPC對話box
                    TextBox[6].gameObject.SetActive(true);//NPC:有的。請問您要單人房或者雙人房?
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    if (Timer > 3)
                    {
                        PlayerSwitch++;
                        Timer = 0f;
                        RecogTextBox.GetComponentInChildren<Text> ().text ="";
                    }
                    break;
                }
            case 4:
                {
                  
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[7].gameObject.SetActive(true);//我要一間單人房
                    if (Timer > 10)
                    {
                        SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"我要一間單");//傳入語音辨識驗證使用者的話
                    }
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//玩家可返回上一步
                    

                    break;
                }
            case 5:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[8].gameObject.SetActive(true);//請問你要住幾天
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
					if (Timer > 5)
					{
						PlayerSwitch++;
						Timer = 0f;
					}
			         break;
                }
            case 6:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[9].gameObject.SetActive(true);//我住一晚明早退房
                    if (Timer > 10)
                    {
                    SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"我住一晚明");//傳入語音辨識驗證使用者的話
                    }
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//可返回上一步
                     

                    break;
                }
            case 7:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[10].gameObject.SetActive(true);//請等一下。我確認一下房間狀況
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    if (Timer > 5)
                    {
                        
                        Timer = 0f;
                        PlayerSwitch++;
                    }
                    break;
                }
            case 8:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[10].gameObject.SetActive(false);//(關閉)請等一下。我確認一下房間狀況
                    TextBox[11].gameObject.SetActive(true);//我們目前還剩三間單人房。一間日月潭美景房，兩間大街風景房。
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    if (Timer > 5)
                    {
                        Timer = 0f;
                        PlayerSwitch++;
                    }
                    break;
                }
            case 9:
                {

                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[12].gameObject.SetActive(true);//我要一間大街風景房我要一間日月潭美景房(二擇一)
                    if (Timer > 10)
                    {
                        SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"我要一間大");//傳入語音辨識驗證使用者的話(我要一間大街風景房)
                        SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"我要一間日");//傳入語音辨識驗證使用者的話(我要一間大街風景房)
                    }  
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/true);//UIButton顯示設定
                     
                    break;
                    

                }
            case 10:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[13].gameObject.SetActive(true);//好的，請問還有什麼需要嗎?
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    if (Timer > 5)
                    {
                        PlayerSwitch++;
                        Timer = 0f;
                    }
                    break;
                }
            case 11:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[14].gameObject.SetActive(true);//請問，有附早餐嗎?
                    if (Timer > 10)
                    {
                        SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"請問有附早");//傳入語音辨識驗證使用者的話
                    }
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                     
                    break;
                }
            case 12:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[15].gameObject.SetActive(true);//有的。早餐有中式和西式早餐。
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    if (Timer > 5)
                    {
                        PlayerSwitch++;
                        Timer = 0f;
                    }                    
                    break;
                }
            case 13:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[16].gameObject.SetActive(true);//好的，請幫我辦理入住手續
                    if (Timer > 10)
                    {
                        SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"好的請幫我");//傳入語音辨識驗證使用者的話
                    }
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                     
                    break;
                }
            case 14:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[17].gameObject.SetActive(true);//稍等一下，讓我為您核對資料。請問，您的姓氏是「林」還是「得」呢?
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    if (Timer > 5)
                    {
                        PlayerSwitch++;
                        Timer = 0f;
                    }
                    break;
                }
            case 15:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[18].gameObject.SetActive(true);//我姓為林，名為彼得。
                    if (Timer > 10)
                    {
                        SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"我姓為林名");//傳入語音辨識驗證使用者的話
                    }
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                     
                    break;
                }
            case 16:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[19].gameObject.SetActive(true);//提醒您，中文先寫姓，再寫名。西文先寫名，再寫姓。
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    if (Timer > 5)
                    {
                        PlayerSwitch++;
                        Timer = 0f;
                    }
                    break;
                }
            case 17:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[20].gameObject.SetActive(true);//我這樣填寫有要更改的地方嗎? 
                    if (Timer > 10)
                    {
                        SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"我這樣填寫");//傳入語音辨識驗證使用者的話
                    }
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                     
                    break;
                }
            case 18:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[21].gameObject.SetActive(true);//資料填寫無誤。您姓林? 請問您是混血兒嗎?
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定                   
                    if (Timer > 5)
                    {
                        PlayerSwitch++;
                        Timer = 0f;
                    }
                    break;
                }
            case 19:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[22].gameObject.SetActive(true);//我是德裔，所以有些特別。
                    if (Timer > 10)
                    {
                        SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"我是德裔所");//傳入語音辨識驗證使用者的話
                    }
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定 
                                       
                    break;
                }
            case 20:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[23].gameObject.SetActive(true);//原來如此，這邊我需要核對身分，請問您的護照號碼是?
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定                   
                    if (Timer > 5)
                    {
                        PlayerSwitch++;
                        Timer = 0f;
                    }
                    break;
                }
            case 21:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[24].gameObject.SetActive(true);//我的護照號碼是767741233。
                    if (Timer > 10)
                    {
                        SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"我的護照號");//傳入語音辨識驗證使用者的話
                    }
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定 
                                        
                    break;
                }
            case 22:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[25].gameObject.SetActive(true);//確認完畢，這是您的房間鑰匙，1 0 2 0。
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定                   
                    if (Timer > 5)
                    {
                        PlayerSwitch++;
                        Timer = 0f;
                    }
                    break;
                }
            case 23:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[26].gameObject.SetActive(true);//請問能讓我結帳嗎?
                    if (Timer > 10)
                    {
                        SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"請問能讓我");//傳入語音辨識驗證使用者的話
                    }
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定   
                                     
                    break;
                }
            case 24:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[27].gameObject.SetActive(true); //可以的，請問您的付費方式是?
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定                    
                    if (Timer > 5)
                    {
                        PlayerSwitch++;
                        Timer = 0f;
                    }
                    break;
                }
            case 25:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[28].gameObject.SetActive(true);//我要付現金，請你點一下。我要刷卡，請你刷這張。我要手機支付，請讓我掃QRCode。(三擇一)
                    if (Timer > 10)
                    {
                        SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"我要付現金");//傳入語音辨識驗證使用者的話
                        SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"我要刷卡請");//傳入語音辨識驗證使用者的話
                        SwitchRecognizeOk(/*語音辨識內容(限定前五個字)*/"我要手機支");//傳入語音辨識驗證使用者的話
                    }
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定  
                                       
                    break;
                }
            case 26:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[29].gameObject.SetActive(true);//感謝您的入住，祝您旅途愉快。
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/true);//UIButton顯示設定
    
                    break;
                }
            case 27: //離開鍵的狀態釋放區
                {
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/false,/*ShowExit*/false);//UIButton顯示設定
                    CameraArray[0].gameObject.SetActive(true);//主角相機關
                    CameraArray[1].gameObject.SetActive(false);//NPC相機開
                    break;
                }
          
		    
		

	}
	}

    
	
    void ButtonUI(bool ShowNext,bool ShowBack,bool ShowExit)//按鈕控制
    {
        NextButton.gameObject.SetActive(ShowNext);//顯示下一步按鈕
        BackButton.gameObject.SetActive(ShowBack);//顯示上一步按鈕
        ExitButton.gameObject.SetActive(ShowExit);//顯示退出按鈕
    }
    public void NextButtonClick()//下一步
    {
        
        PlayerSwitch++;//玩家對話狀態+1
        CloseAllTextBox();//每次畫面刷新都先關閉所有物件
    }
    public void BackButtonClick()//上一步
    {
        PlayerSwitch--;//玩家對話狀態-1
        CloseAllTextBox();//每次畫面刷新都先關閉所有物件
      

    }
    public void ExitButtonClick()//退出
    {

        PlayerSwitch = 27;//離開鍵的狀態釋放區
        CloseAllTextBox();//每次畫面刷新都先關閉所有物件
        
        CameraArray[0].gameObject.SetActive(true);//主角相機開
        CameraArray[1].gameObject.SetActive(false);//NPC相機關
       

    }
    void CloseAllTextBox()
    {
        for (int i = 0; i <= 30;i++ )
        {
			TextBox[i].gameObject.SetActive(false);
        }
      
    }
    void Close_NPC_TextBox()
    {
        for (int i = 2; i <= 30;i++ )
        {
            TextBox[i].gameObject.SetActive(false);
        }
      
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
public void SwitchRecognizeOk(string message)//比對結果
{

    RecognizeTextObj.SendMessage ("CheckRecog",message);

    Timer=0.0f;
    if(RecgStatus==true)
    {
        RecogTextBox.GetComponentInChildren<Text> ().text ="辨識成功!!!";
		PlayerSwitch++;//下一步
        CloseAllTextBox();
        RecgStatus=false;
    }
    else
    {
        
        RecogTextBox.GetComponentInChildren<Text> ().text ="辨識失敗!!!";
    }
}
}

