using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAnim : MonoBehaviour {

    public Vector2 direction = Vector2.right;
    public float pathLength = 5f;
    public float speed = 3f;

    Vector3 start, end, cur;

	void Start () {
        start = transform.position;
        Vector3 v = direction.normalized;
        end = transform.position + v * pathLength;
        cur = end;
	}
	
	void Update () {

        float dist = Vector3.Distance(transform.position, cur);

        if (dist > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, cur, speed * Time.deltaTime / dist);
        }
        else
            cur = cur == start ? end : start;
	}
}
