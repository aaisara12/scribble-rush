using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DrawController : MonoBehaviour
{


    public Image image;
    public Texture2D texture2D;
    public bool canDraw=true;

    [Header("Brush Settings")]
    public int brushSize;
    public Color brushColor;

    public List<Vector2> pixelLocations;


    void DrawToTexture(Vector2 pixelLocation){
        for(int x=0;x<brushSize;x++){
            for(int y=0;y<brushSize;y++){
                if(x<texture2D.width && y<texture2D.width){
                    texture2D.SetPixel(Mathf.RoundToInt(pixelLocation.x+x),Mathf.RoundToInt(pixelLocation.y+y),brushColor);
                }
            }
        }


        texture2D.Apply();
    }

    void InterpolateLastPoint(){
        //interpolate between the last two points that were drawn
        if(pixelLocations.Count>2){
            Debug.LogWarning("Interpolation!");
            Vector2 lastPoint = pixelLocations[pixelLocations.Count-1];
            Vector2 secondToLastPoint = pixelLocations[pixelLocations.Count-2];
            //10 interpolations per two dots
            for(float t=0;t<1;t+=0.1f){
                DrawToTexture(Vector2.Lerp(secondToLastPoint,lastPoint,t));
            }
        }

    }
    void Start(){
        image=GetComponent<Image>();
        pixelLocations = new List<Vector2>();

    }


    void Update()
    {

        if(Input.GetMouseButton(0) && canDraw){
            Vector2 localPoint = Input.mousePosition;

            //Figure out whether we are in the rectangle, and where we are in it 
            RectTransformUtility.ScreenPointToLocalPointInRectangle(image.rectTransform,Input.mousePosition,null,out Vector2 localPointInRectangle);
            if(!RectTransformUtility.RectangleContainsScreenPoint(image.rectTransform,localPoint))
                return;


            //Adjust the position, since currently (0,0) is the center of the image and Unity uses (0,0) as the bottom left
            localPointInRectangle.y += image.rectTransform.rect.height/2;
            localPointInRectangle.x += image.rectTransform.rect.width/2;


            Debug.Log(texture2D.width);
            //Scale it into a 256x256 texture
            float scalingFactor = (texture2D.width/image.rectTransform.rect.width);
            localPointInRectangle *= scalingFactor;

            Debug.Log(localPointInRectangle);

            DrawToTexture(localPointInRectangle);
            pixelLocations.Add(localPointInRectangle);
            InterpolateLastPoint();

            texture2D.Apply();
        }


        if(Input.GetMouseButtonUp(0)){
            pixelLocations.Clear();
        }

  
    }

    public void SetBrushColor(Color c){
        brushColor=c;
    }
    private void OnDestroy() {
        ClearTexture();
    }
    
    void ClearTexture(){
        for(int x=0;x<texture2D.width;x++)
            for(int y=0;y<texture2D.height;y++)
                texture2D.SetPixel(x,y,Color.white);
        texture2D.Apply();
        pixelLocations.Clear();

    }

    

}
