using UnityEngine;

public class PlayerSearcher : MonoBehaviour
{
    public Player FindedPlayer { get; private set; }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Player player))
        {
            FindedPlayer = player;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent(out Player player))
        {
            FindedPlayer = null;
        }
    }
}