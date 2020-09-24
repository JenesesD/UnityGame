﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    public Vector3 offset;

    // fixed to 60 FPS
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing);
            transform.position = newPos;
        }
    }
}
