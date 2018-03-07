using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour {

    public Transform[] coinSpawns;
    public GameObject coin;

	void Start () {
        Spawn();
	}

    void Spawn()
    {
        for(int i = 0; i< coinSpawns.Length; i++)
        {
            int coinFlip = Random.Range(0, 2);
            if (coinFlip > 0)
            {
                var clone = Instantiate(coin, coinSpawns[i].position, Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up));

                if (Random.Range(0, 100) > 70)
                    clone.transform.localScale = clone.transform.localScale * 1.5f;
            }
                
            
        }
    }
}
