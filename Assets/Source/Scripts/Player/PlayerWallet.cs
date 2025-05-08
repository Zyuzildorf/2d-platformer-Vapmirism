using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _money;
    
    public void TakeCoin(Coin coin)
    {
        _money += coin.CoinValue;
    }
}