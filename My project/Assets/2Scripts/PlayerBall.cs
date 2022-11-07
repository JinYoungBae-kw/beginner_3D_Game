using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float JumpPower; //public으로 선언 시 유니티 창에서 설정 가능.
    public int ItemCount;
    Rigidbody rigid;
    bool isJump;
    AudioSource audio;
    public GameManagerLogic manager;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        isJump = false;
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, JumpPower, 0), ForceMode.Impulse);
        }

    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, z), ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            ItemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(ItemCount);
        }
        else if (other.tag == "Finish")
        {
            if (ItemCount == manager.TotalItemCount)
            {
                //Game Clear!!
                SceneManager.LoadScene("Example1");
            }
            else
            {
                //Restart..
                SceneManager.LoadScene("SampleScene");
            }
        }

    }
}
