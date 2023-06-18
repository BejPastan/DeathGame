using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[System.Serializable]
public class EnemyAttack : MonoBehaviour
{
    public float cooldawn;
    public int attackChance;//ten tajemniczy mysi sprzêt przyda nam siê póŸniej
    protected bool alive;

    public async virtual Task Attack()
    {
        Debug.Log("coœ zjeba³em z atakami");
    }

    public void StartAttack()
    {
        alive = true;
    }

    public virtual void StopFight()
    {
        alive = false;
    }
}
