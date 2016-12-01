using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadSave : MonoBehaviour {
    public static LoadSave ldsv;

    private Scene gameScene;
    // Use this for initialization
    void Start() {
        gameScene = gameObject.GetComponent<Scene>();
    }

    // Update is called once per frame
    void Update() {
    }

    public void LoadData() {
        if (File.Exists(Application.persistentDataPath + "/save.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open, FileAccess.Read);
            GameData data = (GameData)bf.Deserialize(fs);
            fs.Close();

            gameScene.setScore(data.score);

            Vector3 playerPos = new Vector3(data.playerX, data.playerY, data.playerZ);
            gameScene.Player.transform.position = playerPos;
            gameScene.Player.transform.rotation = Quaternion.Euler(0, data.playerRotationY, 0);

            Vector3 monsterPos = new Vector3(data.monsterX, data.monsterY, data.monsterZ);
            gameScene.Monster.transform.position = monsterPos;
            gameScene.Monster.transform.rotation = Quaternion.Euler(0, data.monsterRotationY, 0);

        }
    }

    public void SaveData() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate);
        GameData data = new GameData();
        data.score = gameScene.score;

        Vector3 playerPos = gameScene.Player.transform.position;
        data.playerX = playerPos.x;
        data.playerY = playerPos.y;
        data.playerZ = playerPos.z;
        data.playerRotationY = gameScene.Player.transform.rotation.eulerAngles.y;

        Vector3 monsterPos = gameScene.Monster.transform.position;
        data.monsterX = monsterPos.x;
        data.monsterY = monsterPos.y;
        data.monsterZ = monsterPos.z;
        data.monsterRotationY = gameScene.Monster.transform.rotation.eulerAngles.y;

        bf.Serialize(fs, data);
        fs.Close();
    }

}

[Serializable]
class GameData {

    /**Player's score*/
    public int score;

    /**player XYZ coordinates*/
    public float playerX, playerY, playerZ;

    /**Monster's XYZ coordinates*/
    public float monsterX, monsterY, monsterZ;

    /**monster's rotation around the z axis*/
    public float monsterRotationY;

    /**player's rotation around the z axis*/
    public float playerRotationY;
};
