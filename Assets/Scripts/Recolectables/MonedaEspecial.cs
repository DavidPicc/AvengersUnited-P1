using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaEspecial : MonoBehaviour
{
    public int puntosPorMoneda = 5; 
    public Vector2 minPos; 
    public Vector2 maxPos;
    public float tiempoDeAparicion = 10f; 
    public static int puntuacion = 0; 
    private bool monedaActiva = false;

    void Start()
    {
        InvokeRepeating("GenerarMonedaEspecial", tiempoDeAparicion, tiempoDeAparicion);
    }

    void GenerarMonedaEspecial()
    {
        if (!monedaActiva)
        {
            float x = Random.Range(minPos.x, maxPos.x);
            float y = Random.Range(minPos.y, maxPos.y);
            transform.position = new Vector2(x, y);
            monedaActiva = true;
            gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puntuacion += puntosPorMoneda;
            Debug.Log("Puntos: " + puntuacion);

            monedaActiva = false;
            gameObject.SetActive(false); 
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 areaSize = new Vector3(maxPos.x - minPos.x, maxPos.y - minPos.y, 0);
        Vector3 areaCenter = new Vector3((minPos.x + maxPos.x) / 2, (minPos.y + maxPos.y) / 2, 0);
        Gizmos.DrawWireCube(areaCenter, areaSize);
    }
}
