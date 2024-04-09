
using UnityEngine;

public class RotatingBlock : MonoBehaviour
{
    [SerializeField] int Speed;
    void Update()
    {
        transform.Rotate(0, 0, 1 * Speed * Time.deltaTime);
    }
}
