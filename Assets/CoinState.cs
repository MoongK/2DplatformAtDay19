using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinState : MonoBehaviour {

    bool coinroll = false;

    Vector3 moveDir;
    Vector3 upper, downner;

    private void Start()
    {
        moveDir = transform.position;
        moveDir.y = transform.position.y + 1f;

        upper = transform.position;
        upper.y = transform.position.y + 0.2f;

        downner = transform.position;
        downner.y = transform.position.y - 0.2f;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * 100f * Time.deltaTime);

        if (coinroll == true)
            transform.Rotate(Vector3.up * 2000f * Time.deltaTime);
        else
        {
            idleCoin();
        }
    }



    void idleCoin()
    {
        if (transform.position.y >= upper.y)
            moveDir = downner;
        else if (transform.position.y <= downner.y)
            moveDir = upper;

        transform.position = Vector3.MoveTowards(transform.position, moveDir, 1f * Time.deltaTime);

        transform.Rotate(Vector3.up * 100f * Time.deltaTime);

        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coinroll = true;
            Destroy(gameObject, 1f);
        }
    }
}
