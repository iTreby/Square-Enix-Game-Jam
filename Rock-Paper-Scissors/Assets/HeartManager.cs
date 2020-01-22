﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{

    int[] playerHealth = new int[2];

    [SerializeField] int totalHealth;
    [SerializeField] Image[] heartsP1;
    [SerializeField] Image[] heartsP2;

    [SerializeField] TextMeshProUGUI ResultText;

    #region Singleton
    private static HeartManager _instance = null;
    public static HeartManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<HeartManager>();
            }
            return _instance;
        }
    }
    #endregion


    private void Start()
    {
        playerHealth[0] = totalHealth;
        playerHealth[1] = totalHealth;
        
    }

    void TakeDamage(int player)
    {
        //Player 1 Takes Damage
        if (player == 1 && playerHealth[0] > 0)
        {
            heartsP1[playerHealth[0] - 1].enabled = false; //Remove heart at relevant index
            playerHealth[0]--;
            DisplayWin(player);
        }
        else if (player == 1)
        {
            //P1 LOSE LOGIC
            Debug.Log("Player 1 Lost");
        }

        //Player 2 Take damage
        if (player == 2 && playerHealth[1] > 0)
        {
            heartsP2[playerHealth[1] - 1].enabled = false; //Remove heart at relevant index
            playerHealth[1]--;
            DisplayWin(player);
            Debug.Log("Damage second player");
        }
        else if (player == 2)
        {
            //P2 LOSE LOGIC
            Debug.Log("Player 2 Lost");
        }

        else if (player == 3)
        {
            DisplayWin(player);
        }

    }

    public void DisplayWin(int player)
    {
        if(player == 1)
        {
            ResultText.text = "Player 1 wins";
        }
        else if(player == 2)
        {
            ResultText.text = "Player 2 wins";
        }
        else
        {
            ResultText.text = "It's a draw!";
        }

        ResultText.enabled = true;

        //Using timer class set 3~sec timer before text dissapear and next round enabled

    }
}
