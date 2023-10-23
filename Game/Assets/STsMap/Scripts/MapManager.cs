using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Analytics;
using UnityEngine.UI;

namespace Map
{
    public class MapManager : MonoBehaviour
    {
        public MapConfig config1;

        public MapConfig config2;

        public MapConfig config3;
        public MapView view;

        public Map CurrentMap { get; private set; }

        private void Start()
        {   
            if (PlayerPrefs.GetInt("GameOver")==1){
                PlayerInformation.PlayerInfo.playerInfo.newGame();
                GenerateNewMap();
                SaveMap();
                SaveTampMap();
                PlayerPrefs.SetInt("GameOver",0);
            }
            else{
            if (PlayerPrefs.HasKey("Map"))
            {
                PlayerInformation.PlayerInfo.playerInfo.LoadPlayerInfo();
                var mapJson = PlayerPrefs.GetString("Map");
                var map = JsonConvert.DeserializeObject<Map>(mapJson);
                var TampmapJson = PlayerPrefs.GetString("TampMap");
                var Tampmap = JsonConvert.DeserializeObject<Map>(TampmapJson);
                // using this instead of .Contains()
                if (map.path.Any(p => p.Equals(map.GetBossNode().point)))
                {               
                    // payer has already reached the boss, generate a new map        
                  
                    if(PlayerPrefs.GetInt("StageClear") == 1)
                    {
                      GenerateNextMap();
                    }
                    else
                    {
                        CurrentMap = Tampmap;
                  
                         view.ShowMap(Tampmap);
                    }
                }
                else
                {
                    // player has not reached the boss yet, load the current map
                    if(PlayerPrefs.GetInt("StageClear") == 1)
                    {
                    CurrentMap = map;
                    
                    view.ShowMap(map);
                    }
                    else
                    {
                        CurrentMap = Tampmap;
                  
                    view.ShowMap(Tampmap);
                    }
                
                }
                
            }
            else
            {
                GenerateNewMap();
            }
            }
        }

        public void GenerateNewMap()
        {
            
                         var map = MapGenerator.GetMap(config1);
                         CurrentMap = map;
                         Debug.Log(map.ToJson());
                          view.ShowMap(map);
            int i = PlayerPrefs.GetInt("CrrStage");
            Debug.Log("crrmap"+i);
            
        }
        
     public void GenerateNextMap()
        {   
            int i = PlayerPrefs.GetInt("CrrStage");
            i++;
            switch(i){

            case 2:
            PlayerPrefs.SetInt("CrrStage",2);
            var map2 = MapGenerator.GetMap(config2);
            CurrentMap = map2;
            view.ShowMap(map2);
            
            break;

            case 3:
                    PlayerPrefs.SetInt("CrrStage",3);
                    var map3 = MapGenerator.GetMap(config3);
                     CurrentMap = map3;
                     view.ShowMap(map3);
                    
            break;

            default:
             PlayerPrefs.SetInt("CrrStage",1);
                GenerateNewMap();
                
            break;
            }
            int c = PlayerPrefs.GetInt("CrrStage");
            Debug.Log("crrmap"+c);
        }
        

        public void SaveMap()
        {
            if (CurrentMap == null) return;
            var settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            var json = JsonConvert.SerializeObject(CurrentMap, settings);
            PlayerPrefs.SetString("Map", json);
            PlayerPrefs.Save();
        }

        private void OnApplicationQuit()
        {
            SaveMap();
        }
         public void SaveTampMap()
        {
            if (CurrentMap == null) return;
            var settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            var Tampjson = JsonConvert.SerializeObject(CurrentMap, settings);
            PlayerPrefs.SetString("TampMap", Tampjson);
            PlayerPrefs.Save();
        }

        
    }
}
