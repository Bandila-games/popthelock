using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColliderDectector : MonoBehaviour
{

    [SerializeField] Image test;

    public bool IsColliding;

    private bool _IsCollding;
    private Color OriginalColor;
    private void Awake()
    {
        OriginalColor = test.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        test.color = Color.green;
        IsColliding = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        test.color = Color.green;
        IsColliding = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        test.color = OriginalColor;
        IsColliding = false;
    }
}
