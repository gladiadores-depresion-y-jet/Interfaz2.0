using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desplazamiento : MonoBehaviour
{
    Vector3 tempos;
    Vector3 targetPos;
    Vector3 velocidad;
    float tiempo = 1f;
    Text text;
    int x, y;
    // Start is called before the first frame update
    void Start()
    {
        tempos = transform.position;
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != targetPos)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocidad, tiempo);
        }

    }

    public void setTargetPos(Vector3 pos)
    {
        targetPos = pos;
        velocidad = Vector3.zero;
    }
    public void mover(int x, int y)
    {
        tempos.x = (float)-4.5+x;
        tempos.z = y;

        transform.position = tempos;
    }
}
