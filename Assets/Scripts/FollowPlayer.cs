using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        Vector3 Tragetpos = player.position + offset ;
        Tragetpos.x = 0;
        transform.position = Tragetpos;
    }
}
