using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateToMouse : MonoBehaviour
{
    public Camera cam;
    public float maxleng;
    public GameObject player;
    Ray rayMouse;
    Vector3 pos;
    Vector3 direction;
    Quaternion rotation;
    // Update is called once per frame
    void Update()
    {
     if(cam != null){
         RaycastHit hit;
         var mousePos= Input.mousePosition;
         rayMouse=cam.ScreenPointToRay(mousePos);
         if(Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maxleng)){
             rotateToMouseDerction(player, hit.point);
         }else
         {
             var pos= rayMouse.GetPoint(maxleng);
             rotateToMouseDerction(player, pos);
         }
     }   
    }
    void rotateToMouseDerction(GameObject obj, Vector3 dest){
        direction = dest - obj.transform.position;
        rotation= Quaternion.LookRotation(direction);
        obj.transform.localRotation= Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
    public Quaternion getRotation(){
        return rotation;
    }
}
//  using UnityEngine;
//  public class rotateToMouse : MonoBehaviour
//  {
 
// 	// speed is the rate at which the object will rotate
// 	public float speed;
// Quaternion Rotation; 
// 	void FixedUpdate () 
// 	{
//     	// Generate a plane that intersects the transform's position with an upwards normal.
//     	Plane playerPlane = new Plane(Vector3.up, transform.position);
 
//     	// Generate a ray from the cursor position
//     	Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
 
//     	// Determine the point where the cursor ray intersects the plane.
//     	// This will be the point that the object must look towards to be looking at the mouse.
//     	// Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
//     	//   then find the point along that ray that meets that distance.  This will be the point
//     	//   to look at.
//     	float hitdist = 0.0f;
//     	// If the ray is parallel to the plane, Raycast will return false.
//     	if (playerPlane.Raycast (ray, out hitdist)) 
// 		{
//         	// Get the point along the ray that hits the calculated distance.
//         	Vector3 targetPoint = ray.GetPoint(hitdist);
 
//         	// Determine the target rotation.  This is the rotation if the transform looks at the target point.
//         	Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
//                 Rotation= targetRotation;
//         	// Smoothly rotate towards the target point.
//         	transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
// 		}
//     }
//         public Quaternion getRotation(){
//         return Rotation;
//     }
// }
//  {
//      //  e.g. 0.2 = slow, 0.8 = fast, 2 = very fast, Infinity = instant
//      [Tooltip("If rotationSpeed == 0.5, then it takes 2 seconds to spin 180 degrees")]
//      [SerializeField] [Range(0,10)] float rotationSpeed = 0.5f;
 
   
//      [Tooltip("If isInstant == true, then rotationalSpeed == Infinity")]
//      [SerializeField] bool isInstant = false;
   
//      Camera _camera = null;  // cached because Camera.main is slow, so we only call it once.
//      void Start()
//      {
//          _camera = Camera.main;
//      }
   
  
//      void Update()
//      {
//          Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
//          Quaternion targetRotation = Quaternion.LookRotation(ray.direction);
    
//          if (isInstant)
//          {
//              transform.rotation = targetRotation;
//          }
//          else
//          {
//              Quaternion currentRotation = transform.rotation;
   
//              float angularDifference = Quaternion.Angle(currentRotation, targetRotation);  
//              // will always be positive (or zero)
   
//              if (angularDifference > 0) transform.rotation = Quaternion.Slerp(
//                                           currentRotation,
//                                           targetRotation,
//                                           (rotationSpeed * 180 * Time.deltaTime) / angularDifference
//                                      );
//              else transform.rotation = targetRotation;
//          }
//      }
//  }