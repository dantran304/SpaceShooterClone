﻿using UnityEngine;
using System.Collections;

public class BackgroundScroller2 : MonoBehaviour {
    public float scrollSpeed;
    private Vector2 savedOffset;
    Renderer renderer1;
	// Use this for initialization
	void Start () {
        renderer1 = GetComponent<Renderer>();
        savedOffset = renderer1.sharedMaterial.GetTextureOffset("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(savedOffset.x, y);
        renderer1.sharedMaterial.SetTextureOffset("_MainTex", offset);
	}

    void OnDisable()
    {
        renderer1.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
