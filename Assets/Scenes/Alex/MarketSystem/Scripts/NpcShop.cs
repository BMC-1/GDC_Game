using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class NpcShop : MonoBehaviour
{
    [SerializeField] ItemsInShop itemsInShop;

    [SerializeField] Transform shopUi;

    CoinSystem coinSystem;

    List<Transform> activeSlots=new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        coinSystem = FindObjectOfType<CoinSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        DisplayShop();
    }

    private void OnTriggerExit(Collider other)
    {
        CloseTheShop();
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

            activeSlots.Add(itemSlot);
        }
    }

    void CloseTheShop()
    {
        shopUi.gameObject.SetActive(false);

        foreach(Transform slot in activeSlots)
        {
            slot.gameObject.SetActive(false);
        }

        activeSlots.Clear();
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

        itemSlot.GetChild(2).GetComponent<Button>().
            onClick.AddListener(delegate { PurchaseItem(itemsInShop.items[itemIndex]); });



    }

    void PurchaseItem(ItemsInShop.Item item)
    {
        coinSystem.RemoveCoins(item.price);
    }
}


