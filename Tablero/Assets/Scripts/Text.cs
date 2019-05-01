using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Text : MonoBehaviour
{
    public InputField posX;
    public InputField posY;
    Desplazamiento des;
    MovimientoAnimado move;
    Vector3 newPos;
    public void getPos()
    {
        //Debug.Log(posX.text);
        des = GameObject.FindObjectOfType<Desplazamiento>();
        move = GameObject.FindObjectOfType<MovimientoAnimado>();
        int x = int.Parse(posX.text);
        int y = int.Parse(posY.text);
        newPos.x = (float)-4.5 + x;
        newPos.z = y;
        move.MoveTowardsTarget(newPos);
        //des.setTargetPos(newPos);
        // return x;
    }


}
