using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

    public GameObject ob; // player
    Transform gc; // player transform
    CircleCollider2D[] cc ;
    CircleCollider2D cc1, cc2;
    BoxCollider2D bc;

    private void Start()
    {
        gc = ob.transform;
        bc = gameObject.GetComponent<BoxCollider2D>();
        cc = gameObject.GetComponents<CircleCollider2D>();

        cc1 = gameObject.GetComponents<CircleCollider2D>()[0];
        cc2 = gameObject.GetComponents<CircleCollider2D>()[1];
    }
    private void Update()
    {
        //if (gc.transform.position.y >= transform.position.y)
        //{
        //    gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        //    foreach (CircleCollider2D c in cc)
        //        c.isTrigger = false;
        //}
        //else
        //{
        //    gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //    foreach (CircleCollider2D c in cc)
        //        c.isTrigger = true;
        //}

    }
}
