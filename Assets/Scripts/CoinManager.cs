﻿using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.position, transform.right, Time.deltaTime * 360f);
            
	}
}
