using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    int maxHP;
    [SerializeField]
    int currentHP;

    private void Start()
    {
        currentHP = maxHP;
    }

    public bool IsAlive(int dmg)
    {
        currentHP -= dmg;
        return (currentHP > 0);
    }
}
