using UnityEngine;
using System.Collections;

public class BoardGenerator : MonoBehaviour 
{
	public GameObject tile;
	public int sizeX;
	public int sizeZ;
	public float spacing;
	public bool isBlack;

	// Use this for initialization
	void Start () 
	{
		//createGrid();
		StartCoroutine(createGrid());
	}
	
	public IEnumerator createGrid()
	{
		for(int z = 0; z < sizeZ; z++)
		{
			print (z);
		
			for (int x = 0; x < sizeX; x++)
			{
				yield return new WaitForSeconds(0.02f);
			
				if(x%2 == 0) 
				{
					if(z%2 == 0) 
					{
						isBlack = true;
					}
					else 
					{
						isBlack = false;
					}
				} 
				else 
				{
					if(z%2 == 0) 
					{
						isBlack = false;
					} 
					else 
					{
						isBlack = true;
					}
				}
				
				float zWorld = z * spacing - spacing * sizeZ/2 + transform.position.z;
				float xWorld = x * spacing - spacing * sizeX/2 + transform.position.x;
				float yWorld = 0f;
				
				Vector3 worldPos = new Vector3(xWorld,yWorld,zWorld);
				
				string cellName = (x + " " + z).ToString();
				
				spawnTile(worldPos, isBlack, cellName);
			}
		}
	}
	
	public void spawnTile(Vector3 worldPosition, bool isBlack, string cellName)
	{
		GameObject temp = Instantiate(tile,worldPosition,Quaternion.identity) as GameObject;
		temp.name = cellName;
		
		if(isBlack == true)
		{
			temp.GetComponent<MeshRenderer>().material.color = Color.black;
		}
		
		temp.transform.parent = transform;
	}	
}
