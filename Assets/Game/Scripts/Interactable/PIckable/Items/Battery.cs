using UnityEngine;
using UnityEngine.Events;

public class Battery : Item
{
    public override void Pickup(PlayerCharacter mc)
    {
        base.Pickup(mc);
        mc.Flashlight.RefillBatteryLevel();
    }
}
