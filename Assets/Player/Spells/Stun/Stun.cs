using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Stun : Spell
{
    [SerializeField]
    float duration;
    //zatrzymuje trafionych przeciwników na X sekund
    
    public async override Task ExecuteSpell()
    {
        EnemyController[] enemies;

        GetEnemies(range, out enemies);
        //zatrzymywanie przeciwników
        foreach(EnemyController enemy in enemies)
        {
            enemy.StopAttack((int)(duration*1000));
            enemy.PauseMovement((int)(duration * 1000));
        }
        Debug.Log("wykona³o");
        await Task.Delay((int)(duration * 1000));
    }
}
