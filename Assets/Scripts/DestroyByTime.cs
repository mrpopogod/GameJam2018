using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField]
    private float _lifetime;

    public void Start()
    {
        Destroy(gameObject, _lifetime);
    }
}
