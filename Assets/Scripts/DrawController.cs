using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DrawController : MonoBehaviour
{
    
    public Image image;
    public Texture2D texture2D;


    [Header("Brush Settings")]
    public int brushSize;
    public Color brushColor;


    void DrawToTexture(Vector2 pixelLocation){
        for(int x=0;x<brushSize;x++){
            for(int y=0;y<brushSize;y++){
                if(x<texture2D.width && y<texture2D.width){
                    texture2D.SetPixel((int)pixelLocation.x+x,(int)pixelLocation.y+y,brushColor);
                }
            }
        }
        texture2D.Apply();
    }

    void Start(){
        image=GetComponent<Image>();
    }


    void Update()
    {

        if(Input.GetMouseButton(0)){
            Vector2 localPoint = Input.mousePosition;

            //Figure out whether we are in the rectangle, and where we are in it 
            RectTransformUtility.ScreenPointToLocalPointInRectangle(image.rectTransform,Input.mousePosition,null,out Vector2 localPointInRectangle);
            if(!RectTransformUtility.RectangleContainsScreenPoint(image.rectTransform,localPoint))
                return;


            //Adjust the position, since currently (0,0) is the center of the image and Unity uses (0,0) as the bottom left
            localPointInRectangle.y += image.rectTransform.rect.height/2;
            localPointInRectangle.x += image.rectTransform.rect.width/2;



            //Scale it into a 256x256 texture
            float scalingFactor = (texture2D.width/image.rectTransform.rect.width);
            localPointInRectangle *= scalingFactor;

            DrawToTexture(localPointInRectangle);
            texture2D.Apply();


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

    }

    

}
