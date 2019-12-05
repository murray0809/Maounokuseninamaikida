using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_Sheet2 : ScriptableObject
{	
	public List<Sheet> sheets = new List<Sheet> ();

	[System.SerializableAttribute]
	public class Sheet
	{
		public string name = string.Empty;
		public List<Param> list = new List<Param>();
	}

	[System.SerializableAttribute]
	public class Param
	{
		
		public int minSpawnCount;
		public int maxSpawnCount;
		public bool spawnByWall;
		public bool spawmInTheMiddle;
		public bool spawnRotated;
		public float heightFix;
		public string gameObject;
		public int spawnRoom;
	}
}

