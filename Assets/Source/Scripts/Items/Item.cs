using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public event Action<Item> Collected;
    
    public void CallEvent()
    {
        Collected?.Invoke(this);
    }
}