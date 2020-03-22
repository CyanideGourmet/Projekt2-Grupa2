using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDir
{
    UP,
    DOWN,
    UPRIGHT,
    DOWNLEFT
}
public class Gate : MonoBehaviour
{
    //Fields and properties
        //Private
    
    private List<Skull> skulls = new List<Skull>();
    private static Dictionary<MovementDir, Vector2> directionVectorMap = new Dictionary<MovementDir, Vector2>
    {
        { MovementDir.UP,       Vector2.up },
        { MovementDir.DOWN,     Vector2.down },
        { MovementDir.UPRIGHT,  Vector2.up + Vector2.right },
        { MovementDir.DOWNLEFT, Vector2.down + Vector2.left }
    };

        //Public
    public GameObject skullPrefab;
    public GateManager gateManager;
    public float skullSpeed = 2;
    public float skullSpeedIncrease = 0.01f;                        //Per second
    public float[] angularVelocityRange = new float[2] { 0, 0 };
    public float secondsBetweenSkulls = 1;
    public float secondsBetweenSkullsDecrease = 0.001f;             //Per second
    public float secondsBetweenSkullsMin = 0.5f;
    public float powerUpChance = 0.05f;

    public int nextSkull { get; set; }
    public MovementDir direction;
    public bool Active { get; set; } = false;
    public bool SpeedUpActive { get; set; } = false;
    public bool SlowDownActive { get; set; } = false;

    //Methods
        //Private
    private void Start()
    {
        nextSkull = gateManager.RandomSkull(true);
        StartCoroutine(Spawn());
    }
    private void Update()
    {
        if (!gateManager.pause)
        {
            if (secondsBetweenSkulls > secondsBetweenSkullsMin) { secondsBetweenSkulls -= secondsBetweenSkullsDecrease * Time.deltaTime; }
            else if (secondsBetweenSkulls < secondsBetweenSkullsMin) { secondsBetweenSkulls = secondsBetweenSkullsMin; }
            skullSpeed += skullSpeedIncrease * Time.deltaTime;
        }
        foreach(Skull skull in skulls)
        {
            Vector2 velocity = directionVectorMap[direction] * skullSpeed;
            if (SpeedUpActive)
            {
                velocity *= 1.25f;
            }
            if (SlowDownActive)
            {
                velocity /= 2;
            }
            if (!Active || gateManager.pause)
            {
                velocity *= 0;
            }
            skull.GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            for (float timer = secondsBetweenSkulls; timer >= 0; timer -= Time.deltaTime)
            {
                while (gateManager.pause) { yield return null; }
                yield return null;
            }
            if (nextSkull != -1 && Active && !gateManager.pause)
            {
                float angularVelocity = Random.Range(angularVelocityRange[0], angularVelocityRange[1]);
                int rotationDirection = Random.Range(0, 2);
                if (rotationDirection == 0) { rotationDirection = -1; }
                angularVelocity *= rotationDirection;

                GameObject skullInstance = Instantiate(skullPrefab, this.transform.position, Quaternion.AngleAxis(Random.Range(0, 91), new Vector3(0, 0, 1)));
                skullInstance.transform.SetParent(this.transform);
                skullInstance.GetComponent<SpriteRenderer>().sprite = gateManager.skullSprites[nextSkull];
                skullInstance.GetComponent<Rigidbody2D>().angularVelocity = angularVelocity;
                skullInstance.GetComponent<Skull>().skullNr = nextSkull;
                skullInstance.GetComponent<Skull>().gate = this;

                if(!gateManager.IsWanted(nextSkull)) { if(Random.Range(0.0f, 1.0f) <= powerUpChance) { skullInstance.GetComponent<Skull>().PowerUp(); } }
                skulls.Add(skullInstance.GetComponent<Skull>());
                nextSkull = gateManager.RandomSkull(true);
            }
        }
    }
        //Public
    public void SkullDestroyed(Skull skull)
    {
        skulls.Remove(skull);
    }
}
