using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField]
    HealthSystem health;
    //tutaj musi zmienia� tekstury po trafieniu

    //przy okazji kontroluj� stan zapory

    //ale to wszystko dopiero kiedy zrobi� tekstury i b�dzie mi si� chcia�o

    public void GetDamage(int dmg)
    {
        if(!health.IsAlive(dmg))
        {
            Destroy(gameObject);
        }
    }
}
