using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCommands
{
    public static List<string> messagesReceived = new List<string>();
    public static List<string> messagesSend = new List<string>();
    
    public static void addRec(string msg){
      messagesReceived.Add(msg);
    }

    public static void popRec(){
      messagesReceived.RemoveAt(0);
    }
    public static void addSend(string msg){
      messagesSend.Add(msg);
    }

    public static void popSend(){
      messagesSend.RemoveAt(0);
    }


    // Start is called before the first frame update
    
}
