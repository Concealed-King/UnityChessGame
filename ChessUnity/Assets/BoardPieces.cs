using UnityEngine;
using System.Collections;

[System.Serializable]
public struct pieceStats
{
	public int maxMove;
	public int value;
	public PIECE_TYPE type;
}

public enum PIECE_TYPE
{
	PAWN,
	KNIGHT,
	BISHOP,
	ROOK,
	QUEEN,
	KING,
	END_OF_ENUM
}

public class BoardPieces : MonoBehaviour 
{
	public pieceStats piece;
	public PIECE_TYPE startType;
	private int curCellX;
	private int curCellZ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		selectDestination();
	}
	
	private void getCell()
	{
		if(startType == PIECE_TYPE.PAWN)
		{
			Vector3 rayDown = transform.TransformDirection(Vector3.down);
			RaycastHit hitInfo;
		
			if(Physics.Raycast(transform.position, rayDown, out hitInfo))
			{
				cellToPosition(hitInfo.collider.gameObject, false);
			}
		}
	}
	
	private void cellToPosition(GameObject currentPos,bool isDestionation)
	{
		string[] coordinates = currentPos.name.Split(' ');
		if(isDestionation == true)
		{
			int destCellX = int.Parse(coordinates[0]);
			int destCellZ = int.Parse(coordinates[1]);
			
			movePieces(curCellX,curCellZ,destCellX,destCellZ,currentPos);
			
		}
		else
		{
			curCellX = int.Parse(coordinates[0]);
			curCellZ = int.Parse(coordinates[1]);
			print("X: " + curCellX + "| Z: " + curCellZ);
		}
	}
	
	private void selectDestination()
	{
		getCell();
	
		if(Input.GetMouseButton(0))
		{
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray, out hitInfo,100f))
			{
				cellToPosition(hitInfo.collider.gameObject, true);
			}
		}
	}
	
	private void movePieces(int currentX,int currentZ,int destinX,int destinZ, GameObject destination)
	{
		switch(startType)
		{
			case PIECE_TYPE.PAWN:
				if(destinZ < currentZ + piece.maxMove && destinX == currentX && destinZ > currentZ)
				{
					print("PAWN: MOVED");
					this.gameObject.transform.position = new Vector3(destination.transform.position.x,0.52f,destination.transform.position.z);
					
				}
				else
				{
					print ("PAWN: INVALID MOVE");
				}
				break;
			
			case PIECE_TYPE.KNIGHT:
			
				break;
			
			case PIECE_TYPE.BISHOP:
			
				break;
			
			case PIECE_TYPE.ROOK:
				if(destinZ < destinZ + piece.maxMove || destinZ > destinZ + piece.maxMove)
				{
					this.gameObject.transform.position = new Vector3(destination.transform.position.x,0.52f,this.transform.position.z);
	
				}
				if(destinX < destinX + piece.maxMove || destinX > destinX + piece.maxMove)
				{
					this.gameObject.transform.position = new Vector3(this.transform.position.x,0.52f,destination.transform.position.z);
				}
				
				
				break;
			
			case PIECE_TYPE.QUEEN:
			
				break;
			
			case PIECE_TYPE.KING:

				break;	
		}
	}
}
