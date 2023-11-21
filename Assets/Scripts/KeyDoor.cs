using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{

    [SerializeField] private Inventory.ItemsTypes requiredItem;

    public void OpenDoor() {
        if (Inventory.instance.Contains(requiredItem)){
            transform.position = transform.position + Vector3.up * 8f;
            Inventory.instance.removeItem(requiredItem);
        }
        else {
            Debug.Log("Can't open without an item");
        }
    }

    private void OnTriggerEnter(Collider collider) {
        Player player = collider.gameObject.transform.parent.gameObject.GetComponent<Player>();
        if (player != null) {
            OpenDoor();
        }
    }

}
