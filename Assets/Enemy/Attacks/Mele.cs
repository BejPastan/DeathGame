using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mele : EnemyAttack
{
    [SerializeField]
    bool death;//czy postaæ jest œmierci¹
    [SerializeField]
    int dmg;//jaki dmg zadaje

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy" && death)
        {
            Debug.Log("trafi³");
            other.GetComponent<EnemyController>().GetDmg(dmg);
        }
        else if (other.transform.tag == "Player")
        {
            //chuj wie musze to najpierw napisaæ XD
        }
    }
}
