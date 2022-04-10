using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspector : MonoBehaviour
{

    [SerializeField] GameObject emptyInspectedItem;

    public bool isAnItemBeingInspected { get; set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CopyPickableItemsComponents(GameObject pickableItem)
    {
        pickableItem.GetComponent<MeshFilter>().mesh = pickableItem.GetComponent<MeshFilter>().mesh;
        
        pickableItem.GetComponent<Material>().mainTexture= pickableItem.GetComponent<Material>().mainTexture;
    }

    public void InspectTheItem(GameObject itemToInspect)
    {
        CopyPickableItemsComponents(itemToInspect);

        isAnItemBeingInspected = true;


    }
}
 
