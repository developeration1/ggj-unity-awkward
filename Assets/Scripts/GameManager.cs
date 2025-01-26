using System.Collections.Generic;
using AT7.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    private List<PlayerInput> players = new();

    public int PlayerCount => players.Count;

    public void AddPlayer(PlayerInput player)
    {
        players.Add(player);
    }

    public void ClearPlayers()
    {
        foreach (PlayerInput player in players)
        {
            Destroy(player.gameObject);
        }

        players.Clear();
    }

    
}
