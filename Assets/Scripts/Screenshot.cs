using UnityEngine;
using System.IO;

public class Screenshot : MonoBehaviour
{
    public KeyCode screenshotKey;

    private void Update() {
        if(Input.GetKeyDown(screenshotKey))
            TakeScreenshot();
    }
    public void TakeScreenshot()
    {
        //If we don't have a screenshot directory, create one
        if(!Directory.Exists("./Screenshots/"))
            Directory.CreateDirectory("./Screenshots/");

        //Take the screenshot
        ScreenCapture.CaptureScreenshot("./Screenshots/" + System.Guid.NewGuid().ToString() + ".png", 1);

    }
}