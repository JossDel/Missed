using UnityEngine;

public class Deathbytime : MonoBehaviour {

    public float lifetime = 5f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifetime);
	}
}
