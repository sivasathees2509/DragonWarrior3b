using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class BackgroundTile : MonoBehaviour
{
    private const int LookAheadOffset = 2;
    public bool HasRightCopy = false;
    public bool HasLeftCopy = false;

    private float CamwidthX;
    private float SpriteWidthX;


    Transform CopiedTo;
    Transform CopiedFrom;
    void Start()
    {
        //HasRightCopy = HasLeftCopy = false;
        SpriteWidthX = GetComponent<SpriteRenderer>().bounds.size.x;
        CamwidthX = Camera.main.orthographicSize * Camera.main.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        float spriteRightEdge = transform.position.x + SpriteWidthX / 2;
        float spriteLeftEdge = transform.position.x - SpriteWidthX / 2;

        float camRightEdge = Camera.main.transform.position.x + CamwidthX;
        float camLeftEdge = Camera.main.transform.position.x - CamwidthX;

        if(camRightEdge + LookAheadOffset > spriteRightEdge)
        {
            if (!HasRightCopy)
            {
                Makecopy(CopyTo.right);
            }
        }

        if(camLeftEdge - LookAheadOffset < spriteLeftEdge)
        {
            if (!HasLeftCopy)
            {
                Makecopy(CopyTo.left);
            }
        }
        DestroyIfInvisible(camRightEdge, camLeftEdge, spriteRightEdge, spriteLeftEdge);
            
    }

    private void Makecopy(CopyTo side)
    {
        Vector3 copyPosition = new Vector3(transform.position.x + SpriteWidthX * (int)side, transform.position.y, transform.position.z);
        CopiedTo = (Transform)Instantiate(transform, copyPosition, transform.rotation);
        CopiedTo.GetComponent<BackgroundTile>().CopiedFrom = this.transform;
        CopiedTo.parent = this.transform.parent;

        if(side == CopyTo.right)
        {
            this.HasRightCopy = CopiedTo.GetComponent<BackgroundTile>().HasLeftCopy = true; 
        }
        else if(side == CopyTo.left)
        {
            this.HasLeftCopy = CopiedTo.GetComponent<BackgroundTile>().HasRightCopy = true;
        }
    }

    private void DestroyIfInvisible(float camRightedge, float camLeftEdge, float spriteRightEdge, float spriteLefttEdge)
    {
        bool isSpriteInvisibleToRightOfCamera = (spriteLefttEdge - camRightedge > SpriteWidthX);
        bool isSpriteInvisibleToLeftOfCamera = (camLeftEdge - spriteRightEdge > SpriteWidthX);

        if(isSpriteInvisibleToRightOfCamera)
        {
            if(CopiedFrom != null)
            {
                CopiedFrom.GetComponent<BackgroundTile>().HasRightCopy = false;
            }
            if(CopiedTo != null)
            {
                CopiedFrom.GetComponent<BackgroundTile>().HasRightCopy = false;
            }
            GameObject.Destroy(gameObject);
        }
        else if (isSpriteInvisibleToLeftOfCamera)
        {
            if (CopiedFrom != null)
            {
                CopiedFrom.GetComponent<BackgroundTile>().HasLeftCopy = false;
            }
            if (CopiedTo != null)
            {
                CopiedFrom.GetComponent<BackgroundTile>().HasLeftCopy = false;
            }
            GameObject.Destroy(gameObject);
        }
        
    }

    private enum CopyTo
    {
        right = 1,
        left = -1
    }
}
