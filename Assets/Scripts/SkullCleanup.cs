using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullCleanup : MonoBehaviour
{
    public GateManager gateManager;
    public GameMechanics gameMechanics;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Skull")
        {
            if (gateManager.IsWanted(collision.collider.GetComponent<Skull>().skullNr) && !collision.collider.GetComponent<Skull>().IsPowerUp)
            {
                gateManager.NewWanted();
                gameMechanics.Damage();
            }
            collision.collider.GetComponent<Skull>().DeferDestroy();
        }
    }
}
