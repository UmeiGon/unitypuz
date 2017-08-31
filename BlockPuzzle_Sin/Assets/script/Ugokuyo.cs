using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ugokuyo : MonoBehaviour
{
    public float speed = 1;
    public Transform ArmaOya;
    public Transform Camera1;
    private float kasoku = 1;
    public bool stopact;
    private float ad;
    private float ws;
    private float zyouge;
    private Animator anim;
    public bool Flyaction;
    private CharacterController CharCon;
    private AudioClip clip;
    void Start()
    {
        anim = GetComponent<Animator>();
        CharCon = GetComponent<CharacterController>();
        clip = GetComponent<AudioSource>().clip;
    }
    void Update()
    {
        transform.rotation = Camera1.rotation;
        ad = Input.GetAxis("Horizontal");
        ws = Input.GetAxis("Vertical");
        zyouge = Input.GetAxis("Jump");
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            ad *= 0.71f;
            ws *= 0.71f;
        }
        Vector3 targetDirection = new Vector3(ad, 0, ws);

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!anim.GetBool("Spd"))
            {
                anim.SetBool("Spd", true);
                speed = 2;
            }
            else
            {
                anim.SetBool("Spd", false);
                speed = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !Flyaction&&!stopact)             //Fly or tyakuti
        {
            anim.SetTrigger("FlyMode");
            anim.SetBool("Tyakuti", false);
            Flyaction = true;
        }
        if ((Input.GetKeyDown(KeyCode.Z) && Flyaction))
        {
            anim.SetTrigger("Rakka");
            Flyaction = false;
        }
        if (Flyaction)       //flying
        {
            CharCon.Move(new Vector3(0, zyouge * 3 * Time.deltaTime * kasoku, 0));
        }
        else if (!Flyaction)
        {
            if (CharCon.isGrounded)
            {
                anim.SetBool("Tyakuti", true);

            }
            CharCon.Move(new Vector3(0, -9 * Time.deltaTime, 0));
        }

        if (targetDirection.magnitude > 0.001&&!stopact)                                 //moving
        {
            ArmaOya.transform.localRotation = Quaternion.LookRotation(targetDirection);
            anim.SetBool("Frymove", true);
            anim.SetBool("Move", true);
            anim.SetBool("Walk0", true);
            targetDirection = transform.TransformDirection(targetDirection);
            CharCon.Move(targetDirection * 3 * Time.deltaTime * speed * kasoku);
        }
        else
        {
            anim.SetBool("Frymove", false);
            anim.SetBool("Move", false);
            anim.SetBool("Walk0", false);
        }
        if (1 < kasoku)
        {
            kasoku -= 0.2f * Time.deltaTime;
        }

    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Kasoku")
        {
            kasoku = 3;
            hit.gameObject.SetActive(false);
        }
    }

}
