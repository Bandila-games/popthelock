using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColliderDectector : MonoBehaviour
{

    [SerializeField] Image test;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        test.color = Color.green;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        test.color = Color.green;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        test.color = Color.white;
    }
}
