using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMarker : MonoBehaviour
{
    [SerializeField] GameObject groundMark;

    [SerializeField] Transform startingMarkPos;

    [SerializeField] float distanceBetweenMark;

    [SerializeField] int[] dimensionsOfGround;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTheMarks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTheMarks()
    {
        Vector2 posOfMark = startingMarkPos.position;

        for(int i=0; i< dimensionsOfGround[0]; i++)
        {
            for (int j = 0; j < dimensionsOfGround[1]; j++)
            {
                GameObject markClone = Instantiate(groundMark, posOfMark, Quaternion.identity);

                markClone.transform.parent = this.transform;

                posOfMark.x += distanceBetweenMark;
            }

            posOfMark.x = startingMarkPos.position.x;

            posOfMark.y -= distanceBetweenMark;
        }
    }
}
