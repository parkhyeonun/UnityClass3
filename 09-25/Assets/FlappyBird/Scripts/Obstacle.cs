using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform upLog;
    public Transform downLog;
    public bool isDownObstacle = false;
    public float speed;
    private bool alreadyCreated = false;
    private bool gotPoint = false;
    private GameObject bird;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        bird = GameObject.Find("Player");

        body.velocity = Vector2.up * speed;
        InvokeRepeating("Switch", 0, 2); //이동 방향 변경
    }

    void Update()
    {
        float birdX = bird.transform.position.x;

        if (isDownObstacle)
        {
            if (GetComponent<Renderer>().isVisible && !alreadyCreated)
            {
                CreateNextObstacles();
                alreadyCreated = true;
            }

            if (!gotPoint && transform.position.x < birdX)
            {
                LevelManager.instance.UpdatePoints();
                gotPoint = true;
            }
        }

        if (transform.position.x < birdX - 6)
        {
            Destroy(gameObject);
        }
    }

    void CreateNextObstacles()
    {
        float nextX = transform.position.x + Random.Range(6, 10);
        float targetY = Random.Range(11f, -2.5f);
        float deltaY = Random.Range(10f, 11f);

        Vector3 upLogPosition = new Vector3(nextX, targetY + deltaY, transform.position.z);
        Vector3 downLogPosition = new Vector3(nextX, targetY - deltaY, transform.position.z);

        Transform upLogObject = Instantiate(upLog, upLogPosition, Quaternion.identity);
        Transform downLogObject = Instantiate(downLog, downLogPosition, Quaternion.identity);

        bool shouldMove = Random.Range(1, 10) % 3 == 0;
        if (shouldMove)
        {
            upLogObject.GetComponent<Obstacle>().speed = 1;
            downLog.GetComponent<Obstacle>().speed = 1;
        }
        else
        {
            upLogObject.GetComponent<Obstacle>().speed = 0;
            downLogObject.GetComponent<Obstacle>().speed = 0;
        }

    }

    void Switch()
    {
        body.velocity *= -1;
    }
}
