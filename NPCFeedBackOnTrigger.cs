using UnityEngine;
using System.Collections;

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
    private bool CloseAllTextBoxBool=true;//檢測是否CloseAllTextBox成功
    GameObject Currect = GameObject.Find("正確");
    GameObject False = GameObject.Find("錯誤");
    public float Timer = 0f;
    
	void Start () {
     
       
      
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
                    CloseAllTextBox();
                    break;
                }
            case 1:
                {
                   
                        TextBox[0].gameObject.SetActive(true);//NPC Talk Box Open
                        TextBox[4].gameObject.SetActive(true);//歡迎光臨，您好，很高興為您服務！
                        ButtonUI(/*ShowNext*/true,/*ShowBack*/false,/*ShowExit*/false);//UIButton顯示設定
                    if (Timer > 3)
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
                            ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//玩家可返回上一步
                            CurrectFalseChoice();//透過語音辨識結果判定玩家是否進入下一個階段




                    break;
                }
            case 3:
                {
                  
                        TextBox[0].gameObject.SetActive(true);//開啟NPC對話box
                        TextBox[6].gameObject.SetActive(true);//NPC:有的。請問您要單人房或者雙人房?
                        ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                   
                 
                    break;
                }
            case 4:
                {
                  
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[7].gameObject.SetActive(true);//我要一間單人房
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//玩家可返回上一步
                    CurrectFalseChoice();//透過語音辨識結果判定玩家是否進入下一個階段

                    break;
                }
            case 5:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[8].gameObject.SetActive(true);//請問你要住幾天
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    break;
                }
            case 6:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[9].gameObject.SetActive(true);//我住一晚明早退房
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//可返回上一步
                    CurrectFalseChoice();//透過語音辨識結果判定玩家是否進入下一個階段

                    break;
                }
            case 7:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[10].gameObject.SetActive(true);//請等一下。我確認一下房間狀況
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    break;
                }
            case 8:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[11].gameObject.SetActive(true);//我們目前還剩三間單人房。一間日月潭美景房，兩間大街風景房。
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    break;
                }
            case 9:
                {

                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[12].gameObject.SetActive(true);//我要一間大街風景房我要一間日月潭美景房(二擇一)
                    ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/true);//UIButton顯示設定
                    CurrectFalseChoice();//透過語音辨識結果判定玩家是否進入下一個階段
                    break;
                    

                }
            case 10:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[13].gameObject.SetActive(true);//好的，請問還有什麼需要嗎?
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    break;
                }
            case 11:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[14].gameObject.SetActive(true);//請問，有附早餐嗎?
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    CurrectFalseChoice();//透過語音辨識結果判定玩家是否進入下一個階段
                    break;
                }
            case 12:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[15].gameObject.SetActive(true);//有的。早餐有中式和西式早餐。
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    break;
                }
            case 13:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[16].gameObject.SetActive(true);//好的，請幫我辦理入住手續
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    CurrectFalseChoice();//透過語音辨識結果判定玩家是否進入下一個階段
                    break;
                }
            case 14:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[17].gameObject.SetActive(true);//稍等一下，讓我為您核對資料。請問，您的姓氏是「林」還是「得」呢?
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    break;
                }
            case 15:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[18].gameObject.SetActive(true);//我姓為林，名為彼得。
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    CurrectFalseChoice();//透過語音辨識結果判定玩家是否進入下一個階段
                    break;
                }
            case 16:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[19].gameObject.SetActive(true);//提醒您，中文先寫姓，再寫名。西文先寫名，再寫姓。
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    break;
                }
            case 17:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[20].gameObject.SetActive(true);//我這樣填寫有要更改的地方嗎? 
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定
                    CurrectFalseChoice();//透過語音辨識結果判定玩家是否進入下一個階段
                    break;
                }
            case 18:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[21].gameObject.SetActive(true);//資料填寫無誤。您姓林? 請問您是混血兒嗎?
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定                   
                    break;
                }
            case 19:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[22].gameObject.SetActive(true);//我是德裔，所以有些特別。
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定 
                    CurrectFalseChoice();//透過語音辨識結果判定玩家是否進入下一個階段                  
                    break;
                }
            case 20:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[23].gameObject.SetActive(true);//原來如此，這邊我需要核對身分，請問您的護照號碼是?
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定                   
                    break;
                }
            case 21:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[24].gameObject.SetActive(true);//我的護照號碼是767741233。
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定 
                    CurrectFalseChoice();//透過語音辨識結果判定玩家是否進入下一個階段                   
                    break;
                }
            case 22:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[25].gameObject.SetActive(true);//確認完畢，這是您的房間鑰匙，1 0 2 0。
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定                   
                    break;
                }
            case 23:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[26].gameObject.SetActive(true);//請問能讓我結帳嗎?
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定   
                    CurrectFalseChoice();//透過語音辨識結果判定玩家是否進入下一個階段                
                    break;
                }
            case 24:
                {
                    TextBox[0].gameObject.SetActive(true);//Open NPC Talk box 
                    TextBox[27].gameObject.SetActive(true); //可以的，請問您的附費方式是?
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定                    
                    break;
                }
            case 25:
                {
                    TextBox[1].gameObject.SetActive(true);//Player Talk Box Open
                    TextBox[2].gameObject.SetActive(true);//系統提示:
                    TextBox[3].gameObject.SetActive(true);//下列句子按錄音鍵後，請說出
                    TextBox[28].gameObject.SetActive(true);//我要付現金，請你點一下。我要刷卡，請你刷這張。我要手機支付，請讓我掃QRCode。(三擇一)
                    ButtonUI(/*ShowNext*/true,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定  
                    CurrectFalseChoice();//透過語音辨識結果判定玩家是否進入下一個階段                  
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

            TextBox[i].gameObject.SetActive(false);//關閉所有對話框
            Currect.SetActive(false);//關閉正確的Text字樣
            False.SetActive(false);//關閉錯誤的Text字樣
        }
      
    }
  
    public void TextContrast (string speakInput)//處理玩家的語音辨識，並做字串比對
    {
        if (PlayerSwitch==2)
            {
            string ConstrastValue = "請問還有空房嗎";//宣告需與辨識結果比對的字串
                if (speakInput == ConstrastValue)//如果辨識結果與需要辨識的字串相符合
                    {
                        Currect.SetActive(true);//顯示正確的Text字樣
                        False.SetActive(false);//並關閉錯誤的Text字樣
                    }
                else
                    {
                        False.SetActive(true);//顯示錯誤的Text字樣
                        Currect.SetActive(false);//關閉正確的Text字樣
                    }
            }
        if (PlayerSwitch ==4)
            {
            string ConstrastValue = "我要一間單人房";//宣告需與辨識結果比對的字串
            if (speakInput == ConstrastValue)//如果辨識結果與需要辨識的字串相符合
            {
                Currect.SetActive(true);//顯示正確的Text字樣
                False.SetActive(false);//並關閉錯誤的Text字樣
            }
            else
            {
                False.SetActive(true);//顯示錯誤的Text字樣
                Currect.SetActive(false);//關閉正確的Text字樣
            }
        }
        if (PlayerSwitch ==6)
            {
            string ConstrastValue = "我住一晚明早退房";//宣告需與辨識結果比對的字串
            if (speakInput == ConstrastValue)//如果辨識結果與需要辨識的字串相符合
            {
                Currect.SetActive(true);//顯示正確的Text字樣
                False.SetActive(false);//並關閉錯誤的Text字樣
            }
            else
            {
                False.SetActive(true);//顯示錯誤的Text字樣
                Currect.SetActive(false);//關閉正確的Text字樣
            }
        }
        if (PlayerSwitch ==9)
            {
            string ConstrastValue = "我要一間大街風景房";//宣告需與辨識結果比對的字串
            string ConstrastValue2 = "我要一間日月潭美景房";//辨識目標2

            if (speakInput == ConstrastValue)//如果辨識結果與需要辨識的字串相符合
            {
                Currect.SetActive(true);//顯示正確的Text字樣
                False.SetActive(false);//並關閉錯誤的Text字樣
            }
            else
            {
                False.SetActive(true);//顯示錯誤的Text字樣
                Currect.SetActive(false);//關閉正確的Text字樣
            }

            if (speakInput == ConstrastValue2)//如果辨識結果與需要辨識的字串2相符合
            {
                Currect.SetActive(true);//顯示正確的Text字樣
                False.SetActive(false);//並關閉錯誤的Text字樣
            }
            else
            {
                False.SetActive(true);//顯示錯誤的Text字樣
                Currect.SetActive(false);//關閉正確的Text字樣
            }

        }
        if (PlayerSwitch ==11)
            {
            string ConstrastValue = "請問有附早餐嗎";//宣告需與辨識結果比對的字串
            if (speakInput == ConstrastValue)//如果辨識結果與需要辨識的字串相符合
            {
                Currect.SetActive(true);//顯示正確的Text字樣
                False.SetActive(false);//並關閉錯誤的Text字樣
            }
            else
            {
                False.SetActive(true);//顯示錯誤的Text字樣
                Currect.SetActive(false);//關閉正確的Text字樣
            }
        }
        if (PlayerSwitch ==13)
            {
            string ConstrastValue = "好的請幫我辦理入住手續";//宣告需與辨識結果比對的字串
            if (speakInput == ConstrastValue)//如果辨識結果與需要辨識的字串相符合
            {
                Currect.SetActive(true);//顯示正確的Text字樣
                False.SetActive(false);//並關閉錯誤的Text字樣
            }
            else
            {
                False.SetActive(true);//顯示錯誤的Text字樣
                Currect.SetActive(false);//關閉正確的Text字樣
            }
        }
        if (PlayerSwitch ==15)
            {
            string ConstrastValue = "我姓為林名為彼得";//宣告需與辨識結果比對的字串
            if (speakInput == ConstrastValue)//如果辨識結果與需要辨識的字串相符合
            {
                Currect.SetActive(true);//顯示正確的Text字樣
                False.SetActive(false);//並關閉錯誤的Text字樣
            }
            else
            {
                False.SetActive(true);//顯示錯誤的Text字樣
                Currect.SetActive(false);//關閉正確的Text字樣
            }
        }
        if (PlayerSwitch ==17)
            {
            string ConstrastValue = "我這樣填寫有要更改的地方嗎";//宣告需與辨識結果比對的字串
            if (speakInput == ConstrastValue)//如果辨識結果與需要辨識的字串相符合
            {
                Currect.SetActive(true);//顯示正確的Text字樣
                False.SetActive(false);//並關閉錯誤的Text字樣
            }
            else
            {
                False.SetActive(true);//顯示錯誤的Text字樣
                Currect.SetActive(false);//關閉正確的Text字樣
            }
        }
        if (PlayerSwitch ==19)
            {
            string ConstrastValue = "我是德裔所以有些特別";//宣告需與辨識結果比對的字串
            if (speakInput == ConstrastValue)//如果辨識結果與需要辨識的字串相符合
            {
                Currect.SetActive(true);//顯示正確的Text字樣
                False.SetActive(false);//並關閉錯誤的Text字樣
            }
            else
            {
                False.SetActive(true);//顯示錯誤的Text字樣
                Currect.SetActive(false);//關閉正確的Text字樣
            }
        }
        if (PlayerSwitch ==21)
            {
            string ConstrastValue = "我的護照號碼是767741233";//宣告需與辨識結果比對的字串
            if (speakInput == ConstrastValue)//如果辨識結果與需要辨識的字串相符合
            {
                Currect.SetActive(true);//顯示正確的Text字樣
                False.SetActive(false);//並關閉錯誤的Text字樣
            }
            else
            {
                False.SetActive(true);//顯示錯誤的Text字樣
                Currect.SetActive(false);//關閉正確的Text字樣
            }
        }
        if (PlayerSwitch ==23)
            {
            string ConstrastValue = "請問能讓我結帳嗎";//宣告需與辨識結果比對的字串
            if (speakInput == ConstrastValue)//如果辨識結果與需要辨識的字串相符合
            {
                Currect.SetActive(true);//顯示正確的Text字樣
                False.SetActive(false);//並關閉錯誤的Text字樣
            }
            else
            {
                False.SetActive(true);//顯示錯誤的Text字樣
                Currect.SetActive(false);//關閉正確的Text字樣
            }
        }
        if (PlayerSwitch ==25)
            {
            string ConstrastValue = "我要付現金請你點一下";//宣告需與辨識結果比對的字串
            string ConstrastValue2 = "我要刷卡請你刷這張";
            string ConstrastValue3 = "我要手機支付，請讓我掃QRCode";
            /*********************************************需要辨識的字串1*************************************************************/
            if (speakInput == ConstrastValue)//如果辨識結果與需要辨識的字串相符合
            {
                Currect.SetActive(true);//顯示正確的Text字樣
                False.SetActive(false);//並關閉錯誤的Text字樣
            }
            else
            {
                False.SetActive(true);//顯示錯誤的Text字樣
                Currect.SetActive(false);//關閉正確的Text字樣
            }
            /*********************************************需要辨識的字串1*************************************************************/


            /*********************************************需要辨識的字串2*************************************************************/
                            if (speakInput == ConstrastValue2)//如果辨識結果與需要辨識的字串2相符合
                            {
                                Currect.SetActive(true);//顯示正確的Text字樣
                                False.SetActive(false);//並關閉錯誤的Text字樣
                            }
                            else
                            {
                                False.SetActive(true);//顯示錯誤的Text字樣
                                Currect.SetActive(false);//關閉正確的Text字樣
                            }
            /*********************************************需要辨識的字串2*************************************************************/



            /*********************************************需要辨識的字串3*************************************************************/
                            if (speakInput == ConstrastValue3)//如果辨識結果與需要辨識的字串3相符合
                            {
                                Currect.SetActive(true);//顯示正確的Text字樣
                                False.SetActive(false);//並關閉錯誤的Text字樣
                            }
                            else
                            {
                                False.SetActive(true);//顯示錯誤的Text字樣
                                Currect.SetActive(false);//關閉正確的Text字樣
                            }
            /*********************************************需要辨識的字串3*************************************************************/
        }


    }
    public void CurrectFalseChoice()//透過語音辨識結果判定玩家是否進入下一個階段
    {
        if (False == true)
        {
            ButtonUI(/*ShowNext*/false,/*ShowBack*/true,/*ShowExit*/false);//UIButton顯示設定，關閉下一步指示
        }
        if (Currect == true)
        {
            if (Timer > 2)//在這邊要等待兩秒的原因是因為想讓玩家看到辨識成功了
            {
                PlayerSwitch++;//直接進入下一句
                Timer = 0f;
            }
        }
    }
}

