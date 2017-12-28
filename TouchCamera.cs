// Just add this script to your camera. It doesn't need any configuration.

using UnityEngine;
using UnityEngine.UI;
using System;
public class TouchCamera  : MonoBehaviour {
	bool PCEditor;
	void Start()
	{
		OldPos = transform.position;
		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor) 
		{
			PCEditor = true;			
		}

	}

	public Vector3 OldPos;
	public float dragSpeed=2;
	private Vector3 dragOrigin;
	bool istouch;
	public InputField DragSpeed;
	public Text DragCount;
	string ShowMsg;
	Vector3 move ;
	int TopIDZero;
	Vector3 TempDist;
	float ShowTempDist;
	public Toggle UsePlan;
	public void Reset()
	{
		transform.position = new Vector3 (0, 6, -10);
		transform.eulerAngles = new Vector3(30,0,0);
	}
	void Update() {
		
		//dragSpeed = float.Parse(DragSpeed.text);

		if (PCEditor) 
		{
			if (Input.GetMouseButtonDown(0))
			{
				dragOrigin = Input.mousePosition;
				return;
			}

			if (!Input.GetMouseButton (0)) 
			{
				OldPos = transform.position;
				return;

			}

			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
			Vector3 move = new Vector3(OldPos.x-(pos.x*dragSpeed), OldPos.y,OldPos.z -(pos.y*dragSpeed));
			transform.position = move;

		}

		else 
		{
			if (Input.touchCount > 1 && Input.GetTouch(0).phase == TouchPhase.Moved) 
			{
				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
					transform.Translate (-touchDeltaPosition.x * 0.01f,0,-touchDeltaPosition.y * 0.01f);
					transform.position=new Vector3(transform.position.x,6,transform.position.z);
					DragCount.text = transform.position.ToString ();
			
			}

		}
	}
}