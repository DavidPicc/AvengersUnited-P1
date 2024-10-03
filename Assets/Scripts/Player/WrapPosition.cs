using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapPosition : MonoBehaviour
{
    public Transform playerPos;
    public Transform tpPosition;
    public bool isVerticalTP;

    private void Start()
    {
        playerPos = FindAnyObjectByType<PlayerMovement>().transform;
    }
    public void Teleport()
    {
        if (isVerticalTP)
        {
            playerPos.transform.position = tpPosition.transform.position;
            
        }
        else
        {
            Vector2 newPos = new Vector2(tpPosition.position.x, playerPos.position.y);
            playerPos.transform.position = newPos;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("entra");
            Teleport();
        }
    }
}
