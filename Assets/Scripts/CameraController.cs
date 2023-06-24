using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public GameObject player;
    // x, y 제한 범위
    float minX, maxX, minY, maxY;
    private void Start()
    {
        // Stpe 1. 이동 제한 범위 설정
        minY = -Camera.main.orthographicSize;
        maxY = Camera.main.orthographicSize;
        minX = -Camera.main.orthographicSize * Camera.main.aspect;
        maxX = Camera.main.orthographicSize * Camera.main.aspect;
    }
    private void Update()
    {
            Vector3 cameraToPlayerDiff = player.transform.position - this.transform.position;
            Vector3 cameraPos= new Vector3(cameraToPlayerDiff.x * cameraSpeed * Time.deltaTime, cameraToPlayerDiff.y * cameraSpeed * Time.deltaTime, 0.0f);
            this.transform.Translate(cameraPos);
    }

    void LateUpdate()
    {
        // Step 3. 이동 제한
        //LimitToMove();
    }


    // ★ Step 2. 이동 제한 메서드
    void LimitToMove()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                         Mathf.Clamp(transform.position.y, minY, maxY));
    }
}