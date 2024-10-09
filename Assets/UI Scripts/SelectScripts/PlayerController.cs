using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //水平方向です
    float PlayerX;
    //垂直方向です
    float PlayerZ;
    //マウス横振り向き
    float MouseX;
    //マウス縦振り向き
    float MouseY;
    //カメラの向き
    private Vector3 Camera_Direction;
    //Playerが移動する向き
    private Vector3 move_direction;
    //Playerの速度です
    [SerializeField] public float PlayerSpeed = 2f;
    //カメラの回転角の倍数
    [SerializeField] public float RotationMultiple = 3;

    Rigidbody rb;
    void Start()
    {
        //Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {

    }

    private void FixedUpdate()
    {

        PlayerX = Input.GetAxisRaw("Horizontal");
        PlayerZ = Input.GetAxisRaw("Vertical");

        //vector3.scale(a,b); ->aとbをかけた３次元ベクトルの習得
        //正面の向きと(1,0,1)ベクトルの成分同士の掛け算。xz平面でのカメラの向きを習得
        Camera_Direction = Vector3.Scale(transform.forward, new Vector3(1, 0, 1)).normalized;

        //カメラの向きの方向は縦方向、カメラの右方向の向きは横方向。
        //足し算にして斜めの方向を実装
        move_direction = Camera_Direction * PlayerZ + transform.right * PlayerX;

        // プレイヤーの速度　＝プレイヤーの向き×スピード
        rb.velocity = move_direction * PlayerSpeed;

        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");

        //マウスを横方向、縦方向に動かすとカメラが回転する
        if(Mathf.Abs(MouseX) > 0.001f)
        {
            transform.RotateAround(transform.position, Vector3.up, MouseX * RotationMultiple);
        }
        if(Mathf.Abs(MouseY) > 0.001f)
        {
            transform.RotateAround(transform.position, transform.right, MouseY * RotationMultiple/3);
        }
    }
}
