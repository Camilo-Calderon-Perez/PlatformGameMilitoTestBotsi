using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float followSpeed;

    [SerializeField]
    public float yOffset;

    [SerializeField]
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10 );
        transform.position = Vector3.Slerp(transform.position,newPos, followSpeed * Time.deltaTime);
    }
}
