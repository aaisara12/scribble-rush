using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridManager : MonoBehaviour
{
    public DatabaseHandler database;  
    private List<GameModel> loadedGameModels;
    private int gameModelCount = 0;

    [Header ("Frame Information")]
    public int frameCount = 100;
    public GameObject[] framePrefabs;
    public Transform gridTransform;


    private List<FrameManager> frameManagers;


    public class DrawingData{
        public Sprite sprite {get; set;}
        public string prompt {get; set;}
        public DrawingData(Sprite s, string p){
            sprite=s;
            prompt=p;
        }
    }

    public List<DrawingData> loadedDrawings;



    void InitFrames(){
        frameManagers = new List<FrameManager>();
        for(int x=0;x<frameCount;x++){
            GameObject randomFrameTemplate = framePrefabs[Random.Range(0,framePrefabs.Length)];
            FrameManager newFrame = Instantiate(randomFrameTemplate,this.transform.position,Quaternion.identity,gridTransform).GetComponent<FrameManager>();
            newFrame.setDrawing(loadedDrawings[gameModelCount-1-x].sprite,loadedDrawings[gameModelCount-1-x].prompt);
            frameManagers.Add(newFrame);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        loadedGameModels = database.QueryDrawingsFromDB();

        //If I wanted to I could do these two on different threads.....
        LoadAllSprites();
        InitFrames();

    }

    void LoadAllSprites(){
        loadedDrawings = new List<DrawingData>();
        gameModelCount = loadedGameModels.Count;
        for(int x=0;x<gameModelCount;x++){
            
            Texture2D texture = new Texture2D(256,256);
            texture.LoadImage(loadedGameModels[x].imageData);
            DrawingData drawing = new DrawingData(Sprite.Create(texture,new Rect(0, 0, texture.width, texture.height),Vector2.zero,28,0,SpriteMeshType.FullRect,Vector4.zero,false),loadedGameModels[x].prompt);
            loadedDrawings.Add(drawing);
        }
    }


}
