using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    [SerializeField] Sprite[] itemsToCollect;

    [SerializeField] Transform itemToCollectUi;

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
                    if (amountToCollect[i]>0)
                    {
                        amountToCollect[i]--;

                        itemToCollectUi.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = amountToCollect[i].ToString();

                        inventoryBehaviour.RemoveItemFromInventory(itemsToCollect[i]);
                    }
                   

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

        SetTheUiForTheCollectItems();

    }

   

    void SetTheUiForTheCollectItems()
    {
        for(int i=0; i<itemsToCollect.Length; i++)
        {

            itemToCollectUi.GetChild(i).gameObject.SetActive(true);

            itemToCollectUi.GetChild(i).GetComponentInChildren<Image>().sprite = itemsToCollect[i];


            itemToCollectUi.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = amountToCollect[i].ToString();

        }
    }
}
