using UnityEngine;
using System.IO;

public static class FilePath {
	public static readonly string statsContainer = Application.persistentDataPath + "/statsContainer.dat";
	public static readonly string achievementsContainer = Application.persistentDataPath + "/achievementsContainer.dat";
	public static readonly string missionsContainer = Application.persistentDataPath + "/missionsContainer.dat";
	public static readonly string upgradesContainer = Application.persistentDataPath + "/upgradesContainer.dat";
	public static readonly string experienceContainer = Application.persistentDataPath + "/experienceContainer.dat";
}

public static class SaveManager {
	public static void save<ISavable>(ISavable serializable, string filePath) {
		string json = JsonUtility.ToJson(serializable, false);
		Debug.Log(json);
		FileStream file = File.Open(filePath, FileMode.OpenOrCreate);
		BinaryWriter binaryWriter = new BinaryWriter(file);
		binaryWriter.Write(json);
		file.Close();

		try {
			binaryWriter.Dispose();
		}
		catch (System.Exception e) {
			Debug.Log(e.ToString());
			throw e;
		}
	}

	public static ISavable load<ISavable>(string filePath) {
		Debug.Log(filePath + " loaded.");
		FileStream file = File.Open(filePath, FileMode.Open);
		BinaryReader binaryReader = new BinaryReader(file);
		string json = binaryReader.ReadString();
		ISavable deserializedObject = JsonUtility.FromJson<ISavable>(json);
		file.Close();
		try {
			binaryReader.Dispose();
		}
		catch (System.Exception e) {
			Debug.Log(e.ToString());
			throw e;
		}
		return deserializedObject;
	}

	public static bool exists(string filePath) {
		return File.Exists(filePath);
	}
}