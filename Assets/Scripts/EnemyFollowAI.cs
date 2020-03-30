using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowAI : MonoBehaviour
{
    public Transform Character; // Target Object to follow
    public float speed = 0.3F; // Enemy speed
    private Vector3 directionOfCharacter;
    private bool challenged = false;// If the enemy is Challenged to follow by the player
    private float lerpStr = 5f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (challenged)
        {
            directionOfCharacter = Character.transform.position - transform.position;
            directionOfCharacter = directionOfCharacter.normalized;    // Get Direction to Move Towards
            controller.Move(directionOfCharacter * speed);
            // transform.Translate(directionOfCharacter * speed, Space.World);

            Quaternion targetRotation = Quaternion.LookRotation(-directionOfCharacter);
            float str = Mathf.Min(lerpStr * Time.deltaTime, 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
        }
    }
    // Will be triggered as soon as player is in range of Enemy Object
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            challenged = true;
        }
    }
}
