using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed; 


    private float playerHeight;

    private float playerRadius; 


    private void Awake() {
        CapsuleCollider collider = this.transform.GetChild(0).gameObject.GetComponent<CapsuleCollider>();
        this.playerHeight = collider.transform.localScale.y * collider.height;
        this.playerRadius = collider.transform.localScale.y * collider.radius;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement() {
        float horInput = Input.GetAxisRaw("Horizontal");
        float verInput = Input.GetAxisRaw("Vertical");
        Debug.Log(verInput);
        Camera camera = Camera.main;

        Vector3 camForward = camera.transform.forward;
        Vector3 camRight = camera.transform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 forwardRelative = verInput * camForward;
        Vector3 rightRelative = horInput * camRight;

        Vector3 moveDir = forwardRelative + rightRelative;
        moveDir.Normalize();

        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = CanMove(moveDir, moveDistance);

        if (!canMove) {
            if (CanMove(new Vector3(moveDir.x, 0, 0), moveDistance))
                 transform.position += new Vector3(moveDir.x, 0, 0) * moveDistance; 
            else if (CanMove(new Vector3(0, 0, moveDir.z), moveDistance))
                 transform.position += new Vector3(0, 0, moveDir.z) * moveDistance; 

        }

        if (canMove) {
            transform.position += new Vector3(moveDir.x, 0, moveDir.z) * moveDistance;
        }

        if (verInput >= 0f) {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        }
        
    }

    private bool CanMove(Vector3 moveDir, float moveDistance) {
        Vector3 point1 = transform.position + Vector3.up * playerRadius;
        Vector3 point2 = transform.position + Vector3.up * (playerHeight - playerRadius);
        return !Physics.CapsuleCast(point1, point2, playerRadius, moveDir, moveDistance);
    }
}
