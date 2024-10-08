using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Animator playerAnim;



    [SerializeField]
    private GameObject sword;
    [SerializeField]
    private GameObject swordOnShoulder;
    public bool isEquipping;
    public bool isEquipped;


  
    public bool isAttacking;

    public bool isHAttacking;
    private float timeSinceAttack;
    private float timeSinceHAttack;
    public int currentAttack = 0;
    public int currentHAttack = 0;



    private void Update()
    {
        timeSinceAttack += Time.deltaTime;
        timeSinceHAttack += Time.deltaTime;

        Attack();
        HAttack();

        Equip();
        
        
    }

    private void Equip()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerAnim.GetBool("Grounded"))
        {
            isEquipping = true;
            playerAnim.SetTrigger("Equip");
        }
    }

    public void ActiveWeapon()
    {
        if (!isEquipped)
        {
            sword.SetActive(true);
            swordOnShoulder.SetActive(false);
            isEquipped = !isEquipped;
        }
        else
        {
            sword.SetActive(false);
            swordOnShoulder.SetActive(true);
            isEquipped = !isEquipped;
        }
    }

    public void Equipped()
    {
        isEquipping = false;
    }

    private void Attack()
    {

        if (Input.GetMouseButtonDown(0) && playerAnim.GetBool("Grounded") && timeSinceAttack > 0.8f)
        {
            if (!isEquipped)
                return;

            currentAttack++;
            isAttacking = true;

            if (currentAttack > 3)
                currentAttack = 1;

 
            if (timeSinceAttack > 1.0f)
                currentAttack = 1;

            playerAnim.SetTrigger("Attack" + currentAttack);

 
            timeSinceAttack = 0;
        }





    }

        public void ResetAttack()
    {
        isAttacking = false;
        isHAttacking = false;
    } 
    private void HAttack()
    {

        if (Input.GetMouseButtonDown(1) && playerAnim.GetBool("Grounded") && timeSinceHAttack > 0.8f)
        {
            if (!isEquipped)
                return;

            currentHAttack++;
            isHAttacking = true;

            if (currentHAttack > 3)
                currentHAttack = 1;

  
            if (timeSinceHAttack > 1.0f)
                currentHAttack = 1;

    
            playerAnim.SetTrigger("HAttack" + currentHAttack);

  
            timeSinceHAttack = 0;
        }





    }
    
  
    public void ResetHAttack()
    {
        isHAttacking = false;
    } 
}   
