using System;
using UnityEngine;

public class ItemsCollector : MonoBehaviour
{
    public event Action<Item> ItemCollected; 
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item item))
        {
            ItemCollected?.Invoke(item);
            item.CallEvent();
        }
    }
}