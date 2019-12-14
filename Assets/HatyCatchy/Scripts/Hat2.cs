using System.Collections;
using UnityEngine;


//speed = 3, score = -1
public class Hat2 : MonoBehaviour
{
    GameObject scoreManager;
    GameObject player1;
    GameObject player2;
    public float fallSpeed = 5.0f;

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
            scoreManager.SendMessage("Hat2Missed");
            player1.SendMessage("Hat2Missed");
            //player2.SendMessage("Hat2Missed");
            Destroy(this.gameObject);

        }

        if (otherCollider.tag == "Player1")
        {
            scoreManager.SendMessage("Hat2Caught");
            player1.SendMessage("Hat2Caught");

            Destroy(this.gameObject);
        }
        //if (otherCollider.tag == "Player2")
       // {
       //     scoreManager.SendMessage("Hat2Caught");
        //    player2.SendMessage("Hat2Caught");

        //    Destroy(this.gameObject);
       // }
    }
}
