using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    RecEventHandler recHandler = new RecEventHandler();
    void Start()
    {
        Debug.Log("init game manager");
    } 

    // Update is called once per frame
    void Update()
    {
      //executa comandos vindos da rede
      while(ListCommands.messagesReceived.Count != 0){
        string msg = ListCommands.messagesReceived[0];
        recHandler.handleMsg(msg);
        ListCommands.popRec();
      }
    }

}
