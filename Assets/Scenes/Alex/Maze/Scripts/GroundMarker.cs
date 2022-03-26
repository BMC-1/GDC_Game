using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundMarker : MonoBehaviour
{
    [SerializeField] MazeConstructor mazeConstructor;
    [SerializeField] PlayerSpawner playerSpawner;

    [SerializeField] GameObject groundMark;

    [SerializeField] Transform startingPos;

    [SerializeField] Transform parentOfGroundMarks;


    [SerializeField] float distanceBetweenGroundMark;

    [SerializeField] int[] dimensionsOfGround;

    List<Transform> marksSpanwed = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        MarkTheGround();
    }


    // Update is called once per frame
    void Update()
    {
     
    }

    void MarkTheGround()
    {
        Vector2 positionOfGroundPieces = startingPos.position;

        for (int i = 0; i < dimensionsOfGround[0]; i++)
        {
            for (int j = 0; j < dimensionsOfGround[1]; j++)
            {
                GameObject markClone = Instantiate(groundMark, positionOfGroundPieces, Quaternion.identity);

                markClone.transform.parent = parentOfGroundMarks;

                positionOfGroundPieces.x += distanceBetweenGroundMark;

                marksSpanwed.Add(markClone.transform);
            }

            positionOfGroundPieces.x = startingPos.position.x;

            positionOfGroundPieces.y -= distanceBetweenGroundMark;
        }


        playerSpawner.SpawnPlayer(marksSpanwed[marksSpanwed.Count - 1].position);

        mazeConstructor.FindTheSolutionPath(marksSpanwed, distanceBetweenGroundMark);
    }


}
