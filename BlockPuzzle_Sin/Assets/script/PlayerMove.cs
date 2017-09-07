using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Transform Camera1;
    private CharacterController CharaCon;
    private Animator anim;
    public GameObject child;
    private float jumpCount;
    public int MAX_JUMP = 10;
    public float eisyoTimer;
    public bool eisyo;
    private float rakkakasoku = 0;
    private float jumpkasoku = 20;
    private bool jumpflag;
    public Slider eisyobar;
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
                rakkakasoku = 10;
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
                rakkakasoku = 10;
                jumpflag = false;
                anim.SetBool("jump", false);
            }
        }
        else if (!CharaCon.isGrounded)
        {
            CharaCon.Move(new Vector3(0, -(rakkakasoku+=0.2f) * Time.deltaTime, 0));
        }
        CharaCon.Move(new Vector3(0, -3.0f * Time.deltaTime, 0));

    }
    // Update is called once per frame
    void Update()
    {
        if (eisyo)
        {
            anim.SetBool("saikutu", true);
            eisyoTimer += Time.deltaTime;
            eisyobar.gameObject.SetActive(true);
            eisyobar.value = eisyoTimer;
        }
        else
        {
            anim.SetBool("saikutu", false);
            eisyobar.gameObject.SetActive(false);
            eisyoTimer = 0;
        }
        transform.rotation = Camera1.rotation;
        float ad = Input.GetAxis("Horizontal");
        float ws = Input.GetAxis("Vertical");

        Vector3 move = Vector3.Normalize(new Vector3(ad, 0, ws));
        float speed = 30.0f * Time.deltaTime;

        JumpFunc();

        if (move.magnitude > 0)
        {
            eisyo = false;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "clear")
        {
            GameObject.Find("GameManager").GetComponent<gamemanager>().clearImg.SetActive(true);
        }
        if (other.gameObject.tag == "reset")
        {
            scenemanager sm = GameObject.Find("GameManager").GetComponent<scenemanager>();
            sm.OnReset();
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "tama")
        {
            scenemanager sm = GameObject.Find("GameManager").GetComponent<scenemanager>();
            sm.OnReset();
        }
    }
}
