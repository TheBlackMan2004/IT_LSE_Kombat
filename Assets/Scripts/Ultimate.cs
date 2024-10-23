using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Ultimate : MonoBehaviour
{
    public int ultimateCharge;
    public int ultimateMaxCharge;
    public int ultimateChargePerHit;
    public void ChargeUlt()
    {
        ultimateCharge += ultimateChargePerHit;
    }
    private void Start()
    {
        ultimateCharge = 0;
    }
    public virtual void CastUltimate() { } 
}
