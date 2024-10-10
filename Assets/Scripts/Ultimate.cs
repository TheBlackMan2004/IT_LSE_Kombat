using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Ultimate : MonoBehaviour
{
    public int ultimateCharge;
    public int ultimateMaxCharge;
    public int ultimateChargePerHit;

  public virtual void CastUltimate() { } 
}
