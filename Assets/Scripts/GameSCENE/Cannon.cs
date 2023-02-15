using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject cannonBall = default;
    [SerializeField] private Transform cannonFrontPoint = default;
    [SerializeField] private Animator explosionshootAnim = default;

    [SerializeField] private bool specialShot = default;
    [SerializeField] private bool rightDir = default;

    private int shootTriggerHash = Animator.StringToHash("shoot");

    private void Update()
    {
        Shoot();
        SpecialShot();
    }

    private void Shoot()
    {
        if (!specialShot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(cannonBall, cannonFrontPoint.position, cannonFrontPoint.rotation).GetComponent<CannonBall>().AddVelocity(1);
                explosionshootAnim.SetTrigger(shootTriggerHash);
            }
        }
    }

    private void SpecialShot()
    {
        if (specialShot)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                explosionshootAnim.SetTrigger(shootTriggerHash);
                Instantiate(cannonBall, cannonFrontPoint.position, cannonFrontPoint.rotation).GetComponent<CannonBall>().AddVelocity(rightDir ? -1 : 1);
                //atira para os lados
            }
        }
    }
}
