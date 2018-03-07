using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlatform : MonoBehaviour {

    bool dropping = false;
    float Dropper = 10f;

    private void Update()
    {
        if (dropping == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.down, 0.1f * Dropper * Time.deltaTime);
            Dropper += 1f;
        }
    }

    void Drop()
    {
        dropping = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Invoke("Drop", 1f);
    }
}
