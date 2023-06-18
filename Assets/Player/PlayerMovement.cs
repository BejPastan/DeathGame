using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody physics;
    [SerializeField]
    float movementSpeed;

    [SerializeField]
    SpellController spell;
    [SerializeField]
    

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            //musi siê zatrzymywaæ na œcianach a nie w nie wbiegaæ
            physics.AddForce(direction * movementSpeed, ForceMode.VelocityChange);
        }

        //sprawdzanie czy naciœniêto przycisk od rzucania spelli
        if(Input.GetMouseButtonDown(0))
        {
            //przeliczanie pozycji myszy na pozycjê w œwiecie gry
            Vector3 target = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hitInfo);
            target = hitInfo.point;
            //rzucanie butelki
            spell.CastSpell(target);
        }
    }
}
