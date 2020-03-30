using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveEnemy : MonoBehaviour
{

    Transform Character; // Target Object to follow
    public float speed = 0.3F; // Enemy speed
    private Vector3 directionOfCharacter;
    private bool challenged = false;// If the enemy is Challenged to follow by the player
    private float lerpStr = 5f;
    private CharacterController controller;
    AudioSource hitSource;
    public int lives = 1;
    bool isAlive = true;
    public GameObject destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.FindWithTag("Player").transform;
        controller = GetComponent<CharacterController>();
        hitSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (challenged && isAlive)
        {
            directionOfCharacter = Character.transform.position - transform.position;
            directionOfCharacter = directionOfCharacter.normalized;    // Get Direction to Move Towards
            controller.Move(directionOfCharacter * speed);

            Quaternion targetRotation = Quaternion.LookRotation(-directionOfCharacter);
            float str = Mathf.Min(lerpStr * Time.deltaTime, 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
        }
        if (!isAlive)
        {
            transform.Rotate(10f, 0, 0, Space.Self);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            challenged = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            hitSource.Play();
            if (--lives <= 0)
            {
                isAlive = false;
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
                StartCoroutine("DelayedDeath");
            }
        }
    }

    IEnumerator DelayedDeath()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
