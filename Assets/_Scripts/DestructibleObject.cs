using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
	public static Queue<GameObject> disabledObjects = new ();
    // Start is called before the first frame update
    public static void ReenableObjects()
	{
		while (disabledObjects.Count > 0)
		{
			GameObject obj = disabledObjects.Dequeue();
			
			if (obj != null)
			{
				obj.SetActive(true);
			}
		}
	}
}
