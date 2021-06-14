using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColliderDectector : MonoBehaviour
{

    [SerializeField] Image test;

    [SerializeField] GameManager gameManager;
    [SerializeField] LockController lockController;
    public bool IsColliding;

    public bool isTappedWhileColliding = false;

    private void Awake()
    {
        //OriginalColor = test.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      //  test.color = Color.green;
        IsColliding = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

      //  test.color = Color.green;
        IsColliding = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      //  test.color = OriginalColor;
        IsColliding = false;
        if (isTappedWhileColliding == false)
        {
            lockController.StopRotation();
         // StartCoroutine(gameManager.GameFinished(true));
        }
        else { isTappedWhileColliding = false; }
    }
}
