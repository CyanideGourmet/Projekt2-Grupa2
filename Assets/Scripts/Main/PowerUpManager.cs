using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public GateManager gateManager;
    public GameMechanics gameMechanics;
    public Text speedText;
    private float speedTime = 0;
    private int speedCount = 0;
    private int[] slowCount = new int[4] { 0, 0, 0, 0 };
    private int[] closeCount = new int[4] { 0, 0, 0, 0 };
    private void Update()
    {
        speedText.text = Convert.ToString(Math.Round(speedTime));
    }
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
        for(float time = 5; time >= 0; time -= Time.deltaTime)
        {
            while(gateManager.pause)
            {
                speedTime = time;
                yield return null;
            }
            speedTime = time;
            yield return null;
        }
        if (speedCount == 1)
        {
            foreach (Gate gate in gateManager.gates)
            {
                gate.SpeedUpActive = false;
            }
            gameMechanics.MorePointActive = false;
            speedTime = 0;
        }
        speedCount--;
    }
    public void SlowPowerUp()
    {
        int gateNr = UnityEngine.Random.Range(0, 4);
        while (!gateManager.gates[gateNr].Active)
        {
            gateNr = UnityEngine.Random.Range(0, 4);
        }
        slowCount[gateNr]++;
        gateManager.gates[gateNr].SlowDownActive = true;
        StartCoroutine(SlowPowerUpCleanup(gateNr));
    }
    private IEnumerator SlowPowerUpCleanup(int gateNr)
    {
        for (float time = 5; time >= 0; time -= Time.deltaTime)
        {
            while (gateManager.pause)
            {
                yield return null;
                foreach (Gate gate in gateManager.gates)
                {
                    if(gate.SlowDownActive)
                    {
                        if(time >= 0) { gate.slowDownTime = time; }
                        else { gate.slowDownTime = 0; }
                    }
                }
            }
            yield return null;
            foreach (Gate gate in gateManager.gates)
            {
                if (gate.SlowDownActive)
                {
                    if (time >= 0) { gate.slowDownTime = time; }
                    else { gate.slowDownTime = 0; }
                }
            }
        }
        if (slowCount[gateNr] == 1)
        {
            gateManager.gates[gateNr].SlowDownActive = false;
            gateManager.gates[gateNr].slowDownTime = 0;
        }
        slowCount[gateNr]--;
    }
    public void CloseGatePowerUp()
    {
        int gateNr = UnityEngine.Random.Range(0, 4);
        while (!gateManager.gates[gateNr].Active)
        {
            gateNr = UnityEngine.Random.Range(0, 4);
        }
        closeCount[gateNr]++;
        gateManager.gates[gateNr].Active = false;
        StartCoroutine(CloseGatePowerUpClanup(gateNr));
    }
    private IEnumerator CloseGatePowerUpClanup(int gateNr)
    {
        for (float time = 5; time >= 0; time -= Time.deltaTime)
        {
            int temp = 0;
            while (gateManager.pause)
            {
                yield return null;
                temp = 0;
                foreach (Gate gate in gateManager.gates)
                {
                    if (!gate.Active && closeCount[temp] > 0)
                    {
                        if (time >= 0) { gate.closeTime = time; }
                        else { gate.closeTime = 0; }
                    }
                    temp++;
                }
            }
            yield return null;
            temp = 0;
            foreach (Gate gate in gateManager.gates)
            {
                if (!gate.Active && closeCount[temp] > 0)
                {
                    if (time >= 0) { gate.closeTime = time; }
                    else { gate.closeTime = 0; }
                }
                temp++;
            }
        }
        if (closeCount[gateNr] == 1)
        {
            gateManager.gates[gateNr].Active = true;
            gateManager.gates[gateNr].closeTime = 0;
        }
        closeCount[gateNr]--;
    }
}