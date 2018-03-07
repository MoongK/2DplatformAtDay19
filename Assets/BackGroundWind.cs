using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundWind : MonoBehaviour
{

    GameObject Head, Body, Tail;
    GameObject TempH, TempT;
    GameObject player;
    GameObject[] Winds;
    GameObject TempHp, TempTp;
    float pos = 0f;

    Vector2 EndSky;

    public float Wind;
    Vector3 MoveDir = Vector3.zero;

    private void Start()
    {
        Wind = 0f;
        player = GameObject.FindGameObjectWithTag("Player");

        Head = GameObject.Find("SkyTileSprite(L)");
        Body = GameObject.Find("SkyTileSprite");
        Tail = GameObject.Find("SkyTileSprite(R)");

        Winds = new GameObject[] { Head, Body, Tail };

        pos = Body.transform.position.x - Head.transform.position.x;
    }

    void Update()
    {
        if (player.transform.position.x >= Tail.transform.position.x)
        {
            EndSky = Tail.transform.position;
            EndSky.x += pos;
            Head.transform.position = EndSky;

            //set parent
            TempHp = Head.transform.parent.gameObject;
            TempTp = Tail.transform.parent.gameObject;

            Tail.transform.parent = Body.transform.parent;
            Body.transform.parent = TempHp.transform;
            Head.transform.parent = TempTp.transform;

            //set Node
            TempH = Body;
            TempT = Head;

            Body = Tail;
            Head = TempH;
            Tail = TempT;

        }
        else if (player.transform.position.x <= Head.transform.position.x)
        {
            EndSky = Head.transform.position;
            EndSky.x -= pos;
            Tail.transform.position = EndSky;
            
            //set parent
            TempHp = Head.transform.parent.gameObject;
            TempTp = Tail.transform.parent.gameObject;

            Head.transform.parent = Body.transform.parent;
            Tail.transform.parent = TempHp.transform;
            Body.transform.parent = TempTp.transform;

            // set Node
            TempH = Tail;
            TempT = Body;

            Body = Head;
            Head = TempH;
            Tail = TempT;
        }

        MoveDir.x = Wind * Time.deltaTime;
        foreach(GameObject go in Winds)
            go.transform.Translate(MoveDir);
    }
}