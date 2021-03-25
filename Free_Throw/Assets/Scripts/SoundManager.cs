using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip madeShot, missedShot;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        madeShot = Resources.Load<AudioClip>("Made Shot");
        missedShot = Resources.Load<AudioClip>("Missed Shot");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Made Shot":
                audioSrc.PlayOneShot(madeShot);
                break;
            case "Missed Shot":
                audioSrc.PlayOneShot(missedShot);
                break;
        }
    }
}
