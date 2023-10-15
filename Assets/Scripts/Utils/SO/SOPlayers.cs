using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SOPlayers")]
public class SOPlayers : ScriptableObject
{
    public Player Player_01;
    public string Player_01Name;

    public Player Player_02;
    public string Player_02Name;

    public List<Player> PlayerList => new List<Player>() 
    {
        Player_01,
        Player_02
    };

    public Dictionary<string, Player> PlayersDic => new Dictionary<string, Player>
    {
        { Player_01Name, Player_01 },
        { Player_02Name, Player_02 }
    };
}
