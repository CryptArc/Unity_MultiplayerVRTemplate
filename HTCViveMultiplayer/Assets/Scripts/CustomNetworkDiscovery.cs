using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CustomNetworkDiscovery : NetworkDiscovery {

    public delegate void BroadcastEvent(string fromAddress, string data);

    public event BroadcastEvent OnReceivedNetworkBroadcast = delegate { };

    override public void OnReceivedBroadcast(string fromAddress, string data)
    {
        OnReceivedNetworkBroadcast(fromAddress, data);
    }

}
