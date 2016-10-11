using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
    public Transform camera_child;
    public Transform camera_transform;
    public bool camera_rotate;
    public float camera_speed = 5;
    public float camera_height = 5;
    public float rotate_speed = 5;
    public float zoom_speed = 5;
    public float camera_angle = 45;
   

    void Start()
    {
        camera_child = transform.FindChild("camera_child");
        camera_transform = camera_child.FindChild("Main Camera");
        camera_child.position = new Vector3(camera_child.position.x,camera_height, camera_child.position.z);
        camera_child.eulerAngles = new Vector3(camera_angle, camera_child.eulerAngles.y, camera_child.eulerAngles.z);
         
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) )
        {
            transform.position+=transform.TransformDirection(Vector3.left)*camera_speed*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) )
        {
            transform.position += transform.TransformDirection(Vector3.right) * camera_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) )
        {
            transform.position += transform.TransformDirection(Vector3.back) * camera_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * camera_speed * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse ScrollWheel")>0)
        {
            camera_transform.transform.localPosition += new Vector3(camera_transform.transform.localPosition.x, camera_transform.transform.localPosition.y, zoom_speed * Time.deltaTime);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            camera_transform.transform.localPosition -= new Vector3(camera_transform.transform.localPosition.x, camera_transform.transform.localPosition.y, zoom_speed * Time.deltaTime);
        }
        if(Input.GetMouseButton(2))
        {
            camera_rotate = true;
        }else { camera_rotate = false; }
        
        if (camera_rotate)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X")*rotate_speed,0);
            camera_child.Rotate(-Input.GetAxis("Mouse Y")*rotate_speed, 0, 0);
            
        }
    }
}