using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItems", menuName = "ShopItems/ShopItemsInfo", order = 3)]

public class ItemsInShop : ScriptableObject
{
    // Start is called before the first frame update
    public List<Item> items;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [Serializable]
    public class Item
    {
        public string name;

        public int price;

        public Sprite image;

    }
}
