using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePack : Pickup {

    public override void TakeEffect(PlayerController player)
    {
        player.UpgradeWeapon();
        gameObject.SetActive(false);
    }
}
