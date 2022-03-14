using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceOfficerAttack : MonoBehaviour
{
    /// <summary>
    /// This script is used on the Parent game object of a police officer
    /// it takes the mainCharacter -> The player to be followed by the police officer
    /// MUST : BoxCollider [ Big Collider -> The space that can be trigger when a character enter / Trigger must be on]
    /// MUST : BoxCollider [ Small Collider -> Fitted box collider for the police officer to not enter inside game objects. / Trigger must be Off]
    /// Functionality -> It making the "Running" animation of police to be trigger when the followed character
    /// triggers on the big box collider -> Speed increased / Rotation keeps on target as well
    /// </summary>
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
            var _transform = transform;
            _transform.rotation = Quaternion.Slerp(_transform.rotation,targetRotation, 4f * Time.deltaTime);
            _transform.position += _transform.forward * 4f * Time.deltaTime;
        }
    }
}
