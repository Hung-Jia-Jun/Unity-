using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextControl : MonoBehaviour {
	public int TalkSwitch;//說話狀態
	/*************角色動畫藍圖**********************/
	public Animator WaiterAni;//服務生動畫藍圖
	public Animator ChefAni;//老闆動畫藍圖
	public Animator PetercstomerAni;//彼得動畫藍圖
	public Animator MolycustomerAni;//茉莉動畫藍圖
	/**************角色動畫藍圖*********************/
	public GameObject Chef;//老闆對話框標題
	public GameObject ChefTextObj;//老闆要講的話
	public GameObject Chefman;//老闆的角色物件
	public GameObject Customer;//顧客對話框標題
	public GameObject CustomerTextObj;//顧客要講的話

	public GameObject Waiter;//服務生對話框標題
	public GameObject WaiterTextObj;//服務生要講的話
	public float Timer;
	public GameObject NextButton;//下一步按鈕
	public GameObject BackButton;//上一步按鈕
	public GameObject ExitButton;//退出按鈕
	void Start () {
		Chefman=GameObject.Find("廚師");//老闆的角色物件
		Chef=GameObject.Find("ChefTextObj");//老闆對話框標題
		ChefTextObj= GameObject.Find("ChefTalk");//老闆要講的話

		Customer=GameObject.Find("CustomerTextObj");//顧客對話框標題
		CustomerTextObj=GameObject.Find("CustomerTalk");//顧客要講的話

		Waiterman=GameObject.Find("廚師");//
		Waiter=GameObject.Find("WaiterTextObj");//服務生對話框標題
		WaiterTextObj=GameObject.Find("WaiterTalk");//服務生要講的話
		NextButton=GameObject.Find("NextButton");//下一步
		BackButton=GameObject.Find("BackButton");//上一步
		ExitButton=GameObject.Find("ExitButton");//離開
		CloseAllTextBox ();//關閉對話框以保持場面乾淨
		Timer=0.0f;
		TalkSwitch = 12;//直接跳轉到第四個switch
	}

	void Update () {
		Timer++;
		switch (TalkSwitch) {
		/*
		case 0://顧客
			{
				Customer.gameObject.SetActive (true);//開啟顧客對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟顧客要講話的物件
				MolycustomerAni.SetBool("StandIdle",true);//女角待命(站著)
				MolycustomerAni.SetBool("HandShake",true);//女角揮手
				//---------------------------------------------------------------------------------------
				Customer.GetComponentInChildren<Text> ().text = "茉莉";//顯示講話的人
				CustomerTextObj.GetComponentInChildren<Text> ().text = "請問還有空位嗎??";
				MolycustomerAni.SetBool("HandShake",false);//女角揮手關閉
				break;
			}
		case 1://老闆
			{
				Timer++;
				Chef.gameObject.SetActive (true);//開啟老闆對話框
				ChefTextObj.gameObject.SetActive (true);//開啟老闆要講話的物件
				//---------------------------------------------------------------------------------------
				ChefAni.SetBool("Mic",true);//接耳mic確認	
				Chef.GetComponentInChildren<Text> ().text = "老闆";
				ChefTextObj.GetComponentInChildren<Text> ().text = "有的，\n請問，您們是兩位用餐嗎?";
				if (Timer > 300) 
				{
					ChefAni.SetBool("Mic",false);//接耳mic結束
				}
			
			break;
			}
		case 2://彼得
			{
				Customer.gameObject.SetActive (true);//開啟顧客對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟顧客要講話的物件
				//---------------------------------------------------------------------------------------
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "是的，兩位";
				break;
			}
		case 3://老闆
			{
				Chef.gameObject.SetActive (true);//開啟老闆對話框
				ChefTextObj.gameObject.SetActive (true);//開啟老闆要講話的物件
				ChefAni.SetBool ("PleaseFollowMe", true);//點頭鞠躬帶位true
				Chef.GetComponentInChildren<Text> ().text = "老闆";
				ChefTextObj.GetComponentInChildren<Text> ().text = "好的，請往這邊。";

				if (Timer > 300) 
				{
					ChefAni.SetBool ("PleaseFollowMe", false);
				}

			break;
			}
		case 4://茱莉
			{
				Customer.gameObject.SetActive (true);//開啟茱莉對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟茱莉要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "茱莉";
			CustomerTextObj.GetComponentInChildren<Text> ().text = "請問，\n你們有沒有套餐?";
			break;
			}
		case 5://老闆
			{
				Chef.gameObject.SetActive (true);//開啟老闆對話框
				ChefTextObj.gameObject.SetActive (true);//開啟老闆要講話的物件
				Chef.GetComponentInChildren<Text> ().text = "老闆";
				ChefTextObj.GetComponentInChildren<Text> ().text = "我們目前有四種套餐";
			break;
		}
		case 6://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
			CustomerTextObj.GetComponentInChildren<Text> ().text = "對不起，\n讓我們討論一下。";
			break;
		}
		case 7://老闆
			{
				Chef.gameObject.SetActive (true);//開啟老闆對話框
				ChefTextObj.gameObject.SetActive (true);//開啟老闆要講話的物件
				Chef.GetComponentInChildren<Text> ().text = "老闆";
				ChefTextObj.GetComponentInChildren<Text> ().text = "沒關係，稍後再為您服務。";
				ChefAni.SetBool("BackMove",true);//鞠躬後退
				if (Timer < 100) 
				{
					Chefman.transform.Translate(Vector3.forward * -Time.deltaTime);//老闆後退
				}
				if (Timer > 120) 
				{
					ChefAni.SetBool("BackMove",false);//鞠躬後退
				}
			break;
		}

		case 8://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "你要吃什麼?";
			break;
		}

		case 9://茱莉
			{
				Customer.gameObject.SetActive (true);//開啟茱莉對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟茱莉要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "茱莉";
			CustomerTextObj.GetComponentInChildren<Text> ().text = "我要點一份A套餐。\n彼得(需要辨識)你呢?";
			break;
		}
		case 10://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
			CustomerTextObj.GetComponentInChildren<Text> ().text = "我想要一份C套餐。\n它看起來不錯。";
			break;
		}
		case 11://茱莉
			{
				Customer.gameObject.SetActive (true);//開啟對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "茱莉";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "OK，那就這樣決定了。";
			break;
		}*/
		case 12://彼得
			{
				Customer.gameObject.SetActive (true);//開啟對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "服務生，請幫我點餐";
				PetercstomerAni.SetBool ("ShakeHand", true);//彼得揮手
				if (Timer > 30) 
				{
					PetercstomerAni.SetBool ("ShakeHand", false	);//彼得揮手
					gameObject.transform.rotation = Quaternion.Euler (0, 30, 0);					
				}
			break;
		}


		/*
		case 13://服務生
			{
			Waiter.gameObject.SetActive (true);//開啟服務生對話框
			WaiterTextObj.gameObject.SetActive (true);//開啟服務生要講話的物件
			Waiter.GetComponentInChildren<Text> ().text = "服務生";
			WaiterTextObj.GetComponentInChildren<Text> ().text = "好的，為您確認一下餐點。\n一份A餐和一份C餐";
			break;

			}
		case 14://服務生
			{
				Waiter.gameObject.SetActive (true);//開啟服務生對話框
				WaiterTextObj.gameObject.SetActive (true);//開啟服務生要講話的物件
				Waiter.GetComponentInChildren<Text> ().text = "服務生";
				WaiterTextObj.GetComponentInChildren<Text> ().text = "請問飲品要餐前上還是餐後上呢?";
			break;
			}
		case 15://茱莉
			{
				Customer.gameObject.SetActive (true);//開啟茱莉對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟茱莉要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "茱莉";
			CustomerTextObj.GetComponentInChildren<Text> ().text = "我想先上飲料，\n彼得(需要辨識)你呢?";
			break;
		}
		case 16://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "好主意，天氣蠻熱的";
			break;
		}
		case 17://服務生
			{
				Waiter.gameObject.SetActive (true);//開啟服務生對話框
				WaiterTextObj.gameObject.SetActive (true);//開啟服務生要講話的物件
				Waiter.GetComponentInChildren<Text> ().text = "服務生";
				WaiterTextObj.GetComponentInChildren<Text> ().text = "好的，稍後會為您上飲品。";
			break;
		}
		case 18://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "這是你點的套餐嗎?";
			break;
		}
		case 19://茱莉
			{
				Customer.gameObject.SetActive (true);//開啟茱莉對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟茱莉要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "茱莉";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "不，我沒點這個套餐。";
			break;
		}
		case 20://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "我也沒點這個套餐";
			break;
		}
		//------------------------------舉手呼叫老闆&服務生靠近

		case 21://服務生
			{
				Waiter.gameObject.SetActive (true);//開啟服務生對話框
				WaiterTextObj.gameObject.SetActive (true);//開啟服務生要講話的物件
				Waiter.GetComponentInChildren<Text> ().text = "服務生";
				WaiterTextObj.GetComponentInChildren<Text> ().text = "請問有什麼需要呢?";
			break;
			}
		case 22://彼得(需要辨識)
			{
				Customer.gameObject.SetActive (true);//開啟彼得(需要辨識)對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得(需要辨識)要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)(需要辨識)";
			CustomerTextObj.GetComponentInChildren<Text> ().text = "我們沒有\n點這兩個套餐。";
			break;
		}
		case 23://服務生
			{
				Waiter.gameObject.SetActive (true);//開啟服務生對話框
				WaiterTextObj.gameObject.SetActive (true);//開啟服務生要講話的物件
				Waiter.GetComponentInChildren<Text> ().text = "服務生";
				WaiterTextObj.GetComponentInChildren<Text> ().text = "請稍後，我們確認一下餐點";
			break;
		}
		case 24://服務生
			{
				Waiter.gameObject.SetActive (true);//開啟服務生對話框
				WaiterTextObj.gameObject.SetActive (true);//開啟服務生要講話的物件
				Waiter.GetComponentInChildren<Text> ().text = "服務生";
				WaiterTextObj.GetComponentInChildren<Text> ().text = "您們在這兩種套餐打上Ｘ的記號。";
			break;
		}
		case 25://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)(需要辨識)";
			CustomerTextObj.GetComponentInChildren<Text> ().text = "對不起，\n我聽不懂。請您再說一次。";
			break;
		}
		case 26://服務生
			{
				Waiter.gameObject.SetActive (true);//開啟服務生對話框
				WaiterTextObj.gameObject.SetActive (true);//開啟服務生要講話的物件
				Waiter.GetComponentInChildren<Text> ().text = "服務生";
				WaiterTextObj.GetComponentInChildren<Text> ().text = "打差表示不要。打勾表示需要。";
			break;
		}
		case 27://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
			CustomerTextObj.GetComponentInChildren<Text> ().text = "啊！\n我們國家是用打差的記號，\n來表示我們的需要。";
			break;
		}
		case 28://服務生
			{
				Waiter.gameObject.SetActive (true);//開啟服務生對話框
				WaiterTextObj.gameObject.SetActive (true);//開啟服務生要講話的物件
				Waiter.GetComponentInChildren<Text> ().text = "服務生";
				WaiterTextObj.GetComponentInChildren<Text>().text = "真的很抱歉，\n這是我們的疏失，\n我請廚師特別做了特餐，\n來補償你們。";
				

				break;
		}
		case 29://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "真的!感謝您";
			break;
		}
		case 30://服務生
			{
				Waiter.gameObject.SetActive (true);//開啟服務生對話框
				WaiterTextObj.gameObject.SetActive (true);//開啟服務生要講話的物件
				Waiter.GetComponentInChildren<Text> ().text = "服務生";
			WaiterTextObj.GetComponentInChildren<Text> ().text = "但是提醒您，\n下次請不要將需要餐點\n做打差的記號。";
			break;
		}
		case 31://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "好。我懂了";
			break;
		}
		case 32://茱莉
			{
				Customer.gameObject.SetActive (true);//開啟對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "茱莉";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "這間店服務真好";
			break;
		}
		case 33://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "還需要點菜嗎";
			break;}

		case 34://茱莉
			{
				Customer.gameObject.SetActive (true);//開啟茱莉對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟茱莉要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "茱莉";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "不，我已經很飽了";
			break;
		}
		case 35://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
			CustomerTextObj.GetComponentInChildren<Text> ().text = "我也很飽了。\n可是我很渴。\n我想加點一杯飲料。";
			break;
		}
		case 36://茱莉
			{
				Customer.gameObject.SetActive (true);//開啟茱莉對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟茱莉要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "茱莉";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "我也很渴";
			break;
		}
		case 37://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "你要不要點飲料?";
			break;
		}
		case 38://茱莉
			{
				Customer.gameObject.SetActive (true);//開啟茱莉對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟茱莉要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "茱莉";
			CustomerTextObj.GetComponentInChildren<Text> ().text = "我不想點飲料。\n我想加點一碗湯";
			break;
		}
		case 39://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "好";
			break;
		}
		case 40://茱莉
			{
				Customer.gameObject.SetActive (true);//開啟茱莉對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟茱莉要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "茱莉";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "老闆，結帳";
			break;
		}
		case 41://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "總共多少錢?";
			break;
		}
		case 42://老闆
			{
				Chef.gameObject.SetActive (true);//開啟老闆對話框
				ChefTextObj.gameObject.SetActive (true);//開啟老闆要講話的物件
				Chef.GetComponentInChildren<Text> ().text = "老闆";
				ChefTextObj.GetComponentInChildren<Text> ().text = "請稍後，讓我為您結算。";
			break;
		}
		case 43://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "請問我可以刷卡嗎?";
			break;
		}
		case 44://
			{
				Chef.gameObject.SetActive (true);//開啟老闆對話框
				ChefTextObj.gameObject.SetActive (true);//開啟老闆要講話的物件
				Chef.GetComponentInChildren<Text> ().text = "老闆";
				ChefTextObj.GetComponentInChildren<Text> ().text = "可以的。請給我你的信用卡。";
			break;
		}
		case 45://彼得
			{
				Customer.gameObject.SetActive (true);//開啟彼得對話框
				CustomerTextObj.gameObject.SetActive (true);//開啟彼得要講話的物件
				Customer.GetComponentInChildren<Text> ().text = "彼得(需要辨識)";
				CustomerTextObj.GetComponentInChildren<Text> ().text = "請刷這張，謝謝。";
			break;
		}
		case 46://老闆
			{
				Chef.gameObject.SetActive (true);//開啟老闆對話框
				ChefTextObj.gameObject.SetActive (true);//開啟老闆要講話的物件
				Chef.GetComponentInChildren<Text> ().text = "老闆";
				ChefTextObj.GetComponentInChildren<Text> ().text = "感謝您的惠顧，歡迎再次光臨。";
			break;
		}*/

		}
	}



	void CloseAllTextBox()//關閉所有對話框
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
							
							TalkSwitch++;//玩家對話狀態+1
							CloseAllTextBox();//每次畫面刷新都先關閉所有物件
						}
						public void BackButtonClick()//上一步
						{
							TalkSwitch--;//玩家對話狀態-1
							CloseAllTextBox();//每次畫面刷新都先關閉所有物件
							
							
						}
						public void ExitButtonClick()//退出
						{
							
							TalkSwitch = 27;//離開鍵的狀態釋放區
							CloseAllTextBox();//每次畫面刷新都先關閉所有物件
						}


	public void resettime()//計時器歸零
	{
			Timer=0.0f;
	}
}

