using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateatplayer : MonoBehaviour
{
   
    private void FixedUpdate()
    {

        Vector3 Playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        Vector2 direction = new Vector2(
            Playerpos.x - transform.position.x,
            Playerpos.y - transform.position.y
            );

        transform.up = direction;

    }
}
