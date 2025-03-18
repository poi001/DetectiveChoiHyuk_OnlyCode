using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{

    public ITrigger trigger;

    

    public void CallTriggerExecute()
    {
        trigger.Execute();
    }








}
