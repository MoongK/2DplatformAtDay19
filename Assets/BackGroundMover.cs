using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMover : MonoBehaviour {

    GameObject Head, Body, Tail;
    GameObject TempH, TempT;
    GameObject player;
    float pos = 0f;

    Vector2 LeftGround, RightGround;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Head = GameObject.Find("GrassThinSprite(L)");
        Body = GameObject.Find("GrassThinSprite");
        Tail = GameObject.Find("GrassThinSprite(R)");

        pos = Body.transform.position.x - Head.transform.position.x;
    }

    void Update()
    {
        if (player.transform.position.x >= Tail.transform.position.x)
        {
            RightGround = Tail.transform.position;
            RightGround.x += pos;
            Head.transform.position = RightGround;

            TempH = Body;
            TempT = Head;

            Body = Tail;
            Head = TempH;
            Tail = TempT;
        }
        else if (player.transform.position.x <= Head.transform.position.x)
        {
            LeftGround = Head.transform.position;
            LeftGround.x -= pos;
            Tail.transform.position = LeftGround;

            TempH = Tail;
            TempT = Body;

            Body = Head;
            Head = TempH;
            Tail = TempT;
        }
    }
}