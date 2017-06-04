using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Selector))]
public class SelectorEditor : Editor {
	public override void OnInspectorGUI ( )
	{
		Selector selector = ( Selector )target;
		DrawDefaultInspector();

		EditorGUILayout.BeginHorizontal();
		if ( GUILayout.Button("選擇以上物件") )
		{
			Selector.選擇場景內物件 ( selector.遊戲物件清單 );
		}

	}

}
