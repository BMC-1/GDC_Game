using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankBackroundSetter : MonoBehaviour
{
    [SerializeField] GameObject blankBackroundPiece;

    [SerializeField] float distanceBetweenBlankPieces;

    [SerializeField] int[] backroundDimensions;

    [SerializeField] Transform startingSpawningPos;

    List<GameObject> blankBackroundPieces = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SpawnTheBlankBackround();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTheBlankBackround()
    {
        Vector2 currentPos=startingSpawningPos.position;

        for(int i=0; i<backroundDimensions[0]; i++)
        {

            for (int j = 0; j < backroundDimensions[1]; j++)
            {
                GameObject blankPieceClone = Instantiate(blankBackroundPiece, currentPos, Quaternion.identity);

                blankPieceClone.transform.parent = this.transform;

                blankBackroundPieces.Add(blankPieceClone);

                currentPos.x += distanceBetweenBlankPieces;
            }

            currentPos.x = startingSpawningPos.position.x;


            currentPos.y -= distanceBetweenBlankPieces;

        }
    }

    public List<GameObject> blankBackroundsPieces()
    {
        return blankBackroundPieces;
    }
}
