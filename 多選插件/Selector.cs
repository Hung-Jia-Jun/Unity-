using UnityEngine;
using System.Collections;
using UnityEditor;

public class Selector : MonoBehaviour
{
	public GameObject [ ] 遊戲物件清單;
	public static void 選擇場景內物件 ( GameObject [ ] 遊戲物件清單 )
	{
		Selection.objects = 遊戲物件清單;
	}

}