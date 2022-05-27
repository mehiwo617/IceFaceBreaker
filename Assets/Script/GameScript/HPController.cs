using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]

public class HPController : MonoBehaviour
{
    GameObject director;
    Animator animator;
    AnimatorStateInfo currentState;
    int bomb = 0;

    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        this.animator = GetComponent<Animator>();
    }

    public void Damage()
    {
        bomb++;

        this.GetComponent<Image>().fillAmount -= 0.2f;
        animator.SetInteger("bomb", bomb);
        if (bomb > 3)
        {
            animator.Play("HP3");
        }
    }

    public void Damage2()
    {
        bomb++;

        this.GetComponent<Image>().fillAmount -= 0.1f;
        animator.SetInteger("bomb", bomb);
        if (bomb > 3)
        {
            animator.Play("HP3");
        }
    }

}
