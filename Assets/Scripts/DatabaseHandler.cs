using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using Realms.Sync;

public class DatabaseHandler : MonoBehaviour
{
    private Realm _realm;
    public GameModel _GameModel;

    const string REALM_APP_ID = "application-1-lerob";


    
    private async void OnEnable() {

        var realmApp = App.Create(new AppConfiguration(REALM_APP_ID));

        var _realmUser = realmApp.CurrentUser;

        if(_realmUser == null){
            _realmUser = await realmApp.LogInAsync(Credentials.Anonymous(false));
            PartitionSyncConfiguration config = new PartitionSyncConfiguration("game",_realmUser){SchemaVersion = 2};
            _realm = await Realm.GetInstanceAsync(config);


        }
        else{
            PartitionSyncConfiguration config = new PartitionSyncConfiguration("game",_realmUser){SchemaVersion = 2};
            _realm = Realm.GetInstance(config);
        }
        Debug.Log("GOT REALM INSTANCE");
    }

    private void OnDisable() {
        Debug.Log("Disposed of");
        _realm.Dispose();
    }


    public List<GameModel> QueryDrawingsFromDB(){
        //TODO: Limit query size
        List<GameModel> models = new List<GameModel>();
        var GameModels = _realm.All<GameModel>();
        int count=0;
        foreach(GameModel model in GameModels){
            models.Add(model);
            count++;
        }
        Debug.LogWarning($"There are a total of {count} drawings that are loaded");
        return models;
    }

    public void SaveDrawingToDB(GameModel toSave){
        _realm.Write(()=>{
            _realm.Add(toSave);
        });
    }
}
