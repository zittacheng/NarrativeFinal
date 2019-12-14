using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundController : MonoBehaviour
{
    private AudioSource audio1;
    public AudioClip ButtonSound;
    public AudioClip SecondClip;
    // Start is called before the first frame update
    void Start()
    {
        audio1 = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        audio1.PlayOneShot(ButtonSound);
        Debug.Log("play sound");
        Debug.Log(gameObject);
    }

    public void PlaySound2()
    {
        audio1.PlayOneShot(SecondClip);
       // Debug.Log();
    }
}
