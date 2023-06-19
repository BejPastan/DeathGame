using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableWall : MonoBehaviour
{
    [SerializeField]
    HealthSystem health;
    //tutaj musi zmieniaæ tekstury po trafieniu

    //przy okazji kontrolujê stan zapory

    //ale to wszystko dopiero kiedy zrobię tekstury i będzie mi się chciało

    public void GetDamage(int dmg)
    {
        if (!health.IsAlive(dmg))
        {
            Destroy(gameObject);
        }
    }
}
