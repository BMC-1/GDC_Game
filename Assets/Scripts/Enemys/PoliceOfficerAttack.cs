using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceOfficerAttack : MonoBehaviour
{
    [Header("The first child object of the main player")]
    public GameObject mainCharacter;

    private bool getClosed;
    private Animator policeAnimator;
    private AudioSource audioSource;
    private void Start()
    {
        policeAnimator = transform.GetChild(0).GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        getClosed = true;
        audioSource.Play();
        policeAnimator.SetTrigger(StaticHelper.Caught);
    }
    

    private void Update()
    {
        if (getClosed)
        {
            //This code makes the police officer to run straight forward to our player
            Quaternion targetRotation = Quaternion.LookRotation(mainCharacter.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation, 2.5f * Time.deltaTime);
            transform.position += transform.forward * 2.5f * Time.deltaTime;
        }
    }
}
