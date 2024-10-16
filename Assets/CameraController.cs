using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float distance;
    [SerializeField]
    private float rotation;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + (Quaternion.Euler(rotation, player.eulerAngles.y, 0)) * Vector3.forward * -distance, 10f * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation((player.position + player.up * 1) - transform.position), 10f * Time.deltaTime);
    }
}
