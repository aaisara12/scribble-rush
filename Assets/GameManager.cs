using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public StringChannelSender promptSender;
    public string currentPrompt;
    public PromptManager promptManager;
    public VoidChannelSender transitionSender;
    public IntChannelSender timerChannel;
    public DrawController drawController;
    public DatabaseHandler database;    

    //Timer things
    public float timer=10;
    public int promptsLeft=3;
    public bool started=false;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame(){
        started=true;
        currentPrompt=promptManager.noun();
        promptSender.SendValue(currentPrompt);
        promptsLeft=3;
        timer=10;
    }

    // Update is called once per frame
    void Update()
    {
        //Only update the timer when we still have prompts
        if(promptsLeft>0 && started){
            timer -=Time.deltaTime;
            if(timer<=0)
                TimerExpired(); 
            timerChannel.SendValue((int)timer);
        }

    }

    void TimerExpired(){
        promptsLeft--;
        if(promptsLeft==0){
            //Move to the final bit, send the drawing
            drawController.canDraw=false;
            GameModel justCompleted = new GameModel("",currentPrompt,drawController.texture2D.EncodeToJPG());

            //transition to the final
            database.SaveDrawingToDB(justCompleted);
            transitionSender.SendValue();
        }
        else{
            //reset the timer
            timer=10f;
            currentPrompt=promptManager.addAdjective(currentPrompt);
            promptSender.SendValue(currentPrompt);
        }
    }
}
