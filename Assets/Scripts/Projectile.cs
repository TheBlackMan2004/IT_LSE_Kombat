using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public string direction;
    void Update()
    {
        if (direction == "right") transform.Translate(Vector3.right * Time.deltaTime);
        else transform.Translate(Vector3.left * Time.deltaTime);
    }
}
