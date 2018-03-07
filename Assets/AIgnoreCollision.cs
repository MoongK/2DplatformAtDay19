using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIgnoreCollision : MonoBehaviour
{
    GameObject player;
    Transform foot;
    Color originalColor;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        foot = player.transform.Find("rightFoot");
        originalColor = transform.parent.GetComponentInChildren<SpriteRenderer>().color; // Debug
    }


    private void OnTriggerStay2D(Collider2D collision)   // collision.parent = player , player.parent = HoldPlayer(transform..parent.Find("HoldPlayer"))
    {
        if (collision.CompareTag("PlatformJumpTrigger") && player.GetComponent<PlayerController>().platformIgnoreJump)
        {
            Color white = Color.white; white.a = 0.2f;
            if (foot.position.y < (transform.position.y + (transform.localScale.y / 2.0f) - 0.5f))
            {
                transform.parent.GetComponentInChildren<SpriteRenderer>().color = white;

                foreach (var c in player.GetComponents<Collider2D>())
                {
                    foreach (var g in transform.parent.GetComponents<Collider2D>())
                        Physics2D.IgnoreCollision(c, g, true);
                }
            }
        }
        if (collision.transform.parent != null)
        {
            if (collision.transform.parent.CompareTag("Player"))
            {
                if (foot.position.y > (transform.position.y + (transform.localScale.y / 2.0f)))
                    collision.transform.parent.parent = transform.parent.Find("HoldPlayer");
                else
                    transform.parent.Find("HoldPlayer").DetachChildren();
            }
        }
        if (collision.transform.parent != null)
        {
            if (collision.transform.parent.parent == transform.parent) {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    foreach (var c in player.GetComponents<Collider2D>())
                    {
                        foreach (var g in transform.parent.GetComponents<Collider2D>())
                            Physics2D.IgnoreCollision(c, g, true);
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlatformJumpTrigger") && player.GetComponent<PlayerController>().platformIgnoreJump)
        {
            transform.parent.Find("terrain-ground").GetComponent<SpriteRenderer>().color = originalColor; // 모자가 바뀐다,,
            foreach (var c in player.GetComponents<Collider2D>())
            {
                foreach (var g in transform.parent.GetComponents<Collider2D>())
                    Physics2D.IgnoreCollision(c, g, false);
            }
        }

        if (collision.transform.parent != null)
        {
            if (collision.transform.parent.CompareTag("Player"))
                transform.parent.Find("HoldPlayer").DetachChildren();
        }
    }
}