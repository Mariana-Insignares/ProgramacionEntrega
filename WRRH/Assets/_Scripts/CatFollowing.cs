using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalGuide : MonoBehaviour
{
    [Header("Stalking")]
    public Transform target;        
    public float followSpeed = 3f;  
    public float stopDistance = 2f; 
    public Vector3 offset = new Vector3(-1f, 1f, 0f); 

    [Header("Final Destination")]
    public Transform finalDestination; 
    private bool isFinishing = false;

    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) target = player.transform;
        }
    }

    void Update()
    {
        if (target == null) return;

        if (isFinishing)
        {
            MoveTowards(finalDestination.position);
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if (distanceToPlayer > stopDistance)
        {
            Vector3 targetPosition = target.position + offset;
            MoveTowards(targetPosition);
        }
        FlipSprite();
    }

    void MoveTowards(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, followSpeed * Time.deltaTime);
    }

    void FlipSprite()
    {
        if (target.position.x > transform.position.x)
            _spriteRenderer.flipX = false; 
        else
            _spriteRenderer.flipX = true;  
    }

  
    public void GoToFinalExit(Transform exitPoint)
    {
        finalDestination = exitPoint;
        isFinishing = true;
    }
}