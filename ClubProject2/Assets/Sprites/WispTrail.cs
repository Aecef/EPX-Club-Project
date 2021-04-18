using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispTrail : MonoBehaviour
{
    public Color trailColor = new Color(1, 0, 0.38f);
    public float distanceFromCamera = 5;
    public float startWidth = 0.1f;
    public float endWidth = 0f;
    public float trailTime = 0.24f;

    Transform trailTransform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject trailObj = new GameObject("Mouse Trail");
        trailTransform = trailObj.transform;
        TrailRenderer trail = trailObj.AddComponent<TrailRenderer>();
        trail.time = -1f;
        MoveTrailToWisp();
        trail.time = trailTime;
        trail.startWidth = startWidth;
        trail.endWidth = endWidth;
        trail.numCapVertices = 2;
        trail.sharedMaterial = new Material(Shader.Find("Unlit/Color"));
        trail.sharedMaterial.color = trailColor;
        trail.sortingLayerName = "Foreground";
        trail.sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTrailToWisp();
    }

    void MoveTrailToWisp()
    {
        trailTransform.position = transform.position;
    }
}
