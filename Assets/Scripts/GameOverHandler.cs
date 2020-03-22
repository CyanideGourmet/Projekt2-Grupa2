using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<RectTransform>().position.x > -0.1f && GetComponent<RectTransform>().position.x < 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<RectTransform>().position = Vector3.zero;
            StartCoroutine(LeaveScreen());
        }
        if(GetComponent<RectTransform>().position.x > 20)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator LeaveScreen()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
    }
}
