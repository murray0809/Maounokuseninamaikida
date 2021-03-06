using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class Dungeon_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/Dungeon.xls";
	private static readonly string exportPath = "Assets/Dungeon.asset";
	private static readonly string[] sheetNames = { "Dungeons", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			Entity_Sheet2 data = (Entity_Sheet2)AssetDatabase.LoadAssetAtPath (exportPath, typeof(Entity_Sheet2));
			if (data == null) {
				data = ScriptableObject.CreateInstance<Entity_Sheet2> ();
				AssetDatabase.CreateAsset ((ScriptableObject)data, exportPath);
				data.hideFlags = HideFlags.NotEditable;
			}
			
			data.sheets.Clear ();
			using (FileStream stream = File.Open (filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
				IWorkbook book = null;
				if (Path.GetExtension (filePath) == ".xls") {
					book = new HSSFWorkbook(stream);
				} else {
					book = new XSSFWorkbook(stream);
				}
				
				foreach(string sheetName in sheetNames) {
					ISheet sheet = book.GetSheet(sheetName);
					if( sheet == null ) {
						Debug.LogError("[QuestData] sheet not found:" + sheetName);
						continue;
					}

					Entity_Sheet2.Sheet s = new Entity_Sheet2.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i<= sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						Entity_Sheet2.Param p = new Entity_Sheet2.Param ();
						
					cell = row.GetCell(0); p.minSpawnCount = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(1); p.maxSpawnCount = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(2); p.spawnByWall = (cell == null ? false : cell.BooleanCellValue);
					cell = row.GetCell(3); p.spawmInTheMiddle = (cell == null ? false : cell.BooleanCellValue);
					cell = row.GetCell(4); p.spawnRotated = (cell == null ? false : cell.BooleanCellValue);
					cell = row.GetCell(5); p.heightFix = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(6); p.gameObject = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(7); p.spawnRoom = (int)(cell == null ? 0 : cell.NumericCellValue);
						s.list.Add (p);
					}
					data.sheets.Add(s);
				}
			}

			ScriptableObject obj = AssetDatabase.LoadAssetAtPath (exportPath, typeof(ScriptableObject)) as ScriptableObject;
			EditorUtility.SetDirty (obj);
		}
	}
}
