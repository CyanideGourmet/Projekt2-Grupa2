using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateManager : MonoBehaviour
{
    public bool pause { get; set; }
    public Gate gate1;
    public Gate gate2;
    public Gate gate3a;
    public Gate gate3b;
    public Gate[] gates { get; set; }
    public Sprite[] skullSprites;
    public float gate2OpenTime = 30;
    public float gate3aOpenTime = 60;
    public float gate3bOpenTime = 120;
    public GameObject reference;


    private int wantedSkull;
    
    private void Start()
    {
        gates = new Gate[4];
        gates[0] = gate1;
        gates[1] = gate2;
        gates[2] = gate3a;
        gates[3] = gate3b;
        gate1.Active = true;
        NewWanted();
        StartCoroutine(Shake(0, 0));
        StartCoroutine(Shake(0, 4));
        StartCoroutine(OpenGate(1, gate2OpenTime));
        StartCoroutine(Shake(1, gate2OpenTime - 3));
        StartCoroutine(Shake(1, gate2OpenTime + 2));
        StartCoroutine(OpenGate(2, gate3aOpenTime));
        StartCoroutine(Shake(2, gate3aOpenTime - 3));
        StartCoroutine(Shake(2, gate3aOpenTime + 2));
        StartCoroutine(OpenGate(3, gate3bOpenTime));
        StartCoroutine(Shake(3, gate3bOpenTime - 3));
        StartCoroutine(Shake(3, gate3bOpenTime + 2));
    }
    IEnumerator QueueWanted()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 10.0f));
        int gateNr = Random.Range(0, 4);
        while(!gates[gateNr].Active)
        {
            gateNr = Random.Range(0, 4);
        }
        gates[gateNr].Active = false;
        gates[gateNr].nextSkull = wantedSkull;
        gates[gateNr].Active = true;
    }
    public int RandomSkull(bool noWanted = false)
    {
        int randomSkull;
        do
        {
            randomSkull = Random.Range(0, skullSprites.Length);
        } while (randomSkull == wantedSkull && noWanted);
        return randomSkull;
    }
    public bool IsWanted(int skullSprite)
    {
        return skullSprite == wantedSkull;
    }
    public void NewWanted()
    {
        wantedSkull = RandomSkull();
        reference.GetComponent<Image>().sprite = skullSprites[wantedSkull];
        StartCoroutine(QueueWanted());
    }
    public void Pause()
    {
        pause = !pause;
    }
    private IEnumerator OpenGate(int gateNr, float time)
    {
        for (float timer = time; timer >= 0; timer -= Time.deltaTime)
        {
            while (pause) { yield return null; }
            yield return null;
        }
        gates[gateNr].Active = true;
    }
    private IEnumerator Shake(int gateNr, float time)
    {
        for (float timer = time; timer >= 0; timer -= Time.deltaTime)
        {
            while (pause) { yield return null; }
            yield return null;
        }
        gates[gateNr].GetComponent<Animator>().SetBool("Shaking", !gates[gateNr].GetComponent<Animator>().GetBool("Shaking"));
    }
}
