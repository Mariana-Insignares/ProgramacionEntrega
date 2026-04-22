using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStaticAttack : MonoBehaviour
{
    public Animator anim;
    public float detectionRange = 5f;
    private Transform _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (_player != null)
        {
            float distance = Vector2.Distance(transform.position, _player.position);

            // Si el jugador entra en rango, el enemigo "ataca" (animacion)
            if (distance < detectionRange)
            {
                anim.SetTrigger("Attack");
            }
        }
    }
}