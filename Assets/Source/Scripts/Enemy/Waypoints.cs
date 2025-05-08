using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private Transform[] _waypointsArray;

    public int GetArrayLength => _waypointsArray.Length;

    public Transform GetArrayElementByIndex(int index)
    {
        return _waypointsArray[index];
    }
    
    [ContextMenu("GetWaypoints")]
    private void GetWaypoints()
    {
        _waypointsArray = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _waypointsArray[i] = transform.GetChild(i);
        }
    }
}