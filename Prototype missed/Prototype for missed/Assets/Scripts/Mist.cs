using UnityEngine;

public class Mist : MonoBehaviour {

    public float speed = 0.5f;

    public Rigidbody2D rb;
    public float amount; // What is amount?

    [SerializeField] float mistAttackRate = 1f;
    private float timer;

    //public GameObject lightUnderPlayer;

    float distance;

    // Use this for initialization
    void Start() {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (timer <= 0)
            {
                collision.gameObject.GetComponent<PlayerStats>().corruption += amount;
                timer = mistAttackRate;
            }
            timer -= Time.deltaTime;

            //lightUnderPlayer.SetActive(true);
        }

        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyShooter"))
        {

            distance = Vector2.Distance(collision.transform.position, GameObject.Find("Player").transform.position);
            float minDistance = 14f;
            float maxDistance = 40f;

            float perc = Mathf.InverseLerp(minDistance, maxDistance, distance);
            float minComvert = 0;
            float maxComvert = 182;

            float opac = Mathf.Abs(Mathf.Lerp(minComvert, maxComvert, perc) - 255f);

            float closer = Mathf.Clamp(opac, 176f, 255f);

            collision.GetComponent<SpriteRenderer>().color = new Color(closer / 255f, closer / 255f, closer / 255f, opac / 255f);

            if (collision.transform.childCount != 4)
                return;
            if (collision.transform.GetChild(2) != null || collision.transform.GetChild(3) != null)
            {
                collision.transform.GetChild(2).gameObject.SetActive(true);
                collision.transform.GetChild(3).gameObject.SetActive(true);

                collision.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, opac / 255f);
                collision.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, opac / 255f);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timer = 0;
            //lightUnderPlayer.SetActive(false);
        }

        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            if (collision.transform.childCount != 4)
                return;
            if (collision.transform.GetChild(2) != null && collision.transform.GetChild(3) != null)
            {
                collision.transform.GetChild(2).gameObject.SetActive(false);
                collision.transform.GetChild(3).gameObject.SetActive(false);
            }
        }
    }
}
