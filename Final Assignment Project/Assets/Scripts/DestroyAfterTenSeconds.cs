using UnityEngine;

public class DestroyAfterTenSeconds : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 10f);
    }
}
