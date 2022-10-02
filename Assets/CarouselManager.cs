using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarouselManager : MonoBehaviour
{
    public List<Image> carouselElements;
    public DatabaseHandler database;  
    public List<GameModel> loadedGameModels;
    public TextMeshProUGUI promptLabel; 


    public class DrawingData{
        public Sprite sprite {get; set;}
        public string prompt {get; set;}
        public DrawingData(Sprite s, string p){
            sprite=s;
            prompt=p;
        }
    }

    public List<DrawingData> loadedDrawings;
    int offSet = 0;

    public void spinLeft(){
        offSet++;
        for(int x=0;x<carouselElements.Count;x++){
            int y = (x+offSet) % loadedGameModels.Count;
            carouselElements[x].sprite = loadedDrawings[y].sprite;
            if(x==1){
                promptLabel.text=loadedDrawings[y].prompt;
            }
        }
    }

    public void spinRight(){
        offSet--;
        for(int x=0;x<carouselElements.Count;x++){
            int y = (x+offSet) % loadedGameModels.Count;
            if(x+offSet<0){
                y=loadedGameModels.Count-x+offSet;
            }
            carouselElements[x].sprite = loadedDrawings[y].sprite;
            if(x==1){
                promptLabel.text=loadedDrawings[y].prompt;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        loadedGameModels = database.QueryDrawingsFromDB();
        LoadAllSprites();

        //Initialize
        for(int x=0;x<carouselElements.Count;x++){
            carouselElements[x].sprite = loadedDrawings[x].sprite;
            if(x==1){
                promptLabel.text=loadedDrawings[x].prompt;
            }
        }
    }

    void LoadAllSprites(){
        loadedDrawings = new List<DrawingData>();
        for(int x=0;x<loadedGameModels.Count;x++){
            
            Texture2D texture = new Texture2D(256,256);
            texture.LoadImage(loadedGameModels[x].imageData);
            DrawingData drawing = new DrawingData(Sprite.Create(texture,new Rect(0, 0, texture.width, texture.height),Vector2.zero,28,0,SpriteMeshType.FullRect,Vector4.zero,false),loadedGameModels[x].prompt);
            loadedDrawings.Add(drawing);
        }
    }


}
