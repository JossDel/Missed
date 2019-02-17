using UnityEngine;

public class Enemymovement : MonoBehaviour {

    public float speed;
    private Transform target;
    public int canSeePlayer;

	// Use this for initialization
	void Start () {
            canSeePlayer = 0;
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (canSeePlayer == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
            
	}
}
