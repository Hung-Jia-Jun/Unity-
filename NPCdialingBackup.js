#pragma strict
//角色
var player 	: Transform;
var NPC 	: Transform; 
//鏡頭切換
var Camera0 : GameObject;
var Camera1 : GameObject;

var waiter 	: Animator;
var BS 		: AnimatorStateInfo;
var Idle 	: int = Animator.StringToHash("Base Layer.Idle");
var Hellow 	: int = Animator.StringToHash("Base Layer.Hellow");
var idleGrab : int = Animator.StringToHash("Base Layer.idleGrab");
//對話視窗//
private var talktext0  	: boolean;
private var talktext0_1 : boolean;
private var talktext1 	: boolean;
private var talktext1_1 : boolean;
private var talktext2 	: boolean;
private var talktext2_1 : boolean;
private var talktext3 	: boolean;
private var talktext3_1 : boolean;
private var talktext4 	: boolean;
private var talktext4_1 : boolean;
private var talktext4_2 : boolean;
private var talktext5 	: boolean;
private var talktext5_1 : boolean;
private var talktext6 	: boolean;
private var talktext6_1 : boolean;
private var talktext7 	: boolean;
private var talktext7_1 : boolean;
private var talktext8 	: boolean;
private var talktext8_1 : boolean;
private var talktext9 	: boolean;
private var talktext9_1 : boolean;
private var talktext10 	 : boolean;
private var talktext10_1 : boolean;
private var talktext11 	 : boolean;
private var talktext11_1 : boolean;
private var talktext12 	 : boolean;
private var talktext12_1 : boolean;
//
public var Reproducir = false;
private var dis 		: float;//紀錄主角與NPC的距離用
//按鈕顏色
var btnStyle 	: GUIStyle;
var btnStyle2 	: GUIStyle; 
var micStyle	: GUIStyle;//麥克風按鈕圖片
//NPC播放聲音
var	sound		: AudioClip[];
//Text檔
var txtopen		: TextAsset;
//exe檔
//----------------------------------------------------------------------------------------------
function Textopen()//開啟text
{
	
}
//----------------------------------------------------------------------------------------------
function SpeachStart()//開啟語音辨識
{
	//System.Diagnostics.Process.Start("WindowsFormsApplication2.exe");
}
//----------------------------------------------------------------------------------------------
function Start()
{		

}
//----------------------------------------------------------------------------------------------
function CameraFalse()
{		
	Camera0.active=true;
	Camera1.active=false;
}
//----------------------------------------------------------------------------------------------
function onActiveFalse()
{
	waiter.SetBool("idleGrab",true);
	waiter.SetBool("idleGrab",false);
	waiter.SetBool("Hellow",false);
    talktext0  = false;
    talktext0_1= false;
	talktext1  = false;
	talktext1_1= false;
	talktext2  = false;	
    talktext2_1= false;	
	talktext3  = false;
    talktext3_1= false;
	talktext4  = false;
    talktext4_1= false;
    talktext4_2= false;
	talktext5  = false;	
    talktext5_1= false;
	talktext6  = false;	
	talktext6_1= false;
	talktext7  = false;	
	talktext7_1= false;
	talktext8  = false;	
	talktext8_1= false;
	talktext9  = false;
	talktext9_1= false;
	talktext10 = false;	
	talktext10_1= false;
	talktext11 = false;
	talktext11_1= false;
	talktext12  = false;	
	talktext12_1= false;
}
//----------------------------------------------------------------------------------------------
function Update () 
{
	dis = Vector3.Distance(NPC.transform.position, player.position);//計算主角與NPC距離
	
	if (dis < 25)//當主角靠近NPC時
	{
		NPC.transform.LookAt(player);//NPC面向主角
		NPC.transform.eulerAngles = Vector3(0, NPC.transform.eulerAngles.y, 0);
	}
}
//進入觸發區域後啟動對話
//----------------------------------------------------------------------------------------------
function OnTriggerEnter (other : Collider)
{
	BS = waiter.GetCurrentAnimatorStateInfo(0);
	if (other == player.collider && dis < 15 && !talktext0)
		onActiveFalse();
		CameraFalse();
		Camera0.active=false;
		Camera1.active=true;
		talktext0 = true;
		audio.clip=sound[0];
		audio.Play();
		//招手動作idleGrab啟動
		if(BS.nameHash == idleGrab)
		{	
			if(!waiter.IsInTransition(0))
			waiter.SetBool("idleGrab",true);
			waiter.SetBool("Hellow",true);
		}		
}
//----------------------------------------------------------------------------------------------
function wait0()//waiter框顯示
{
	Reproducir = true;
	yield WaitForSeconds(4.4f);
	onActiveFalse();
	talktext0_1 = true;
}
//----------------------------------------------------------------------------------------------
function wait0_1()//waiter框+功能框顯示
{
	Reproducir = true;
	yield WaitForSeconds(3.5f);
	audio.Play();
	onActiveFalse();
	talktext1 = true;
}
//----------------------------------------------------------------------------------------------
function wait1()//waiter框顯示
{
	Reproducir = true;
	yield WaitForSeconds(5f);
	onActiveFalse();
	talktext1_1 = true;
}
//----------------------------------------------------------------------------------------------
function wait1_1()//waiter框+功能框顯示
{
	Reproducir = true;
	yield WaitForSeconds(3.5f);
	audio.Play();
	onActiveFalse();
	talktext2 = true;
}
//----------------------------------------------------------------------------------------------
function wait2()//waiter框顯示
{
	Reproducir = true;
	yield WaitForSeconds(3f);
	onActiveFalse();
	talktext2_1 = true;
}
//----------------------------------------------------------------------------------------------
function wait2_1()//waiter框+功能框顯示
{
	Reproducir = true;
	yield WaitForSeconds(3.5f);
	audio.Play();
	onActiveFalse();
	talktext3 = true;
}
//----------------------------------------------------------------------------------------------
function wait3()//waiter框顯示
{
	Reproducir = true;
	yield WaitForSeconds(11.5f);
	onActiveFalse();
	talktext3_1 = true;
}
//----------------------------------------------------------------------------------------------
function wait3_1()//waiter框+功能框顯示
{
	Reproducir = true;
	yield WaitForSeconds(2);
	audio.Play();
	onActiveFalse();
	talktext4 = true;

}
//----------------------------------------------------------------------------------------------
function wait4()//waiter框顯示
{
	Reproducir = true;
	yield WaitForSeconds(3.2f);
	onActiveFalse();
	talktext4_1 = true;
}
//----------------------------------------------------------------------------------------------
function wait4_1()//waiter框+功能框顯示
{
	Reproducir = true;
	yield WaitForSeconds(3.5f);
	onActiveFalse();
	talktext5 = true;
	audio.Play();
}
//----------------------------------------------------------------------------------------------
function wait5()//waiter框顯示
{
	Reproducir = true;
	yield WaitForSeconds(3.6f);
	onActiveFalse();
	talktext5_1 = true;
}
//----------------------------------------------------------------------------------------------
function wait5_1()//waiter框+功能框顯示
{
	Reproducir = true;
	yield WaitForSeconds(3.5f);
	onActiveFalse();
	talktext6 = true;
	audio.Play();
}
//----------------------------------------------------------------------------------------------
function wait6()//waiter框顯示
{
	Reproducir = true;
	yield WaitForSeconds(7.6f);
	onActiveFalse();
	talktext6_1 = true;
}
//----------------------------------------------------------------------------------------------
function wait6_1()//waiter框+功能框顯示
{
	Reproducir = true;
	yield WaitForSeconds(3.5f);
	onActiveFalse();
	talktext7 = true;
	audio.Play();
}
//----------------------------------------------------------------------------------------------
function wait7()//waiter框顯示
{
	Reproducir = true;
	yield WaitForSeconds(6.8f);
	onActiveFalse();
	talktext7_1 = true;
}

//----------------------------------------------------------------------------------------------
function wait7_1()//waiter框+功能框顯示
{
	Reproducir = true;
	yield WaitForSeconds(4f);
	onActiveFalse();
	talktext8 = true;
	audio.Play();
}
//----------------------------------------------------------------------------------------------
function wait8()//waiter框顯示
{
	Reproducir = true;
	yield WaitForSeconds(5.2f);
	onActiveFalse();
	talktext8_1 = true;
}

//----------------------------------------------------------------------------------------------
function wait8_1()//waiter框+功能框顯示
{
	Reproducir = true;
	yield WaitForSeconds(5f);
	onActiveFalse();
	talktext9 = true;
	audio.Play();
}
//----------------------------------------------------------------------------------------------
function wait9()//waiter框顯示
{
	Reproducir = true;
	yield WaitForSeconds(5.4f);
	onActiveFalse();
	talktext9_1 = true;
}

//----------------------------------------------------------------------------------------------
function wait9_1()//waiter框+功能框顯示
{
	Reproducir = true;
	yield WaitForSeconds(5f);
	onActiveFalse();
	talktext10 = true;
	audio.Play();
}
//----------------------------------------------------------------------------------------------
function wait10()//waiter框顯示
{
	Reproducir = true;
	yield WaitForSeconds(5.8f);
	onActiveFalse();
	talktext10_1 = true;
}

//----------------------------------------------------------------------------------------------
function wait10_1()//waiter框+功能框顯示
{
	Reproducir = true;
	yield WaitForSeconds(3.5f);
	onActiveFalse();
	talktext11 = true;
	audio.Play();
}
//----------------------------------------------------------------------------------------------
function wait11()//waiter框顯示
{
	Reproducir = true;
	yield WaitForSeconds(3.1f);
	onActiveFalse();
	talktext11_1 = true;
}

//----------------------------------------------------------------------------------------------
function wait11_1()//waiter框+功能框顯示
{
	Reproducir = true;
	yield WaitForSeconds(3.5f);
	onActiveFalse();
	talktext12 = true;
	audio.Play();
}
//----------------------------------------------------------------------------------------------
function OnGUI () 
{
//----------------------------------------------------------------------------------------------
	if (talktext0)
	{
/*左*/	wait0();
		GUI.skin.box.alignment = TextAnchor.MiddleLeft;
		GUI.skin.box.fontSize = 13;
		GUI.skin.textArea.alignment = TextAnchor.MiddleLeft;
		GUI.skin.textArea.fontSize = 15;
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		GUI.TextArea(Rect(Screen.width/2 -550,Screen.height/2 -250, 400, 200), "歡迎光臨，您好，很高興為您服務！");//waiter對話框	
	
	if(Reproducir == true)
		{
			Reproducir = false;

/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{
				onActiveFalse();
				talktext0_1  = true;
				Reproducir = false;
			}else{
				audio.Stop();
				onActiveFalse();
				talktext0_1  = true;
				Reproducir = false;
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{
				onActiveFalse();
				talktext0  = true;
				Reproducir = false;
				audio.clip=sound[0];
				audio.Play();
			}else{
				audio.Stop();
				onActiveFalse();
				talktext0  = true;
				Reproducir = false;
				audio.clip=sound[0];
				audio.Play();
				}
			}
		}
	}
//----------------------------------------------------------------------------------------------
	if (talktext0_1)
	{
/*右*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250, 200), "");//系統提示框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250,  22), "<color=#ff0000>系統提示:</color>下列句子按錄音鍵後，請說出");//系統提示字框(左
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -215, 250,  60), "● 請問，還有空房嗎?");//內容提示字框

/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext1    = true;
				Reproducir = false;
				audio.clip = sound[2];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext1    = true;
				Reproducir = false;
				audio.clip = sound[2];
				audio.Play();
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext0 = true;
				Reproducir = false;
				audio.clip = sound[0];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext0 = true;
				Reproducir = false;
				audio.clip = sound[0];
				audio.Play();
			}
		}
/*錄*/	if( GUI.Button (Rect (Screen.width/2 +230, Screen.height/2 -105, 40, 40), "",micStyle)&& Reproducir == false)
		{ 
			wait0_1();
			if(Reproducir == true)
			{
				audio.clip = sound[2];
				Reproducir = false;
			}
		} 
	}
//----------------------------------------------------------------------------------------------
	if (talktext1)
	{
/*左*/	wait1();
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		GUI.TextArea(Rect(Screen.width/2 -550,Screen.height/2 -250, 400, 200), "有的。請問您要單人房或者雙人房?");//waiter對話框	
	
	if(Reproducir == true)
		{
			Reproducir = false;
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步", btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext1_1    = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext1_1    = true;
				Reproducir = false;
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步", btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext0_1 = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext0_1 = true;
				Reproducir = false;
				}
			}
		}
	}
//----------------------------------------------------------------------------------------------
	if (talktext1_1)
	{
/*右*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250, 220), "");//系統提示框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250,  22), "<color=#ff0000>系統提示:</color>下列句子按錄音鍵後請擇一說出");//系統提示字框(左

		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框

		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -210, 250,  60), "● 我要一間單人房。");//內容提示字框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -150, 250,  60), "● 我要一間雙人房。");//內容提示字框

/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext2  = true;
				Reproducir = false;
				audio.clip = sound[5];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext2  = true;
				Reproducir = false;
				audio.clip = sound[5];
				audio.Play();
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext1 = true;
				Reproducir = false;
				audio.clip = sound[2];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext1 = true;
				Reproducir = false;
				audio.clip = sound[2];
				audio.Play();
			}
		}
/*錄*/	if( GUI.Button (Rect (Screen.width/2 +230, Screen.height/2 -80, 40, 40), "",micStyle)&& Reproducir == false)
		{ 
			wait1_1();
		if(Reproducir == true)
			{
			audio.clip = sound[5];
			Reproducir = false;
			}
		} 
	}
//----------------------------------------------------------------------------------------------
	if (talktext2)
	{
		wait2();
/*左*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		GUI.TextArea(Rect(Screen.width/2 -550,Screen.height/2 -250, 400, 200),"請問，您要住幾天?");//waiter對話框
	if(Reproducir == true)
		{
			Reproducir = false;
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext2_1    = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext2_1    = true;
				Reproducir = false; 
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext1_1 = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext1_1 = true;
				Reproducir = false;
				}
			}
		}
	}
//----------------------------------------------------------------------------------------------
	if (talktext2_1)
	{
/*右*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250, 180), "");//系統提示框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250,  22), "<color=#ff0000>系統提示:</color>下列句子按錄音鍵後，請說出");//系統提示字框(左
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -210, 250,  60), "● 我住一晚，明早退房。");//內容提示字框
		
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext3  = true;
				Reproducir = false;
				audio.clip = sound[36];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext3  = true;
				Reproducir = false;
				audio.clip = sound[36];
				audio.Play();
				}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext2 = true;
				Reproducir = false;
				audio.clip = sound[5];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext2 = true;
				Reproducir = false;
				audio.clip = sound[5];
				audio.Play();
				}
		}
/*錄*/	if( GUI.Button (Rect (Screen.width/2 +230, Screen.height/2 -120, 40, 40), "",micStyle)&& Reproducir == false)
		{ 
			wait2_1();
		if(Reproducir == true)
			{
			audio.clip = sound[36];
			Reproducir = false;
			}
		}  
	}
//----------------------------------------------------------------------------------------------
	if (talktext3)
	{
		wait3();
/*左*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		GUI.TextArea(Rect(Screen.width/2 -550,Screen.height/2 -250, 400, 200),"請等一下。我確認一下房間狀況。\n 我們目前還剩三間單人房。\n一間日月潭美景房，兩間大街風景房。");//waiter對話框

	if(Reproducir == true)
		{
			Reproducir = false;
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext3_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext3_1  = true;
				Reproducir = false;
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext2_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext2_1  = true;
				Reproducir = false;	
				}
			}
		}
	}
//----------------------------------------------------------------------------------------------
	if (talktext3_1)
	{
/*右*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250, 220), "");//系統提示框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250,  22), "<color=#ff0000>系統提示:</color>下列句子按錄音鍵後請擇一說出");//系統提示字框(左
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框

		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -210, 250,  60), "● 我要一間大街風景房。");//內容提示字框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -150, 250,  60), "● 我要一間日月潭美景房。");//內容提示字框

/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext4    = true;
				Reproducir = false;
				audio.clip = sound[10];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext4   = true;
				Reproducir = false;
				audio.clip = sound[10];
				audio.Play();
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext3 = true;
				Reproducir = false;
				audio.clip = sound[36];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext3 = true;
				Reproducir = false;
				audio.clip = sound[36];
				audio.Play();
			}
		}
/*錄*/	if( GUI.Button (Rect (Screen.width/2 +230, Screen.height/2 -80, 40, 40), "",micStyle)&& Reproducir == false)
		{ 
			wait3_1();
		if(Reproducir == true)
			{
			audio.clip = sound[10];
			Reproducir = false;
			}
		} 
	}
//----------------------------------------------------------------------------------------------
	if (talktext4)
	{
		wait4();
/*左*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		GUI.TextArea(Rect(Screen.width/2 -550,Screen.height/2 -250, 400, 200),"好的，請問還有什麼需要嗎?");//waiter對話框
	if(Reproducir == true)
		{
			Reproducir = false;		
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext4_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext4_1  = true;
				Reproducir = false;
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext3_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext3_1  = true;
				Reproducir = false;	
				}
			}
		}
	}
//----------------------------------------------------------------------------------------------
	if (talktext4_1)
	{
/*右*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250, 200), "");//系統提示框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250,  22), "<color=#ff0000>系統提示:</color>下列句子按錄音鍵後，請說出");//系統提示字框(左
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -210, 250,  60), "● 請問，有附早餐嗎?");//內容提示字框

/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext5    = true;
				Reproducir = false;
				audio.clip = sound[16];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext5   = true;
				Reproducir = false;
				audio.clip = sound[16];
				audio.Play();
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext4 = true;
				Reproducir = false;
				audio.clip = sound[10];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext4 = true;
				Reproducir = false;
				audio.clip = sound[10];
				audio.Play();
			}
		}
/*錄*/	if( GUI.Button (Rect (Screen.width/2 +230, Screen.height/2 -100, 40, 40), "",micStyle)&& Reproducir == false)
		{ 
			wait4_1();
		if(Reproducir == true)
			{
			audio.clip = sound[16];
			Reproducir = false;
			}
		} 
	}
//----------------------------------------------------------------------------------------------
	if (talktext5)
	{
		wait5();
/*左*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		GUI.TextArea(Rect(Screen.width/2 -550,Screen.height/2 -250, 400, 200), "有的。早餐有中式和西式早餐。");//waiter對話框
	if(Reproducir == true)
		{
			Reproducir = false;			
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext5_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext5_1  = true;
				Reproducir = false;
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext4_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext4_1  = true;
				Reproducir = false;	
				}
			}
		}
	}
//----------------------------------------------------------------------------------------------
	if (talktext5_1)
	{
/*右*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250, 200), "");//系統提示框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250,  22), "<color=#ff0000>系統提示:</color>下列句子按錄音鍵後，請說出");//系統提示字框(左

		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框

		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -210, 250,  60), "● 好的，請幫我辦理入住手續。");//內容提示字框
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext6    = true;
				Reproducir = false;
				audio.clip = sound[19];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext6   = true;
				Reproducir = false;
				audio.clip = sound[19];
				audio.Play();
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext5 = true;
				Reproducir = false;
				audio.clip = sound[16];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext5 = true;
				Reproducir = false;
				audio.clip = sound[16];
				audio.Play();
			}
		}
/*錄*/	if( GUI.Button (Rect (Screen.width/2 +230, Screen.height/2 -100, 40, 40), "",micStyle)&& Reproducir == false)
		{ 
			wait5_1();
		if(Reproducir == true)
			{
			audio.clip = sound[19];
			Reproducir = false;
			}
		} 
	}
//----------------------------------------------------------------------------------------------
	if (talktext6)
	{
		wait6();
/*左*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		GUI.TextArea(Rect(Screen.width/2 -550,Screen.height/2 -250, 400, 200),"稍等一下，讓我為您核對資料。\n 請問，您的姓氏是「林」還是「得」呢?");//waiter對話框

	if(Reproducir == true)
		{
			Reproducir = false;			
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext6_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext6_1  = true;
				Reproducir = false;
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext5_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext5_1  = true;
				Reproducir = false;	
				}
			}
		}
	}	
//----------------------------------------------------------------------------------------------
	if (talktext6_1)
	{
/*右*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250, 200), "");//系統提示框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250,  22), "<color=#ff0000>系統提示:</color>下列句子按錄音鍵後，請說出");//系統提示字框(左
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框

		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -210, 250,  60), "● 我姓林，名彼得。");//內容提示字框

/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext7    = true;
				Reproducir = false;
				audio.clip = sound[22];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext7   = true;
				Reproducir = false;
				audio.clip = sound[22];
				audio.Play();
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext6 = true;
				Reproducir = false;
				audio.clip = sound[19];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext6 = true;
				Reproducir = false;
				audio.clip = sound[19];
				audio.Play();
			}
		}
/*錄*/	if( GUI.Button (Rect (Screen.width/2 +230, Screen.height/2 -100, 40, 40), "",micStyle)&& Reproducir == false)
		{ 
			wait6_1();
		if(Reproducir == true)
			{
			audio.clip = sound[22];
			Reproducir = false;
			}
		} 
	}
//----------------------------------------------------------------------------------------------
	if (talktext7)
	{
		wait7();
/*左*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		GUI.TextArea(Rect(Screen.width/2 -550,Screen.height/2 -250, 400, 200), "提醒您，\n 中文先寫姓，再寫名。\n 西文先寫名，再寫姓。");//waiter對話框
	if(Reproducir == true)
		{
			Reproducir = false;					
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext7_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext7_1  = true;
				Reproducir = false;
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext6_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext6_1  = true;
				Reproducir = false;
				}
			}
		}
	}
//----------------------------------------------------------------------------------------------
	if (talktext7_1)
	{
/*右*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250, 200), "");//系統提示框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250,  22), "<color=#ff0000>系統提示:</color>下列句子按錄音鍵後，請說出");//系統提示字框(左
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框


		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -210, 250,  60), "● 我這樣填寫有要更改的地方嗎?");//內容提示字框

/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext8    = true;
				Reproducir = false;
				audio.clip = sound[24];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext8   = true;
				Reproducir = false;
				audio.clip = sound[24];
				audio.Play();
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext7    = true;
				Reproducir = false;
				audio.clip = sound[22];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext7   = true;
				Reproducir = false;
				audio.clip = sound[22];
				audio.Play();
			}
		}
/*錄*/	if( GUI.Button (Rect (Screen.width/2 +230, Screen.height/2 -100, 40, 40), "",micStyle)&& Reproducir == false)
		{ 
			wait7_1();
		if(Reproducir == true)
		{
			audio.clip = sound[24];
			Reproducir = false;
		}
		} 		
	}	
//----------------------------------------------------------------------------------------------
	if (talktext8)
	{
		wait8();
/*左*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		GUI.TextArea(Rect(Screen.width/2 -550,Screen.height/2 -250, 400, 200), "資料填寫無誤。\n 您姓林? 請問您是混血兒嗎?");//waiter對話框				
	if(Reproducir == true)
		{
			Reproducir = false;
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext8_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext8_1  = true;
				Reproducir = false;
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext7_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext7_1  = true;
				Reproducir = false;
				}
			}
		}
	}
//----------------------------------------------------------------------------------------------
	if (talktext8_1)
	{
/*右*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250, 200), "");//系統提示框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250,  22), "<color=#ff0000>系統提示:</color>下列句子按錄音鍵後，請說出");//系統提示字框(左)
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框

		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -210, 250,  60), "● 我是外籍，所以有些特別。");//內容提示字框
	
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext9    = true;
				Reproducir = false;
				audio.clip = sound[26];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext9   = true;
				Reproducir = false;
				audio.clip = sound[26];
				audio.Play();
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext8    = true;
				Reproducir = false;
				audio.clip = sound[24];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext8   = true;
				Reproducir = false;
				audio.clip = sound[24];
				audio.Play();
			}
		}
/*錄*/	if( GUI.Button (Rect (Screen.width/2 +230, Screen.height/2 -100, 40, 40), "",micStyle)&& Reproducir == false)
		{ 
			wait8_1();
		if(Reproducir == true)
		{
			audio.clip = sound[26];
			Reproducir = false;
		}
		} 
	}
//----------------------------------------------------------------------------------------------
	if (talktext9)
	{
		wait9();
/*左*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		GUI.TextArea(Rect(Screen.width/2 -550,Screen.height/2 -250, 400, 200), "原來如此，\n 我需要核對身分，請問您的護照號碼是?");//waiter對話框
	if(Reproducir == true)
		{
			Reproducir = false;	
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext9_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext9_1  = true;
				Reproducir = false;
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext8_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext8_1  = true;
				Reproducir = false;
				}
			}
		}
	}
//----------------------------------------------------------------------------------------------
	if (talktext9_1)
	{
/*右*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250, 200), "");//系統提示框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250,  22), "<color=#ff0000>系統提示:</color>下列句子按錄音鍵後，請說出");//系統提示字框(左
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		

		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -210, 250,  60), "● 我的護照號碼是767741233。");//內容提示字框
	
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext10    = true;
				Reproducir = false;
				audio.clip = sound[29];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext10   = true;
				Reproducir = false;
				audio.clip = sound[29];
				audio.Play();
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext9    = true;
				Reproducir = false;
				audio.clip = sound[26];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext9   = true;
				Reproducir = false;
				audio.clip = sound[26];
				audio.Play();
			}
		}
/*錄*/	if( GUI.Button (Rect (Screen.width/2 +230, Screen.height/2 -100, 40, 40), "",micStyle)&& Reproducir == false)
		{ 
			wait9_1();
		if(Reproducir == true)
			{
			audio.clip = sound[29];
			Reproducir = false;
			}
		} 
	}
//----------------------------------------------------------------------------------------------
	if (talktext10)
	{
		wait10();
/*左*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		GUI.TextArea(Rect(Screen.width/2 -550,Screen.height/2 -250, 400, 200), "確認完畢。\n 這是您的房間鑰匙，1020。");//waiter對話框
	if(Reproducir == true)
		{
			Reproducir = false;	
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext10_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext10_1  = true;
				Reproducir = false;
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext9_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext9_1  = true;
				Reproducir = false;
				}
			}
		}
	}	
//----------------------------------------------------------------------------------------------
	if (talktext10_1)
	{
/*右*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250, 200), "");//系統提示框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250,  22), "<color=#ff0000>系統提示:</color>下列句子按錄音鍵後，請說出");//系統提示字框(左
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		

		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -210, 250,  60), "● 請問能讓我先結帳嗎?");//內容提示字框
	
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext11    = true;
				Reproducir = false;
				audio.clip = sound[31];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext11   = true;
				Reproducir = false;
				audio.clip = sound[31];
				audio.Play();
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext10 = true;
				Reproducir = false;
				audio.clip = sound[29];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext10 = true;
				Reproducir = false;
				audio.clip = sound[29];
				audio.Play();
			}
		}
/*錄*/	if( GUI.Button (Rect (Screen.width/2 +230, Screen.height/2 -100, 40, 40), "",micStyle)&& Reproducir == false)
		{ 
			wait10_1();
		if(Reproducir == true)
			{
			audio.clip = sound[31];
			Reproducir = false;
			}
		} 
	}
//----------------------------------------------------------------------------------------------
	if (talktext11)
	{
		wait11();
/*左*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 30, 250,  50), "");//按鈕框
		GUI.TextArea(Rect(Screen.width/2 -550,Screen.height/2 -250, 400, 200),"可以的，請問您的付費方式是?");//waiter對話框
	if(Reproducir == true)
		{
			Reproducir = false;	
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 -25, 90, 40), "下一步 ",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext11_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext11_1  = true;
				Reproducir = false;
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 -25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext10_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext10_1  = true;
				Reproducir = false;
				}
			}
		}
	}
//----------------------------------------------------------------------------------------------
	if (talktext11_1)
	{
/*右*/	GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250, 270), "");//系統提示框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -250, 250,  22), "<color=#ff0000>系統提示:</color>下列句子按錄音鍵後請擇一說出");//系統提示字框(左
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 + 20, 250,  50), "");//按鈕框
		

		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -210, 250,  60), "● 我要付現金，請你點一下。");//內容提示字框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -150, 250,  60), "● 我要刷卡，請你刷這張。");//內容提示字框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 - 90, 250,  55), "● 我要手機支付，請讓我掃QRCode。");//內容提示字框
	
/*下*/	if( GUI.Button (Rect (Screen.width/2 +250, Screen.height/2 +25, 90, 40), "下一步 ",btnStyle))
		{
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext12    = true;
				Reproducir = false;
				audio.clip = sound[35];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext12   = true;
				Reproducir = false;
				audio.clip = sound[35];
				audio.Play();
			}
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +150, Screen.height/2 +25, 90, 40), "上一步",btnStyle))
		{ 	
			if(!audio.isPlaying)
			{	//沒音
				onActiveFalse();
				talktext11    = true;
				Reproducir = false;
				audio.clip = sound[31];
				audio.Play();
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext11   = true;
				Reproducir = false;
				audio.clip = sound[31];
				audio.Play();
			}
		}
/*錄*/	if( GUI.Button (Rect (Screen.width/2 +230, Screen.height/2 -30, 40, 40), "",micStyle)&& Reproducir == false)
		{ 
			wait11_1();
		if(Reproducir == true)
			{
			audio.clip = sound[35];
			Reproducir = false;
			}
		} 
	}
//----------------------------------------------------------------------------------------------
	if (talktext12)
	{
/*左*/	GUI.TextArea(Rect(Screen.width/2 -550,Screen.height/2 -250, 400, 200),"感謝您的入住，祝您旅途愉快。");//waiter對話框
		GUI.Box(Rect(Screen.width/2 +120,Screen.height/2 -30, 250,  50), "");//按鈕框

/*結*/	if( GUI.Button (Rect (Screen.width/2 +290, Screen.height/2 -25, 70, 40), "結束",btnStyle))
		{ 	
			CameraFalse();
			onActiveFalse();
		}
/*R*/	if( GUI.Button (Rect (Screen.width/2 +210, Screen.height/2 -25, 70, 40), "重新開始",btnStyle))
		{ 	
			onActiveFalse();
			talktext0 = true;
			audio.clip = sound[0];
			audio.Play();
		}
/*上*/	if( GUI.Button (Rect (Screen.width/2 +130, Screen.height/2 -25, 70, 40), "上一步",btnStyle))
		{
			if(!audio.isPlaying)
			{//沒音
				onActiveFalse();
				talktext11_1  = true;
				Reproducir = false;
			}else{//有音
				audio.Stop();
				onActiveFalse();
				talktext11_1  = true;
				Reproducir = false;
			}
		}
	}							
}
