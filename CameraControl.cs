using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
	

    //相機跟隨的目標物件
    public Transform MainCamera;
    //觀察該物體的距離
    public float Distance = 5F;
    //旋轉速度
    private float SpeedX = 240;
    private float SpeedY = 120;
    //角度限制
    private float MinLimitY = 5;
    private float MaxLimitY = 180;

    //旋轉角度
    private float mX = 0.0F;
    private float mY = 0.0F;



    //是否啟用差值
    public bool isNeedDamping = true;
    //速度
    public float Damping = 10F;

    private Quaternion mRotation;

    void Start()
    {
        //初始化旋轉角度
        mX = transform.eulerAngles.x;
        mY = transform.eulerAngles.y;
    }

    void LateUpdate()
    {
     
       
        
            //檢查滑鼠的X,Y軸輸入
            mX += Input.GetAxis("Mouse X") * SpeedX * 0.02F;
            mY -= Input.GetAxis("Mouse Y") * SpeedY * 0.02F;
            //範圍限制
           // mY = ClampAngle(mY, MinLimitY, MaxLimitY);
            //計算旋轉
            mRotation = Quaternion.Euler(mY, mX, 0);
            //根據是否插值來采取不同的角度計算方式
            if (isNeedDamping)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, mRotation, Time.deltaTime * Damping);
            }
            else
            {
                transform.rotation = mRotation;
            }
            
        

       

        //重新計算位置
        Vector3 mPosition = mRotation * new Vector3(0.0F, 0.0F, -Distance) + MainCamera.position;

        //設定相機的角度與位置
        if (isNeedDamping)
        {
            transform.position = Vector3.Lerp(transform.position, mPosition, Time.deltaTime * Damping);
        }
        else
        {
            transform.position = mPosition;
        }

    }

    //角度限制
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
       
	}




   





