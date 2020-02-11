using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Tilemap tileMap;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;
    private float halfHeight;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        bottomLeftLimit = tileMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = tileMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);

        PlayerMovement.instance.SetBounds(tileMap.localBounds.min, tileMap.localBounds.max);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);

        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(this.transform.position.y, bottomLeftLimit.y, topRightLimit.y), this.transform.position.z);
    }
}
