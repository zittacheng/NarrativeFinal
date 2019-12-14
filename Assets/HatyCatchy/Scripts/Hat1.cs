//HATY CATCHY by m@ boch - NYU GAMECENTER - Oct 2016
//modifications by Bennett Foddy - Jan 2019

using UnityEngine;
using System.Collections;


//speed = 3, score = +1
public class Hat1 : MonoBehaviour
{

    GameObject scoreManager;
    GameObject player1;
    GameObject player2;
    public float fallSpeed=5.0f;

    // Start() is called at the beginning of the game
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager");//fill the scoreManager variable with a reference to the Score Manager
        player1 = GameObject.Find("Player1"); //fill player Variable with reference to Player
       // player2 = GameObject.Find("Player2");
    }

    // Update() is called every frame
    void Update()
    {
        //We aren't using the physics engine here, so we have to be responsible for moving the hat toward the ground
        //we use Time.deltaTime so that the hat moves at the same speed even if the frame rate changes.
        transform.position += new Vector3(0,-fallSpeed*Time.deltaTime,0);
    }

    //OnTriggerEnter2D() is called by the unity engine under the following conditions
    //1. The object that the script is on has a Collider2D set to 'Trigger' mode(could be a box, circle, etc)
    //2. The object that the script is on is touching another object with a Collider2D and a Rigidbody2D on it.
    //The function receives a reference to the incoming Collider2D component as a parameter

    //Note: we aren't using any of the other functions of the Rigidbody2D here, so we set it to 'Kinematic' mode.
    //As a rule, you don't want to move a Collider2D unless it has a Rigidbody2D on it.
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //check to see if the colliding object had the tag 'Ground'
        if (otherCollider.tag == "Ground")
        {
            //And tell the scoreManager & player that the player missed a hat
            scoreManager.SendMessage("Hat1Missed");
            player1.SendMessage("Hat1Missed");
            //player2.SendMessage("Hat1Missed");
            //Then destroy the hat, destroy needs to be sent a game object, which we can get from this.gameObject
            Destroy(this.gameObject);

        }
        //check to see if the colliding object had the tag 'Player'
        if (otherCollider.tag == "Player1")
        {
            //Debug.Log()
            //Tell the scoreManager & player that the player missed a hat
            scoreManager.SendMessage("Hat1Caught");
            player1.SendMessage("Hat1Caught");
            //Then destroy the hat, destroy needs to be sent a game object, which we can get from this.gameObject
            Destroy(this.gameObject);
        }
       // if (otherCollider.tag == "Player2")
       // {
            //Tell the scoreManager & player that the player missed a hat
        //    scoreManager.SendMessage("Hat1Caught");
         //   player2.SendMessage("Hat1Caught");
            //Then destroy the hat, destroy needs to be sent a game object, which we can get from this.gameObject
        //    Destroy(this.gameObject);
     //   }
    }
}