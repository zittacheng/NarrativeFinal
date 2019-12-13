using System.Collections;
using UnityEngine;


//speed = 6, score = +3
public class Hat3 : MonoBehaviour
{
    GameObject scoreManager;
    GameObject player1;
    GameObject player2;
    public float fallSpeed = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager");
        player1 = GameObject.Find("Player1");
        //player2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -fallSpeed * Time.deltaTime, 0);

    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Ground")
        {
            scoreManager.SendMessage("Hat3Missed");
            player1.SendMessage("Hat3Missed");
           // player2.SendMessage("Hat3Missed");
            Destroy(this.gameObject);

        }

        if (otherCollider.tag == "Player1")
        {
            scoreManager.SendMessage("Hat3Caught");
            player1.SendMessage("Hat3Caught");

            Destroy(this.gameObject);
        }
       // if (otherCollider.tag == "Player2")
       // {
        //    scoreManager.SendMessage("Hat3Caught");
        //    player2.SendMessage("Hat3Caught");

        //    Destroy(this.gameObject);
       // }
    }
}
