using System.Collections;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float moveSpeed; 

    public Sprite sadPlayer2Sprite;
    public Sprite happyPlayer2Sprite;

    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0);
        }


        float rightEdge = 5f; 
        float leftEdge = -5f;
        if (transform.position.x > rightEdge)
        {
            transform.position = new Vector3(rightEdge, transform.position.y, 0);
        }
        if (transform.position.x < leftEdge)
        {
            transform.position = new Vector3(leftEdge, transform.position.y, 0);
        }
    }

    public void Hat1Caught()
    {
        sr.sprite = happyPlayer2Sprite; 
    }


    public void Hat1Missed()
    {
        sr.sprite = sadPlayer2Sprite;//changes the sprite on the SpriteRenderer component
    }

    public void Hat2Caught()
    {
        sr.sprite = sadPlayer2Sprite; //changes the sprite on the SpriteRenderer component
    }

    //To receive the message 'HatMissed' we need to have a public function with that name
    //This is called by the Hat script on each Hat, using SendMessage("HatMissed")
    public void Hat2Missed()
    {
        sr.sprite = happyPlayer2Sprite;//changes the sprite on the SpriteRenderer component
    }
}

