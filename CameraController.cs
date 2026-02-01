using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;

    public Transform clampMin, clampMax;

    public Camera cam;
    private float halfwidth, halfheight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = FindAnyObjectByType<PlayerController>().transform;

        clampMin.SetParent(null);
        clampMax.SetParent(null);

        cam = GetComponent<Camera>();
        halfheight = cam.orthographicSize;
        halfwidth = cam.orthographicSize * cam.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, clampMin.position.x + halfwidth,clampMax.position.x - halfwidth);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, clampMin.position.y + halfheight, clampMax.position.y - halfheight);

        transform.position = clampedPosition;

    }
}
