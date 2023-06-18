using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[System.Serializable]
public class EnemyAttack : MonoBehaviour
{
    public float cooldawn;
    public int attackChance;//ten tajemniczy mysi sprz�t przyda nam si� p�niej
    protected bool alive;

    public async virtual Task Attack()
    {
        Debug.Log("co� zjeba�em z atakami");
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
