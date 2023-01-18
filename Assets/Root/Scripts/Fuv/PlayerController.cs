using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlayerController : UnitController
{
    private VirtualButtonBehaviour virtualButton;

    private void Start()
    {
        virtualButton = gameObject.transform.parent.GetComponentInChildren<VirtualButtonBehaviour>();
        virtualButton.RegisterOnButtonPressed(OnButtonPressed);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if(!isDead && UnitManager.enemy != null)
        {
            combat.Attack(UnitManager.enemy.health);
        }
    }

    protected override void Die()
    {
        base.Die();
        UnitManager.player = null;
    }
}