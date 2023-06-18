using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField]
    HealthSystem health;
    //tutaj musi zmieniaæ tekstury po trafieniu

    //przy okazji kontrolujê stan zapory

    //ale to wszystko dopiero kiedy zrobiê tekstury i bêdzie mi siê chcia³o

    public void GetDamage(int dmg)
    {
        if(!health.IsAlive(dmg))
        {
            Destroy(gameObject);
        }
    }
}
