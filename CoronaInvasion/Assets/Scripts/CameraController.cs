using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(target.transform.position.x, -12.1f, 12.1f), Mathf.Clamp(target.transform.position.y, -11.6f, 11.6f), transform.position.z);
    }

}
