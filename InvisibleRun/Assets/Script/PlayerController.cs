using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed;

    private bool IsGround;
    Rigidbody2D Rigid2D;
    private int JumpCount;
    public Text GO;
    public GameObject MENU;
    public AudioSource Jump;

    Animator animator;


    void Start()
    {
        Rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("IsGround", true);
        AudioSource audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && JumpCount < 2)
        {
            animator.SetBool("IsGround", false);
            Rigid2D.AddForce(Vector2.up * jumpSpeed);
            Jump.PlayOneShot(Jump.clip);

            ///IsGround = false;
            JumpCount++;
            if (JumpCount >= 2)
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
            animator.SetBool("IsGround", true);
        }


    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.CompareTag("Player") && collision.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("GAMEOVER");
            SceneManager.LoadScene("ResultScene");

        }

    }
}

