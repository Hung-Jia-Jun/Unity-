using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {
	public GameObject[] SoundArray;//聲音陣列
	public string SoundArrayText;
	public float Timer;
	// Use this for initialization
	void Start () {
	DontDestroyOnLoad(transform.gameObject);
	SoundArray[0] = GameObject.Find("SoundArray (1)");//1.請問，還有空位嗎?
    SoundArray[1] = GameObject.Find("SoundArray (2)");//2.有的，請問，您們是兩位用餐嗎? 
    SoundArray[2] = GameObject.Find("SoundArray (3)");//4.好的，請往這邊。
    SoundArray[3] = GameObject.Find("SoundArray (4)");//5.請問，你們有沒有套餐?
    SoundArray[4] = GameObject.Find("SoundArray (5)");//6.我們目前有四種套餐。
    SoundArray[5] = GameObject.Find("SoundArray (6)");//8.沒關係，稍後再為您服務。
    SoundArray[6] = GameObject.Find("SoundArray (7)");//10.我要點一份A套餐。彼得你呢?
    SoundArray[7] = GameObject.Find("SoundArray (8)");//12.OK，那就這樣決定了。
    SoundArray[8] = GameObject.Find("SoundArray (9)");//14.好的，為您確認一下餐點。一份A餐和一份C餐。
    SoundArray[9] = GameObject.Find("SoundArray (10)");//15.請問飲品要餐前上還是餐後上呢?
    SoundArray[10] = GameObject.Find("SoundArray (11)");//16.我想先上飲料，彼得你呢?
    SoundArray[11] = GameObject.Find("SoundArray (12)");//18.好的，稍後會為您上飲品
    SoundArray[12] = GameObject.Find("SoundArray (13)");//20.不，我沒點這個套餐。
    SoundArray[13] = GameObject.Find("SoundArray (14)");//21.請問有什麼需要呢?
    SoundArray[14] = GameObject.Find("SoundArray (15)");//23.請稍後，我們確認一下餐點。
    SoundArray[15] = GameObject.Find("SoundArray (16)");//24.您們在這兩種套餐打上Ｘ的記號。
    SoundArray[16] = GameObject.Find("SoundArray (17)");//26.打差表示不要。打勾表示需要。
    SoundArray[17] = GameObject.Find("SoundArray (18)");//28. 真的很抱歉，這是我們的疏失，我請廚師特別做了特餐，來補償你們。
    SoundArray[18] = GameObject.Find("SoundArray (19)");//30. 但是提醒您，下次請不要將需要餐點做打差的記號。
    SoundArray[19] = GameObject.Find("SoundArray (20)");//32.這間店服務真好
    SoundArray[20] = GameObject.Find("SoundArray (21)");//34.不，我已經很飽了。
    SoundArray[21] = GameObject.Find("SoundArray (22)");//36.我也很渴。
    SoundArray[22] = GameObject.Find("SoundArray (23)");//38.我不想點飲料。我想加點一碗湯。
    SoundArray[23] = GameObject.Find("SoundArray (24)");//40.老闆，結帳。
    SoundArray[24] = GameObject.Find("SoundArray (25)");//43.請稍後，讓我為您結算。
    SoundArray[25] = GameObject.Find("SoundArray (26)");//45.可以的。請給我你的信用卡。
    SoundArray[26] = GameObject.Find("SoundArray (27)");//47.感謝您的惠顧，歡迎再次光臨。
    closeAllMusic();
    Timer=0.0f;
	}
	
	
	void Update () {

	}


public void closeAllMusic()
{
	for (int i=0;i<27;i++)
	{
		SoundArray[i].gameObject.SetActive(false);//關閉所有聲音物件
	}
}

public void ChooseMusic(int i)//選擇播放之物件
{
	SoundArray[i].gameObject.SetActive(true);//設定要播放哪個物件
	Timer=0.0f;
	if (Timer>5)
	{
		SoundArray[i].gameObject.SetActive(false);//關閉要播放哪個物件
	}
}

}
