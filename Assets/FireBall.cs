using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
  
    private void Update()
    {
        this.transform.position += new Vector3(0, -1, 0) * 25 * Time.deltaTime;
        Destroy(this.gameObject, 0.5f);
    }

   
}

    

