using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public Spell usedSpell;
    public GameObject throwPrefab;

    private void Start()
    {
        GetSpell();
    }

    private void GetSpell()
    {
        usedSpell = throwPrefab.GetComponent<Spell>();
        Debug.Log(usedSpell);
    }

    //rzucanie butelki czy co to tam bêdzie z tym spellem
    public void CastSpell(Vector3 target)
    {
        //pobieranie warotœci wysokoœci paraboli
        float parabolaHeight = usedSpell.paraboleHeight;
        //obliczanie si³ aby mo¿na by³o rzuciæ spella po paraboli
        float verticalSpeed = Mathf.Sqrt(2 * parabolaHeight * Physics.gravity.magnitude);
        target.x -= transform.position.x;
        target.z -= transform.position.z;
        Debug.Log(target);
        Vector3 velocityDirection = target;
        velocityDirection.y = 0;
        velocityDirection = velocityDirection.normalized;
        float time = 2 * Mathf.Sqrt(2 * parabolaHeight / Physics.gravity.magnitude);
        float distance = Mathf.Sqrt((target.x * target.x) + (target.z * target.z));
        float speed = distance / time;
        Debug.Log(speed);
        velocityDirection = velocityDirection * speed + GetComponent<Rigidbody>().velocity / 4;
        velocityDirection.y = verticalSpeed;
        Debug.Log("force Direction: " + velocityDirection);
        //tworzenie kopi itemu do rzucenia
        GameObject throwedSpell = Instantiate(throwPrefab, transform.position, transform.rotation);
        //nadawanie prêdkoœci
        throwedSpell.GetComponent<Rigidbody>().AddForce(velocityDirection, ForceMode.VelocityChange);
    }

}
