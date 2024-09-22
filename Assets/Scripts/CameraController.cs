// Author: Kevin McCullough
// Date: 9/22/24
// Description: adjusts camera

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; // offset vector from initial config
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;           
    }
}
