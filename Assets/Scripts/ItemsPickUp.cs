using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] private Inventory.ItemsTypes item;

    private void OnTriggerEnter(Collider collider) {
        Player player = collider.gameObject.transform.parent.gameObject.GetComponent<Player>();
        if (player != null) {
            Debug.Log("Picked up an Item");
            Inventory.instance.addItem(item);
            Destroy(gameObject);
        }
    }

}
