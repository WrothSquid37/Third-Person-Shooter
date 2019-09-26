using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPutter : MonoBehaviour {

	public int cols = 10;
	public int rows = 10;

	public int sizeY;
	public int yOffset;

	public Transform prefab;

	public Material blockMaterial;

	public Transform plane;

	void Start()
	{
		for (int x = 0; x < cols; x++)
		{
			for (int y = 0; y < rows; y++)
			{

				int state = (int)Mathf.Round(Random.Range(0,2));

				print(state);

				if (state == 1)
				{

					float tempX = plane.localScale.x / x;
					float tempZ = plane.localScale.z / y;

					Vector3 pos = new Vector3(tempX, yOffset, tempZ);

					Transform tranform = Instantiate(prefab, pos, Quaternion.identity);



				}

			}
		}
	}

}
