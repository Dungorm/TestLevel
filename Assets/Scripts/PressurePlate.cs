using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    [SerializeField] private Door door;

    private void OnTriggerEnter(Collider other) {
        door.ToggleDoor();
    }

    private void OnTriggerExit(Collider other) {
        // door.ToggleDoor();
    }

}
