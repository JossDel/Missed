using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWithPlayer : MonoBehaviour
{
    Vector3 pos;
    public Vector3 yOffset = new Vector3(0, -3, 0);
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        pos = player.transform.position;
        transform.position = pos + yOffset;
    }

    // Update is called once per frame
    void Update()
    {
        pos = player.transform.position;
        transform.position = pos + yOffset;
    }
}
