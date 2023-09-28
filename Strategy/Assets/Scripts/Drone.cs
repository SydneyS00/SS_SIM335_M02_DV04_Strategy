using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    //Ray parms
    private RaycastHit _hit;
    private Vector3 _rayDirection;
    private float _rayAngle = -45.0f;
    private float _rayDistance = 15.0f;

    //Movement parms
    public float speed = 1.0f;
    public float maxHeight = 5.0f;
    public float weavingDistance = 1.5f;
    public float fallbackDistance = 20.0f;

    void Start()
    {
        _rayDirection = transform.TransformDirection(Vector3.back) * _rayDistance;
        _rayDirection = Quaternion.Euler(_rayAngle, 0.0f, 0f) * _rayDirection; 
    }

    //This method here contains the core mechanism of the Strategy 
    //  pattern. 
    //A Drone object can communicate with the concrete strategies
    //  it recieved through the IManeuverBehavior interface. Thus, 
    //  it only needs to call Maneuver() to execute a strategy at 
    //  runtime. 
    //Basically the Drone object doesn't need to know how a 
    //  strategy's behavior/algorithm is executed, it just needs to 
    //  be aware of its interface. 
    public void ApplyStrategy(IManeuverBehavior strategy)
    {
        strategy.Maneuver(this); 
    }

    void Update()
    {
        Debug.DrawRay(transform.position, _rayDirection, Color.blue);

        if(Physics.Raycast(transform.position, _rayDirection, out _hit, _rayDistance))
        {
            if(_hit.collider)
            {
                Debug.DrawRay(transform.position, _rayDirection, Color.green);
            }
        }
    }

}
