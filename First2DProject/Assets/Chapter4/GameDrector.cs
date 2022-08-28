using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDrector : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject distance;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("car");
        flag = GameObject.Find("flag");
        distance = GameObject.Find("Distance");
    }

    // Update is called once per frame
    void Update()
    {

        float lenght = flag.transform.position.x - car.transform.position.x;

        distance.GetComponent<Text>().text = "남은거리 : " + lenght.ToString("F2");
        Debug.Log("남은거리 : " + lenght.ToString("F2"));
    }
}
