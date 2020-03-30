﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour {
    public float moveSpeed = 13;
	Rigidbody rb;
    
	void Start() {
        rb = GetComponent<Rigidbody>(); 
        
    }
	
    void Update() {

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * Time.deltaTime * moveSpeed;

        Vector3 pointToLookAt = transform.position + moveDirection * 100;
		
		
        // transform.position += moveDirection;
		rb.MovePosition(transform.position + moveDirection);
        transform.LookAt(pointToLookAt);

    }
}
