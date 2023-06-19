using UnityEngine;
using System.Threading.Tasks;

public class WallAttack : EnemyAttack
{
    [SerializeField]

    public async override Task Attack()
    {
        //odpala animację ataku
        //czeka do końca animacji
        //tworzy kolejne fragmenty wall'a
    }
}
