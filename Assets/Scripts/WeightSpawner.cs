using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightSpawner : MonoBehaviour {

    public GameObject WeightPrefab;
    public Transform weightspawner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
		
	}

    void Spawn()
    {
        Instantiate(WeightPrefab, weightspawner.position, weightspawner.rotation);
    }
}
