using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GateManager gateManager;
    public GameMechanics gameMechanics;
    private int speedCount = 0;
    private int[] slowCount = new int[4] { 0, 0, 0, 0 };
    private int[] closeCount = new int[4] { 0, 0, 0, 0 };
    public void SpeedPowerUp()
    {
        speedCount++;
        foreach(Gate gate in gateManager.gates)
        {
            gate.SpeedUpActive = true;
        }
        gameMechanics.MorePointActive = true;
        StartCoroutine(SpeedPowerUpCleanup());
    }
    private IEnumerator SpeedPowerUpCleanup()
    {
        yield return new WaitForSeconds(12);
        if (speedCount == 1)
        {
            foreach (Gate gate in gateManager.gates)
            {
                gate.SpeedUpActive = false;
            }
            gameMechanics.MorePointActive = false;
        }
        speedCount--;
    }
    public void SlowPowerUp()
    {
        int gateNr = Random.Range(0, 4);
        while (!gateManager.gates[gateNr].Active)
        {
            gateNr = Random.Range(0, 4);
        }
        slowCount[gateNr]++;
        gateManager.gates[gateNr].SlowDownActive = true;
        StartCoroutine(SlowPowerUpCleanup(gateNr));
    }
    private IEnumerator SlowPowerUpCleanup(int gateNr)
    { 
        yield return new WaitForSeconds(12);
        if(slowCount[gateNr] == 1)
        {
            gateManager.gates[gateNr].SlowDownActive = false;
        }
        slowCount[gateNr]--;
    }
    public void CloseGatePowerUp()
    {
        int gateNr = Random.Range(0, 4);
        while (!gateManager.gates[gateNr].Active)
        {
            gateNr = Random.Range(0, 4);
        }
        closeCount[gateNr]++;
        gateManager.gates[gateNr].Active = false;
        StartCoroutine(CloseGatePowerUpClanup(gateNr));
    }
    private IEnumerator CloseGatePowerUpClanup(int gateNr)
    {
        yield return new WaitForSeconds(12);
        if(closeCount[gateNr] == 1)
        {
            gateManager.gates[gateNr].Active = true;
        }
        closeCount[gateNr]--;
    }
}