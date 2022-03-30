using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class NpcShop : MonoBehaviour
{
    [SerializeField] ItemsInShop itemsInShop;

    [SerializeField] Transform shopUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        DisplayShop();
    }

    void DisplayShop()
    {
        Transform itemSlot;

        shopUi.gameObject.SetActive(true);

        for(int i=0; i< itemsInShop.items.Count; i++)
        {
            itemSlot = shopUi.GetChild(1).GetChild(i);

            itemSlot.gameObject.SetActive(true);

            SetTheItemDetails(itemSlot, i);
        }
    }

    void SetTheItemDetails(Transform itemSlot,int itemIndex)
    {
        itemSlot.GetChild(0).GetComponent<Image>().sprite= itemsInShop.items[itemIndex].image;

        itemSlot.GetChild(1).GetComponent<TextMeshProUGUI>().text= itemsInShop.items[itemIndex].name;

        itemSlot.GetChild(2).
            GetChild(0).
            transform.
            GetComponentInChildren<TextMeshProUGUI>().
            text= itemsInShop.items[itemIndex].price.ToString();
    }
}
