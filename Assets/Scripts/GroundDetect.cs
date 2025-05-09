using UnityEngine;

public class GroundDetect : MonoBehaviour
{
    public bool isGrounded;
    public float distanciaRaycast = 0.1f;
    public LayerMask layerGround;

    private Transform origenRaycast;


    void Start()
    {
        origenRaycast = this.transform;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(origenRaycast.position, Vector2.down, distanciaRaycast, layerGround);
        isGrounded = hit.collider != null;
    }
}
