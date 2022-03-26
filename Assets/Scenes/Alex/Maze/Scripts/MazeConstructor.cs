using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeConstructor : MonoBehaviour
{
    [SerializeField] TreasureSpawner treasureSpawner;

    [SerializeField] int[] minAndMaxMarksToMoveToPerStep;
    [SerializeField] int[] minAndMaxObsticlesToAppear;
    [SerializeField] int[] minAndMaxLengthOfObsticles;

    [SerializeField] GameObject wall;

    Vector2 directionToMoveX = new Vector2(-1, 0);

    Vector2[] directionsToMoveY = new Vector2[] { new Vector2(0, 1), new Vector2(0, -1) };

    string[] axisToExpand = new string[] { "x", "y" };

    List<Transform> solutionPath = new List<Transform>();

    public void FindTheSolutionPath(List<Transform> marks,float distanceBetweenMarks)
    {
        int numberOfSteps = Random.Range(minAndMaxMarksToMoveToPerStep[0], minAndMaxMarksToMoveToPerStep[1]);

        int randomNumber = Random.Range(0, 2);

        Vector2 currentPos= marks[marks.Count-1].position;

        bool shouldItMoveOnYAxis = true;

        do
        {
            if (shouldItMoveOnYAxis == false)
            {
                FindNextMark(ref currentPos, (currentPos) +directionToMoveX*distanceBetweenMarks, marks);
            }
            else
            {
    
                FindNextMark(ref currentPos, (currentPos) + directionsToMoveY[randomNumber] * distanceBetweenMarks, marks);
            }

            if(numberOfSteps>0)
            {
                numberOfSteps--;
            }
            else
            {
                shouldItMoveOnYAxis = !shouldItMoveOnYAxis;

                randomNumber = Random.Range(0, 2);

                numberOfSteps = Random.Range(minAndMaxMarksToMoveToPerStep[0], minAndMaxMarksToMoveToPerStep[1]);
            }



        } while (currentPos.x != marks[0].position.x);

        treasureSpawner.SetTreasuresPosition(solutionPath[solutionPath.Count-1].position);

        SpawnTheMazeWalls(marks, distanceBetweenMarks);
    }

    void FindNextMark(ref Vector2 currentPos,Vector2 futurePos,List<Transform> marks)
    {
        Transform markFound = null;

        foreach(Transform mark in marks)
        {
            if(Vector2.Distance(mark.position, futurePos)<0.5f)
            {
                markFound = mark;

                break;
            }
        }

        if(markFound!=null)
        {
            currentPos = markFound.position;

            solutionPath.Add(markFound);

            markFound.name = "Path";
        }
 
    }


    void SpawnTheMazeWalls(List<Transform> marks,float distanceBetweenMarks)
    {

        List<Transform> usedMarks = new List<Transform>();

        Transform markFound;

        int numberOfObsitclesToSpawn = Random.Range(minAndMaxObsticlesToAppear[0], minAndMaxObsticlesToAppear[1]);
 
        do
        {
            do
            {
                markFound = marks[Random.Range(0, marks.Count)];

            } while (solutionPath.Contains(markFound) || usedMarks.Contains(markFound));


            SpawnObsticle(markFound.position);

            ExtendMazeWall(markFound.position, marks, usedMarks, distanceBetweenMarks);

            usedMarks.Add(markFound);

            numberOfObsitclesToSpawn--;


            

        } while (numberOfObsitclesToSpawn > 0);


    }

    void ExtendMazeWall(Vector2 wallPos,List<Transform> marks, List<Transform> usedMarks,float distanceBetweenMarks)
    {

        int sizeOfObsticle = Random.Range(minAndMaxLengthOfObsticles[0], minAndMaxLengthOfObsticles[1]);


        string currentAxisToExpand = axisToExpand[Random.Range(0, axisToExpand.Length)];

        foreach(Transform mark in marks)
        {
            if(!usedMarks.Contains(mark) && !solutionPath.Contains(mark))
            {
                if (axisToExpand[Random.Range(0, axisToExpand.Length)] == "x")
                {
                    if(mark.transform.position.y== wallPos.y)
                    {
                        if(Mathf.Abs(mark.transform.position.x - wallPos.x)<=distanceBetweenMarks*sizeOfObsticle)
                        {
                            SpawnObsticle(mark.transform.position);

                            usedMarks.Add(mark);
                        }
                    }
                }
                else
                {
                    if (mark.transform.position.x == wallPos.x)
                    {
                        if (Mathf.Abs(mark.transform.position.y - wallPos.y) <= distanceBetweenMarks * sizeOfObsticle)
                        {
                            SpawnObsticle(mark.transform.position);

                            usedMarks.Add(mark);
                        }
                    }
                }
            }
         
        }

        

    }

    void SpawnObsticle(Vector2 position)
    {
        GameObject wallClone = Instantiate(wall, position, Quaternion.identity);

    }


}
