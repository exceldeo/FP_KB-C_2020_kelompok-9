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
        transform.position = new Vector3(Mathf.Clamp(target.transform.position.x, -15.7f, 15.7f), Mathf.Clamp(target.transform.position.y, -10.6f, 10.6f), transform.position.z);
    }

}
