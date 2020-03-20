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
    public bool IsPowerUp         { get { return isPowerUp; } protected set { isPowerUp = value; } }
    public PowerUpType PowerType  { get { return powerType; } protected set { powerType = value; } }
    public int skullNr { get; set; }

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
                this.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case PowerUpType.SLOW:
                this.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case PowerUpType.CLOSE:
                this.GetComponent<SpriteRenderer>().color = Color.magenta;
                break;
        }
    }
}
