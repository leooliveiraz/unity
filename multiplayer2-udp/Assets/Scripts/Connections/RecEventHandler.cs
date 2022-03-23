using UnityEngine;
using System.Collections;
public class RecEventHandler : MonoBehaviour {
  
  private static GameManager manager;

  public void handleMsg(string msg){
    string[] commands = commandExploder(msg);
    Debug.Log("handling:"+ msg);
    switch(commands[0]){
      case "newId":
        SessionStorage.id = int.Parse(commands[1]);
        break;
      case "newPlayer":
        int playerId = int.Parse(commands[1]);
        string playerName = commands[2];
        float playerX = float.Parse(commands[3].Replace('.',','));
        float playerY = float.Parse(commands[4].Replace('.',','));
        
        if (playerId != SessionStorage.id || !SessionStorage.created ){
          if(playerId == SessionStorage.id)
            SessionStorage.created = true;
          GameObject player = Resources.Load(playerId == SessionStorage.id ? "Prefabs/LocalPlayer" : "Prefabs/NetworkPlayer") as GameObject;
          player.name = "net"+playerId;
          Instantiate(player ,new Vector3(playerX, playerY,0), Quaternion.identity);
        }

        break;
        
      case "playerMoved":
        int playerMovedId = int.Parse(commands[1]);
        if(playerMovedId != SessionStorage.id){
          float playerMovedX = float.Parse(commands[2].Replace('.',','));
          float playerMovedY = float.Parse(commands[3].Replace('.',','));
          Debug.Log("x:"+playerMovedX+ "----y:"+playerMovedY);
          GameObject playerMoved = GameObject.Find("net"+commands[1]+"(Clone)");
          Vector3 movement = new Vector3(playerMovedX, playerMovedY, 0);
          playerMoved.transform.position = movement;
          Debug.Log("x1:"+playerMoved.transform.position.x+ "----y1:"+playerMoved.transform.position.y);
        }
        break;

    }
  }
  static string[] commandExploder(string msg){
    string[] commands = msg.Split(';');
    return commands;
  }
}