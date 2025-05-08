using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnpoints;
    
    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        Coin newCoin;
        
        for (int i = 0; i < _spawnpoints.Length; i++)
        {
            newCoin = Instantiate(_coinPrefab, _spawnpoints[i].position, Quaternion.identity);

            newCoin.Collected += DestroyCoin;
        }        
    }

    private void DestroyCoin(Item coin)
    {
        Destroy(coin.gameObject);
        
        coin.Collected -= DestroyCoin;
    }
}