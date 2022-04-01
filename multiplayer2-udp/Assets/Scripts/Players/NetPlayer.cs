using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetPlayer : MonoBehaviour
{
    Vector2 speed = new Vector2(20,20);
    public int movingX = 0, movingY =0;
    public float inputX = 0, inputY =0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(movingX != 0 || movingY != 0){
        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY,0);
        movement*= Time.deltaTime;
        transform.Translate(movement);
      } 
    }
}
