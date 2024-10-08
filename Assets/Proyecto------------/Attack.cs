using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Vertical");
        anim.SetFloat("vertical", movement);

        bool isMoving = movement != 0;
        anim.SetBool("isMoving", isMoving);

        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetTrigger("attack");
        }
    }
}
