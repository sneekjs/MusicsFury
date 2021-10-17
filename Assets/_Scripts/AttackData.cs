using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackData
{
    public enum AttackType
    {
        Cross,
        Cirlce,
        Swirl,
        SpawnAirdrop,
        AirDropAttack
    }

    public AttackType type;
    public OrbData orbBehaviour;
}
