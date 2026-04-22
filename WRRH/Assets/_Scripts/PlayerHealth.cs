using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }
    IEnumerator WaitForDamage()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        currentHealth--;
        animator.SetBool("isHit", true);
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(3, 6, false);
        animator.SetBool("isHit", false);

    }

    public void GetDamage()
    {
        if (currentHealth > 1)
        {
            StartCoroutine(WaitForDamage());
        }
        else
        {
            FindObjectOfType<GameManager>().GameOver();
            Destroy(gameObject);
        }
    }
 public void Heal(int amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;
        }
    }
}