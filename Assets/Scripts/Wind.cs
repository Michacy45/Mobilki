using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {
 
     void Start()
    {
        var tempRotation = Quaternion.identity;
        var tempVector = Vector3.zero;
        tempVector = tempRotation.eulerAngles;
        tempVector.y = Random.Range(0, 359);
        tempRotation.eulerAngles = tempVector;
        transform.rotation = tempRotation;
    }

}

