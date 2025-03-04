﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour {

    public Transform target;
    public float smooth = 5.0f;
    public float cameraDistance = -10.0f;
    public float cameraYOffset = 2.0f;
	
	void LateUpdate ()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + cameraYOffset, cameraDistance);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
	}
}
