using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EasterEggEventTriggers : EventTrigger {

    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        AudioManager.instance.StartEasterEggActivation();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        AudioManager.instance.StopEasterEggActivation();
    }
}
