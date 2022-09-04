using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatPlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 15.0f;
    float maxwalkSpeed = 2.0f;
    int key = 0;
    bool sw = true;
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        if(Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rigid2D.velocity.y) == 0)
        {
            animator.SetBool("isJump", true);
            rigid2D.AddForce(transform.up * jumpForce);
        }
        else
        {
            animator.SetBool("isJump", false);

        }

        //좌우이동

        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
            sw = true;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
            sw = false;
        }

        //플레이어 속도 체크
        float speedx = Mathf.Abs(rigid2D.velocity.x);

        if(sw)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        //스피드 제한
        if(speedx < maxwalkSpeed)
        {
            rigid2D.AddForce(transform.right * key * this.walkForce);
            key = 0;
        }

        if(rigid2D.velocity.y == 0)
        {
            //플레이어 속도에 맞춰 애니메이션 속도 변경
            animator.speed = speedx / 2.0f;

        }
        else
        {
            //플레이어 속도에 맞춰 애니메이션 속도 변경
            animator.speed = 1.0f;
        }

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("Jump");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("ClearScene");
        Debug.Log("골");
    }
}
