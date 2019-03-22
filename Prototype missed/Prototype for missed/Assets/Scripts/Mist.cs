using UnityEngine;

public class Mist : MonoBehaviour {

    public float speed = 0.5f;

    public Rigidbody2D rb;

    float distance;

    void Start() {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "End of Map")
            Destroy(gameObject);

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
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyShooter"))
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
