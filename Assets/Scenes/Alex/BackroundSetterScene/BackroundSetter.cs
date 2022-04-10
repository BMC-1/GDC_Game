using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackroundSetter : MonoBehaviour
{

    [SerializeField] Transform backroundTransform;

    [SerializeField] Sprite textureOfBackround;

    [SerializeField] float distanceBetweenBackrounds;

    [SerializeField] float radius;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTheBackround();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnTheBackround()
    {

        int numberOfLoops = 40;

        float previousRotation = 0;

        do
        {
            Vector3 positionToSpawn = this.transform.position + (this.transform.forward * radius);

            Transform backroundClone = Instantiate(backroundTransform, positionToSpawn, Quaternion.identity);

            

            previousRotation = this.transform.rotation.eulerAngles.y;

            this.transform.Rotate(new Vector3(0, distanceBetweenBackrounds, 0));

            backroundClone.GetComponent<SpriteRenderer>().sprite = textureOfBackround;

            SetTheRotatioForBackround(backroundClone.gameObject);

            numberOfLoops--;

            print(this.transform.eulerAngles.y);
                

        } while (this.transform.eulerAngles.y<360 && previousRotation< this.transform.eulerAngles.y && numberOfLoops>0);

          

        

    }

    void SetTheRotatioForBackround(GameObject spawnedBackround)
    {
        spawnedBackround.transform.LookAt(this.transform);
    }
}
