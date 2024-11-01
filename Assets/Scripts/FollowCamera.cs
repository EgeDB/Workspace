using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Vector3 player;
    [SerializeField] private Transform cameraPosition;


 
    private void Update()
    {
        transform.position = cameraPosition.position + player;
    }
}
