using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage=15;
    public string direction;
    public float size = 0.2f;
    [SerializeField] CharacterBase thrower;
    [SerializeField] LayerMask layer;
    private void Start()
    {
        var characters = FindObjectsOfType<CharacterBase>();
        foreach(CharacterBase character in characters)
        {
            if (character.characterName == thrower.characterName) thrower = character;
        }
        if (thrower.facesRight) direction = "right";
        else direction = "left";
    }
    void Update()
    {
        if (direction == "right") transform.Translate(Vector3.right * Time.deltaTime * speed);
        else transform.Translate(Vector3.left * Time.deltaTime * speed);
        checkCollision();
    }

    void checkCollision()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, size, layer );
        foreach( Collider2D enemy in enemies)
        {
            if(thrower.characterName!= enemy.GetComponent<CharacterBase>().characterName)
            {
                enemy.GetComponent<CharacterBase>().TakeDamage(damage);
                Destroy(gameObject);
            }
           
        }
    }

}
