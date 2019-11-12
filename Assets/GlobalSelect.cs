using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Microsoft.MixedReality.Toolkit.Input;
public class GlobalSelect : BaseInputHandler, IMixedRealityInputHandler
{

    [Tooltip("Fire a global if focused game object is not one of these")]
    public LayerMask ignoreLayers = 0/*nothing*/;
    [Tooltip("The event fired on a Holo tap.")]
    public UnityEvent Tap;

    public void OnInputUp(InputEventData eventData)
    {

    }
    public void OnInputDown(InputEventData eventData)
    {
        Tap.Invoke();
    }

    protected override void RegisterHandlers()
    {

    }

    protected override void UnregisterHandlers()
    {

    }

}