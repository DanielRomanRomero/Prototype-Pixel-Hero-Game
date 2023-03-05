using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    private int _pickHeartAmount,_coinSpinAmount,_coinShineAmount;

    public int PickHeartAmount { get => _pickHeartAmount; set => _pickHeartAmount = value; }
    public int CoinSpinAmount { get => _coinSpinAmount; set => _coinSpinAmount = value; }
    public int CoinShineAmount { get => _coinShineAmount; set => _coinShineAmount = value; }

    private PlayerExtrasTracker playerExtrasTracker;

    private void Start()
    {
        playerExtrasTracker = GameObject.Find("Player").GetComponent<PlayerExtrasTracker>();
    }

    public void ManagingAmounts()
    {
        if (PickHeartAmount >= 5)
        {
            playerExtrasTracker.CanDoubleJump = true;
        }

        if (CoinSpinAmount >= 6)
        {
            playerExtrasTracker.CanDash = true;
        }

        if (CoinShineAmount >= 10)
        {
            playerExtrasTracker.CanEnterBallMode = true;
            playerExtrasTracker.CanDropBombs = true;
        }
    }
}
