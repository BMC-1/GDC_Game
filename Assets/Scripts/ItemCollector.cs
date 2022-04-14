using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] Sprite[] itemsToCollect;

    [SerializeField] int[] amountToCollect;

    InventoryBehaviour inventoryBehaviour;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("GetTheInventortyBehaviour", 2f);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   

    public void CollectItems()
    {
        for(int i=0; i<itemsToCollect.Length; i++)
        {
            for(int j=0; j<inventoryBehaviour.ItemFramesParent().childCount; j++)
            {
                //print(inventoryBehaviour.ItemFramesParent().GetChild(j).GetChild(0).GetComponent<Sprite>());

                if(inventoryBehaviour.ItemFramesParent().GetChild(j).GetChild(0).GetComponent<Image>().sprite== itemsToCollect[i])
                {
                    amountToCollect[i]--;

                    inventoryBehaviour.RemoveItemFromInventory(itemsToCollect[i]);

                }
            }

            CheckIfAllItemsWhereCollected();

        }
    }

    void CheckIfAllItemsWhereCollected()
    {
        for(int i=0; i<itemsToCollect.Length; i++)
        {
            if(amountToCollect[i]>0)
            {
                return;
            }
        }

        FindObjectOfType<SceneChanger>().LoadNextScene();
    }

    void GetTheInventortyBehaviour()
    {
        inventoryBehaviour = FindObjectOfType<InventoryBehaviour>();

        print(inventoryBehaviour);

    }
}
