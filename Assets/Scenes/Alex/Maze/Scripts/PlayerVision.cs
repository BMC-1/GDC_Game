using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : MonoBehaviour
{

    [SerializeField] BlankBackroundSetter blankBackroundSetter;

    [SerializeField] float playerVision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCloseBackroundPiece();
    }

    void DisplayCloseBackroundPiece()
    {
        foreach(GameObject blankPieces in blankBackroundSetter.blankBackroundsPieces())
        {
            if(Vector2.Distance(blankPieces.transform.position,this.transform.position)<= playerVision)
            {
                if(CanThePlayerSeeTheArea(blankPieces)==true)
                {
                    blankPieces.SetActive(false);

                }
            }
            else
            {
                blankPieces.SetActive(true);

            }
        }

    }

    bool CanThePlayerSeeTheArea(GameObject blankPiece)
    {
        Vector2 directionOfAreaToCheck = blankPiece.transform.position - this.transform.position;

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, directionOfAreaToCheck);

        if(hit.collider.gameObject== blankPiece)
        {
            return true;
        }
        else
        {
            return false;
        }
    }




}
