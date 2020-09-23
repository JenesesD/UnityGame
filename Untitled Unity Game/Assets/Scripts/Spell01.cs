using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell01 : MonoBehaviour
{
    public GameObject projectile;
    public float damage;
    public float projectileVelocity;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 playerPos = transform.position;
            Vector2 direction = (mousePos - playerPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileVelocity;
        }
    }
}
