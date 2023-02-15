using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCannon : MonoBehaviour
{
    [SerializeField] private GameObject cannonBall = default;
    [SerializeField] private Transform cannonFrontPoint = default;
    [SerializeField] private Animator explosionshootAnim = default;

    private int shootTriggerHash = Animator.StringToHash("shoot");

    public void Shoot()
    {
        Instantiate(cannonBall, cannonFrontPoint.position, cannonFrontPoint.rotation).GetComponent<CannonAiBall>().AddVelocity(1);
        explosionshootAnim.SetTrigger(shootTriggerHash);
    }
}
