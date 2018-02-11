using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Pickup {
    public float valueEffect;

    public override void TakeEffect(PlayerController player)
    {
        player.GetHealth(valueEffect);
        gameObject.SetActive(false);
    }
}
