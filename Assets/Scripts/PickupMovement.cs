// Author: Kevin McCullough
// Date: 9/22/24
// Description: controls speed of pickup and velocity


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    //controlling speed of pickup
    public float speed = 1.0f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // randomizes the velocity for the pickup
        float randomX = Random.Range(-10.0f, 10.0f);
        float randomY = Random.Range(-10.0f, 10.0f);
        rb2d.velocity = new Vector2(randomX, randomY) * speed;

    }

}
