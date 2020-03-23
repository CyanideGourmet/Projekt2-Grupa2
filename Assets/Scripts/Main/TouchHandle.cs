using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandle : MonoBehaviour
{
    private Vector3 touchPositionW;

    public TouchPhase touchPhase = TouchPhase.Began;
    public GameMechanics gameMechanics;
    public PowerUpManager powerUpManager;
    public GateManager gateManager;
    public SkullSounds skullSounds;
    void Update()
    {
        if(Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
                if(touch.phase == touchPhase)
                {
                    touchPositionW = Camera.main.ScreenToWorldPoint(touch.position);
                    Vector2 touchPositionW2D = new Vector2(touchPositionW.x, touchPositionW.y);
                    RaycastHit2D hitInformation = Physics2D.Raycast(touchPositionW2D, Camera.main.transform.forward);
                    if (hitInformation.collider != null)
                    {
                        if (hitInformation.collider.tag == "Skull" && !gateManager.pause)
                        {
                            if (gateManager.IsWanted(hitInformation.collider.GetComponent<Skull>().skullNr) && !hitInformation.collider.GetComponent<Skull>().IsPowerUp)
                            {
                                skullSounds.GoodSkull();
                                gateManager.NewWanted();
                                gameMechanics.AddPoints(gameMechanics.pointReward);
                                if(gameMechanics.MorePointActive)
                                {
                                    gameMechanics.AddPoints(Convert.ToInt32(gameMechanics.pointReward * 0.5f));
                                }
                                StartCoroutine(hitInformation.collider.GetComponent<Skull>().Fade(AnimationType.POINT));
                            }
                            else if(hitInformation.collider.GetComponent<Skull>().IsPowerUp)
                            {
                                skullSounds.GoodSkull();
                                switch (hitInformation.collider.GetComponent<Skull>().PowerType)
                                {
                                    case PowerUpType.SLOW:
                                        powerUpManager.SlowPowerUp();
                                        break;
                                    case PowerUpType.SPEED:
                                        powerUpManager.SpeedPowerUp();
                                        break;
                                    case PowerUpType.CLOSE:
                                        powerUpManager.CloseGatePowerUp();
                                        break;
                                }
                                StartCoroutine(hitInformation.collider.GetComponent<Skull>().Fade(AnimationType.POWER));
                            }
                            else
                            {
                                skullSounds.BadSkull();
                                gameMechanics.Damage();
                                StartCoroutine(hitInformation.collider.GetComponent<Skull>().Fade(AnimationType.DEATH));
                            }
                        }
                    }
                }
            }
        }
    }
}
