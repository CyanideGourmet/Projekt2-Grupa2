using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PowerUpType
{
    SPEED,
    SLOW,
    CLOSE
}

public class Skull : MonoBehaviour
{
    //Fields and properties
        //Private
    private bool isPowerUp = false;
    private PowerUpType powerType;
        //Public
    public Gate gate;
    public GameObject deadAnim;
    public bool IsPowerUp         { get { return isPowerUp; } protected set { isPowerUp = value; } }
    public PowerUpType PowerType  { get { return powerType; } protected set { powerType = value; } }
    public int skullNr { get; set; }
    public SkullType skullType { get; set; }

    //Methods
        //private
    private IEnumerator CDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy();
    }
        //public
    public void Destroy()
    {
        gate.SkullDestroyed(this);
        Destroy(this.gameObject);
    }
    public void DeferDestroy(float time = 0.5f)
    {
        StartCoroutine(CDestroy(time));
    }
    public void PowerUp()
    {
        IsPowerUp = true;
        PowerType = (PowerUpType)Random.Range(0, 3);
        switch(PowerType)
        {
            case PowerUpType.SPEED:
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BUFF_3");
                skullType = SkullType.RED;
                break;
            case PowerUpType.SLOW:
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BUFF_2");
                skullType = SkullType.GREEN;
                break;
            case PowerUpType.CLOSE:
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BUFF_1");
                skullType = SkullType.BLUE;
                break;
        }
    }
    public IEnumerator Fade(AnimationType animationT)
    {
        gate.SkullDestroyed(this);
        yield return new WaitForSeconds(0.14f);
        GameObject deadAnimation = Instantiate(deadAnim, this.transform.position, this.transform.rotation);
        deadAnimation.GetComponent<SkullAnimationManager>().animationType = animationT;
        deadAnimation.GetComponent<SkullAnimationManager>().skullType = skullType;
        deadAnimation.GetComponent<SkullAnimationManager>().Play();
        Destroy(this.gameObject);
    }
}
