using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<ItemData> _item = new List<ItemData>();
    public List<ItemData> Items => _item;

    public void AddItem(ItemData item)
    {
        Items.Add(item);
    }

    public bool CheckInventory(string id)
    {
        bool isExists = Items.Exists(v => string.Equals(v.ID, id));
        return isExists;
    }

    public void RemoveItem(ItemData item)
    {
        Items.Remove(item);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
