using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class InternetManager : NetworkManager
{
    public bool CreateRoom = false;
    public string RoomName = "room1";
    
    public void Start () {

        StartMatchMaker();
        
        if (CreateRoom)
        {
            CreateMatch(RoomName);
        } else
        {
            matchMaker.ListMatches(0, 20, "", OnMatchList);
        }
       
    }

    void CreateMatch(string newMatchName)
    {
        matchName = newMatchName;
        matchMaker.CreateMatch(matchName, 2, true, "", OnMatchCreate);
    }

    void JoinMatch(MatchDesc match)
    {
        matchName = match.name;
        matchSize = (uint)match.currentSize;
        matchMaker.JoinMatch(match.networkId, "", OnMatchJoined);
    }

    public override void OnMatchList(ListMatchResponse matchList)
    {
        base.OnMatchList(matchList);

        // auto join room if found
        foreach (MatchDesc match in matchList.matches)
        {
            if (match.name == RoomName)
            {
                JoinMatch(match);
                return;
            }
        }

    }


}
