using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    //
    //Right now just trying to play around with direction and movement of the cube 
    //
     //Currently have it set for PC for testing and will move it to phone once the logic is there
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Rigidbody rb;
    public Transform player;
    public float speed;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public int power = 50;
   
    private void Update() {
        ///This moves the cube depending on where your mouse is
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * speed;
        // END MMOVEMENT
        
            if(Physics.Raycast(ray, out RaycastHit raycastHit ))
            {
              print(raycastHit.point);
                if(groundPlane.Raycast(ray, out rayLength)){
                Vector3 pointToLook = ray.GetPoint(rayLength);
                Debug.DrawLine(ray.origin, pointToLook, Color.yellow);
                print(pointToLook.x);
                transform.LookAt(new Vector3(pointToLook.x,transform.position.y, pointToLook.z));
                }
    
       }
   }
    private void FixedUpdate() {
      rb.velocity = moveVelocity;
   }
//    void rotateRam(){
//         Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
//         Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
//         float rayLength;
//         if(groundPlane.Raycast(ray, out rayLength)){
//             Vector3 pointToLook = ray.GetPoint(rayLength);
//             Debug.DrawLine(ray.origin, pointToLook, Color.yellow);
//         }
    
//    }
 }
