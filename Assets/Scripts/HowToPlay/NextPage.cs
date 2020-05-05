using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPage : MonoBehaviour
{
    public GameObject nextPage;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Next);
    }
    private void Next()
    {
        nextPage.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
