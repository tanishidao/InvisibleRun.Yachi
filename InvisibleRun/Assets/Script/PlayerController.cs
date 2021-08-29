using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed;

    private bool IsGround;
    Rigidbody2D Rigid2D;
    private int JumpCount;




    void Start()
    {
        Rigid2D = GetComponent<Rigidbody2D>(); ;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && JumpCount < 2)
        {

            Rigid2D.AddForce(Vector2.up * jumpSpeed);
            Debug.Log("space������");
            ///IsGround = false;
            JumpCount++;
            if(JumpCount >= 2)
            {
                IsGround = false;
            }
        }
        if (2 <= JumpCount && IsGround)
        {
            JumpCount = -2;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGround = true;
            Debug.Log("�n�ʂɐG��Ă���");
        }


    }
}
