using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firegoesout : MonoBehaviour
{
    public float lifetime = 5f;
    public GameObject poof;
    // Use this for initialization
    private void Start()
    {
        lifetime = 5f;
    }
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {

        Instantiate(poof, transform.position, transform.rotation);
        Destroy(gameObject);
        }
    }
}
