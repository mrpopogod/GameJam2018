using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField]
    private float _lifetime;

    void Start()
    {
        Destroy(gameObject, _lifetime);
    }
}
