﻿using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
    public GameObject beamPrefab;
    public AudioClip fireSound;
    public AudioClip death;
    
    public float health = 150f;
    public float damage = 0f;
    public float projectileSpeed = 2f;
    public float firingRate = 2f;
    public float shotsPerSeconds = .5f;
    public int scoreValue = 100;

    private ScoreKeeper sk;

    void Start()
    {
        sk = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Projectile>() != null)
        {
            Projectile missle = col.gameObject.GetComponent<Projectile>();
            damage += missle.GetDamage();
            missle.Hit();
            if (health <= damage)
            {
                AudioSource.PlayClipAtPoint(death, transform.position);
                sk.Score(scoreValue);
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        float probability = Time.deltaTime * shotsPerSeconds;
        if(Random.value < probability)
        Fire();

    }

    void Fire()
    {
        GameObject beam = Instantiate(beamPrefab, transform.position,
                  Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
    

}
