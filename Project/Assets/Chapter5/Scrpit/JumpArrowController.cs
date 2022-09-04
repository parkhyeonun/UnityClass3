using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpArrowController : MonoBehaviour
{
    GameObject player;
    Transform arrowPoint;
    Vector2 p1;
    Vector2 p2;
    Vector2 dir;
    float d;
    float r1;
    float r2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");

    }

    // Update is called once per frame
    void Update()
    {
        //ÇÁ·¹ÀÓ¸¶´Ù ¶³¾îÁü
        gameObject.transform.Translate(0,-0.1f,0);

        if (gameObject.transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        p1 = gameObject.transform.position;
        p2 = player.transform.position;
        dir = p1 - p2;

        d = dir.magnitude;

        r1 = 0.05f;
        r2 = 1.0f;

        if( d <= r1 + r2)
        {
            GameObject director = GameObject.Find("GameManager");
            director.GetComponent<GameManager> ().DecreaseHp();
            Destroy(gameObject);
        }


    }
}
