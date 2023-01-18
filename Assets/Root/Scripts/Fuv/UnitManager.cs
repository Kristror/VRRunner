using System.Collections;
using UnityEngine;
public class UnitManager : MonoBehaviour
{
    public static UnitController player, enemy;

    public void SetTargetPlayer(UnitController unit)
    {
        player = unit;
    }

    public void SetTargetEnemy(UnitController unit)
    {
        enemy = unit;
    }

    public void SetNullPlayer()
    {
        player = null;
    }

    public void SetNullEnemy()
    {
        enemy = null;
    }
}