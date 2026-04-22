using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPoints : MonoBehaviour
{
    public Animator anim;


    // Update is called once per frame
    void Update()
    {
        TriggerAnim();
    }

    public void TriggerAnim()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Active");
        }
    }

}
