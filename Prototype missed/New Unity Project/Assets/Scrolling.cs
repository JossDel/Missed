using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float m_speed = 0.01f;
    private Vector3 m_pos;
    // Start is called before the first frame update
    void Start()
    {
        m_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        m_pos.x += m_speed * Time.deltaTime;
        transform.position = m_pos;
    }
}
