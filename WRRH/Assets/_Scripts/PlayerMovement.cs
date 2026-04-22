using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Velocity;
    private Rigidbody2D _rb;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
    }

    void ProcessMovement()
    {
        float inputMovement = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(inputMovement * Velocity, _rb.velocity.y);

        ManageOrientation(inputMovement);
    }

    void ManageOrientation(float inputMovement)
    {
        if (isFacingRight == true && inputMovement < 0 || (isFacingRight == false && inputMovement > 0))
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}