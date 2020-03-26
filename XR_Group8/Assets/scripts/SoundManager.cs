using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip opening;
    public AudioClip inGame;
    public AudioClip ending;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayOpening()
    {
        this.GetComponent<AudioSource>().clip = opening;
        this.GetComponent<AudioSource>().Play(0);
    }
    public void PlayInGame()
    {
        this.GetComponent<AudioSource>().clip = inGame;
        this.GetComponent<AudioSource>().Play(0);
    }

    public void PlayEnding()
    {
        this.GetComponent<AudioSource>().clip = ending;
        this.GetComponent<AudioSource>().Play(0);
    }
}
