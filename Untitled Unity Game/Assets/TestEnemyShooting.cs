using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    public float spellDamage;
    public float spellVelocity;
    public float cooldown;

    void Start()
    {
        StartCoroutine(ShootPlayer());
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);
        if (player != null)
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.transform.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * spellVelocity;
            spell.GetComponent<TestEnemyProjectile>().damage = spellDamage;
            StartCoroutine(ShootPlayer());
        }
    }
}
