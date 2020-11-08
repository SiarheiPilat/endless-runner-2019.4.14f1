using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingLevel : MonoBehaviour
{
	public Vector3 mainDirection;
	public float Multiplier;

    void Update()
    {
	    transform.position += mainDirection * Multiplier * Time.deltaTime;
    }
}
