using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public enum ItemsTypes {
        Key
    }

    public static Inventory instance;

    [SerializeField] private List<ItemsTypes> items = new List<ItemsTypes>(); 

    private void Awake() {
        instance = this;
    }

    public void addItem(ItemsTypes item) {
        if (!items.Contains(item))
            items.Add(item);
    }

    public void removeItem(ItemsTypes item) {
        if (items.Contains(item))
            items.Remove(item);
    }

    public bool Contains(ItemsTypes item) {
        return items.Contains(item);
    }

}
