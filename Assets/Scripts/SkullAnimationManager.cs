using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AnimationType
{
    POINT,
    DEATH,
    POWER
}
public enum SkullType
{
    _1X6,
    _7X10,
    _11X16,
    _17X19,
    RED,
    BLUE,
    GREEN
}
public class SkullAnimationManager : MonoBehaviour
{
    public AnimationType animationType;
    public SkullType skullType;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Play()
    {
        animator = GetComponent<Animator>();
        switch (animationType)
        {
            case AnimationType.POINT:
                Point();
                break;
            case AnimationType.DEATH:
                Death();
                break;
            case AnimationType.POWER:
                Power();
                break;
        }
        SkullAnimate();
        StartCoroutine(Delete());
    }
    private void Point()
    {
        animator.ResetTrigger("Death");
        animator.ResetTrigger("Power");
        animator.SetTrigger("Points");
    }
    private void Death()
    {
        animator.ResetTrigger("Points");
        animator.ResetTrigger("Power");
        animator.SetTrigger("Death");
    }
    private void Power()
    {
        animator.ResetTrigger("Points");
        animator.ResetTrigger("Death");
        animator.SetTrigger("Power");
    }
    private void SkullAnimate()
    {
        animator.ResetTrigger("1x6");
        animator.ResetTrigger("7x10");
        animator.ResetTrigger("11x16");
        animator.ResetTrigger("17x19");
        animator.ResetTrigger("Red");
        animator.ResetTrigger("Blue");
        animator.ResetTrigger("Green");
        string trigger = "";
        switch(skullType)
        {
            case SkullType._1X6:
                trigger = "1x6";
                break;
            case SkullType._7X10:
                trigger = "7x10";
                break;
            case SkullType._11X16:
                trigger = "11x16";
                break;
            case SkullType._17X19:
                trigger = "17x19";
                break;
            case SkullType.RED:
                trigger = "Red";
                break;
            case SkullType.BLUE:
                trigger = "Blue";
                break;
            case SkullType.GREEN:
                trigger = "Green";
                break;
        }
        animator.SetTrigger(trigger);
    }
    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(0.99f);
        Destroy(this.gameObject);
    }
}