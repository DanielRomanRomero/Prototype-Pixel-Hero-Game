using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{ 
    private int _heartsPending = 5, _coinsSpinPending = 6, _coinsShinePending = 10;

    public int HeartsPending { get => _heartsPending; set => _heartsPending = value; }
    public int CoinsSpinPending { get => _coinsSpinPending; set => _coinsSpinPending = value; }
    public int CoinsShinePending { get => _coinsShinePending; set => _coinsShinePending = value; }

    private void OnGUI()
    {
        GUILayout.Label("Pending Pick Hearts: "+HeartsPending);
        GUILayout.Label("Pending Coins Spin: " + CoinsSpinPending);
        GUILayout.Label("Pending Coins Shine: " + CoinsShinePending);
    }
}
