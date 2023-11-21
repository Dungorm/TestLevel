using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        this.isOpen = false;        
    }

    public void ToggleDoor() {
        if (!isOpen)
            OpenDoor();
        else
            CloseDoor();
        isOpen = !isOpen;
    }

    private void OpenDoor() {
        transform.position = transform.position + Vector3.up * 8f;
    }

    private void CloseDoor() {
        transform.position = transform.position - Vector3.up * 8f;
    }
}
