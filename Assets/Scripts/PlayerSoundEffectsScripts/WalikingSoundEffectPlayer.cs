using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalikingSoundEffectPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] walkingSounds;

    [SerializeField] AudioSource audioSource;

    [SerializeField] string [] groundTags;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void PlayWalkingSoundEffect(string groundTag)
    {
        if(audioSource.isPlaying==false)
        {
            for (int i = 0; i < walkingSounds.Length; i++)
            {
                if (this.groundTags[i] == groundTag)
                {
                    audioSource.clip = walkingSounds[i];

                    audioSource.Play();
                }
            }
        }
       
    }
}
