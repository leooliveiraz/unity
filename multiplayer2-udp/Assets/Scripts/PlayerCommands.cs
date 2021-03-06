using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 speed = new Vector2(50,50);
    float lastX , lastY;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      float inputX = Input.GetAxis("Horizontal");
      float inputY = Input.GetAxis("Vertical");

      if(inputX != 0 || inputY != 0){
        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY,0);
        movement*= Time.deltaTime;
        transform.Translate(movement);

        ListCommands.addSend("moving;"+this.transform.position.x.ToString()+";"+this.transform.position.y.ToString());
      }
      
    }
}
