using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControll : MonoBehaviour
{
    public GameObject player;
    public Transform cam;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = cam.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     cam.position = player.transform.position + offset;
    }
}
