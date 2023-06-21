using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mele : MonoBehaviour
{
    [SerializeField]
    bool death;//czy postać jest śmiercią
    [SerializeField]
    int dmg;//jaki dmg zadaje

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy" && death)
        {
            Debug.Log("trafił");
            other.GetComponent<EnemyController>().GetDmg(dmg);
        }
        else if (other.transform.tag == "Player")
        {
            //chuj wie musze to najpierw napisać XD
        }
    }
}
