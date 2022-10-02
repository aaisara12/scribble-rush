using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using Realms.Sync;

public class GameModel : RealmObject
{
    [PrimaryKey]
    [MapTo("_id")]
    public string gamerTag {get; set;}

    [MapTo("_prompt")]
    public string prompt {get;set;}

    [MapTo("_image_data")]
    public byte[] imageData {get;set;}

    [Required]
    [MapTo("game")]
    public string game {get;set;}

    public GameModel(){}

    public GameModel(string gamerTag, string prompt, byte[] imageData){
        this.gamerTag=System.Guid.NewGuid().ToString();
        this.prompt=prompt;
        this.imageData=imageData;
        game="game";
    }
}
