using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUp { ChangeScene, Shield, PW3, PW4 };

public class PowerUpScript : MonoBehaviour
{
    public PowerUp powerUpType = PowerUp.Shield;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        switch (powerUpType)
        {
            case PowerUp.ChangeScene:
                animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimationChangeScene");
                break;
            case PowerUp.Shield:

                break;
            case PowerUp.PW3:
                break;
            case PowerUp.PW4:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //GameManager.Instance.HP++;
            //Destroy(collision.gameObject);
            //GameManager.Instance.score += 100;
        }
    }
}
