using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    private float X;//滑鼠X軸向量
    private float Y;//滑鼠Y軸向量
    public Transform target;//攝影機該對準的目標物件
    public float Xspeed=200F;//X軸旋轉速度
    public float Yspeed = 200;//Y軸旋轉速度
    public float mSpeed = 10;//自身旋轉速度
    public float yMinLimit =-50;//Y軸最小旋轉限制
    public float yMaxLimit = 50;//Y軸最大旋轉限制
    public Vector3 Angle;//角度
    void Start()
    {
        Angle = transform.eulerAngles;//獲取相機角度
        X = Angle.x;//獲取相機角度的X軸
        Y = Angle.y;//獲取相機角度的Y軸
    }
    void Update()
    {
        if (target) {

            X += Input.GetAxis("Mouse X") * Xspeed * 0.02f;
            Y -= Input.GetAxis("Mouse Y") * Yspeed * 0.02f;
            Y = Mathf.Clamp(Y, yMinLimit, yMaxLimit);
            if (X < -360) X = 0;
            if (X > 360) X = 0;
        }
        
      
    }
    
}
