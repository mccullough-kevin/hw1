// Author: Kevin McCullough
// Date: 9/22/24
// Description: adds a twist by consuming the object and triggering invisibility in the player controller

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInvincibility : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Consume the pickup and remove it from screen
            Destroy(gameObject);

            // Communicate the pickup back to the playercontroller to handle
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.GrantInvincibility();
            }
        }
    }
}