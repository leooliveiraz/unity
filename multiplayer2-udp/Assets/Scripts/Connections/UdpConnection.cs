using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

using System.Threading;

using UnityEngine;

public class UdpConnection : MonoBehaviour
{
  UdpClient client;
  string hostIp = "localhost";
  int hostPort = 1234;
  
  private Thread threadReceive;
  private Thread threadSend;
  void Start()
  {
    client = new UdpClient();
    try
    {
      client.Connect(hostIp,hostPort);
      threadReceive = new Thread(receiveMsg);
      threadReceive.Start();
      sendMsg("connecting");
    }
    catch (Exception e)
    {
      Debug.Log(e.Message);
    }
  }

  void sendMsg(string msg){
    byte [] sendBytes = Encoding.UTF8.GetBytes(msg);
    client.Send(sendBytes, sendBytes.Length);
  }
  void receiveMsg(){
    while(true){
      IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any,0);
      byte[] receivedBytes = client.Receive(ref remoteEndPoint);
      string msg = Encoding.UTF8.GetString(receivedBytes);
      ListCommands.addRec(msg);
    }
  }
  
  void Update()
  {
    while(ListCommands.messagesSend.Count > 0){
      String msg = ListCommands.messagesSend[0];
      sendMsg(msg);
      ListCommands.popSend();
    }
  }
}
