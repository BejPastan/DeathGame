using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mele : EnemyAttack
{
    [SerializeField]
    bool death;//czy posta� jest �mierci�
    [SerializeField]
    int dmg;//jaki dmg zadaje

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy" && death)
        {
            Debug.Log("trafi�");
            other.GetComponent<EnemyController>().GetDmg(dmg);
        }
        else if (other.transform.tag == "Player")
        {
            //chuj wie musze to najpierw napisa� XD
        }
    }
}
