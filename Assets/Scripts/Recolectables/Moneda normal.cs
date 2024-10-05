using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedanormal : MonoBehaviour
{
    public int puntosPorMoneda = 1; 
    public Vector2 minPos; 
    public Vector2 maxPos; 
    public static int puntuacion = 0; 

    void Start()
    {
        GenerarMoneda();
    }

    void GenerarMoneda()
    {
        float x = Random.Range(minPos.x, maxPos.x);
        float y = Random.Range(minPos.y, maxPos.y);
        transform.position = new Vector2(x, y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puntuacion += puntosPorMoneda;
            Debug.Log("Puntos: " + puntuacion);

            GenerarMoneda();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 areaSize = new Vector3(maxPos.x - minPos.x, maxPos.y - minPos.y, 0);
        Vector3 areaCenter = new Vector3((minPos.x + maxPos.x) / 2, (minPos.y + maxPos.y) / 2, 0);
        Gizmos.DrawWireCube(areaCenter, areaSize);
    }
}
