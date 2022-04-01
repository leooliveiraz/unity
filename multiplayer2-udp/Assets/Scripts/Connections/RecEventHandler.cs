using UnityEngine;
using System.Collections;
public class RecEventHandler : MonoBehaviour {
  
  private static GameManager manager;

  public void handleMsg(string msg){
    string[] commands = commandExploder(msg);
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
        playerMoved(commands);
        break;
        
      case "playerMovingX":
        playerMovingX(commands);
        break;
        
      case "playerMovingY":
        playerMovingY(commands);
        break;
        
        
      case "playerDisconnected":
        playerDisconnected(commands);
        break;

    }
  }
  static string[] commandExploder(string msg){
    string[] commands = msg.Split(';');
    return commands;
  }
  void playerMoved(string[] commands){
    int playerMovedId = int.Parse(commands[1]);
    if(playerMovedId != SessionStorage.id){
      float playerMovedX = float.Parse(commands[2].Replace('.',','));
      float playerMovedY = float.Parse(commands[3].Replace('.',','));
      GameObject playerMoved = GameObject.Find("net"+commands[1]+"(Clone)");
      NetPlayer player = playerMoved.GetComponent<NetPlayer>();
      Vector3 movement = new Vector3(playerMovedX, playerMovedY, 0);
      playerMoved.transform.position = movement;
    }
  }
  void playerMovingX(string[] commands){
    int playerID = int.Parse(commands[1]);
    if(playerID != SessionStorage.id){
      int movedX = int.Parse(commands[2]);
      GameObject playerObj = GameObject.Find("net"+commands[1]+"(Clone)");
      NetPlayer player = playerObj.GetComponent<NetPlayer>();
      player.movingX = movedX;
    }
  }
  
  void playerMovingY(string[] commands){
    int playerID = int.Parse(commands[1]);
    if(playerID != SessionStorage.id){
      int movedY = int.Parse(commands[2]);
      GameObject playerObj = GameObject.Find("net"+commands[1]+"(Clone)");
      NetPlayer player = playerObj.GetComponent<NetPlayer>();
      player.movingY = movedY;
    }
  }

  void playerDisconnected(string[] commands){
    Debug.Log("doing nothing");
  }
}