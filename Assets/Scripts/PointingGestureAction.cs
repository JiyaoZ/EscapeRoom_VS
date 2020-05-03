using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;
using System;
using Zinnia.Data.Attribute;
using Zinnia.Data.Type;

public class PointingGestureAction : BooleanAction
{
    public Boolean gripTrigger { get; set; }
    public Boolean indexTrigger { get; set; }
    public Boolean isGrabbing { get; set; }

    void Update() {
        Receive(gripTrigger && !indexTrigger && !isGrabbing);

        Debug.Log("gripTrigger: "+ gripTrigger.ToString());
        Debug.Log("indexTrigger: " + indexTrigger.ToString());
        Debug.Log("isGrabbing: " + isGrabbing.ToString());
    }
}
