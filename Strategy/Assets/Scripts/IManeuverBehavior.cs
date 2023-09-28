using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManeuverBehavior
{
    //This is our Strategy interface where all of our
    //  concrete strategies will use it 
    void Maneuver(Drone drone);
    
}
