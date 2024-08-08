using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
        void OnCollisionEnter(Collision collisinInfo)
        {
            if (collisinInfo.collider.tag == "Obstacle")
            {
                movement.enabled = false;
                FindObjectOfType<GameManager>().EndGame();

            }
        }
}
