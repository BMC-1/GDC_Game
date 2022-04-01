using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour
{

    [SerializeField] Transform  itemFramesParent;

    [SerializeField] CoinSystem coinSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToInventory(Sprite itemImage,int priceOfItem)
    {
        Transform itemFrame;

        for(int i=0; i<itemFramesParent.childCount; i++)
        {
            itemFrame = itemFramesParent.GetChild(i).GetChild(0);

            print(itemFrame.GetComponent<Image>().sprite);

            if (itemFrame.GetComponent<Image>().sprite==null)
            {
                itemFrame.GetComponent<Image>().sprite = itemImage;

                itemFrame.gameObject.SetActive(true);

                coinSystem.RemoveCoins(priceOfItem);

                break;
            }
        }
    }

    public void RemoveItemFromInventory(Sprite itemImage, int priceOfItem)
    {
        Transform itemFrame;

        for (int i=0; i<itemFramesParent.childCount; i++)
        {
            itemFrame = itemFramesParent.GetChild(i).GetChild(0);

            if (itemFrame.GetComponent<Image>().sprite== itemImage)
            {
                itemFrame.GetComponent<Image>().sprite = null;

                itemFrame.gameObject.SetActive(false);

                coinSystem.AddCoins(priceOfItem);

                break;
            }
        }
    }
}
