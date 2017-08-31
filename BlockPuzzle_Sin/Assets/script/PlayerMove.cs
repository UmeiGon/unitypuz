using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform Camera1;
    private CharacterController CharaCon;
    private Animator anim;
    private GameObject child;
    private float jumpCount;
    public int MAX_JUMP = 10;
    private float rakkakasoku = 0;
    private float jumpkasoku = 20;
    private bool jumpflag;
    void Start()
    {
        CharaCon = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        child = transform.Find("Born").gameObject;
    }
    public bool CheckGrounded()
    {
        if (CharaCon.isGrounded) { return true; }
        var ray = new Ray(this.transform.position + Vector3.up * 0.1f, Vector3.down);
        var kyori = 0.3f;
        return Physics.Raycast(ray, kyori);
    }
    void JumpFunc()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckGrounded())
            {
                jumpflag = true;
                anim.SetBool("jump", true);
            }
        }
        if (jumpflag)
        {
            jumpCount += Time.deltaTime * jumpkasoku++;
            CharaCon.Move(new Vector3(0, Time.deltaTime * jumpkasoku, 0));
            if (jumpCount >= MAX_JUMP)
            {
                jumpCount = 0;
                jumpkasoku = 20;
                rakkakasoku = 0;
                jumpflag = false;
                anim.SetBool("jump", false);
            }
        }
        else if (!CharaCon.isGrounded)
        {
            CharaCon.Move(new Vector3(0, -(rakkakasoku++) * Time.deltaTime, 0));
        }


    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera1.rotation;
        float ad = Input.GetAxis("Horizontal");
        float ws = Input.GetAxis("Vertical");

        Vector3 move = Vector3.Normalize(new Vector3(ad, 0, ws));
        float speed = 30.0f * Time.deltaTime;

        JumpFunc();

        if (move.magnitude > 0)
        {

            anim.SetBool("walk", true);
            //モデルだけ移動方向に動かす
            child.transform.localRotation = Quaternion.LookRotation(move);

            //実際に動かす
            Vector3 targetDirection = transform.TransformDirection(move);
            //child.transform.LookAt(targetDirection);
            CharaCon.Move(targetDirection * speed);
        }
        else
        {
            anim.SetBool("walk", false);
        }


    }
}
