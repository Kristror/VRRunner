using UnityEditor;
using UnityEngine;

public class EnemyController : UnitController
{
    protected override void Update()
    {
        base.Update();
        if(!isDead && UnitManager.player.health != null)
        {
            combat.Attack(UnitManager.player.health);
        }
    }

    protected override void Die()
    {
        base.Die();

        UnitManager.enemy = null;
    }
}