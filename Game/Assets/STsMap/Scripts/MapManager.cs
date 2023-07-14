using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

namespace Map
{
    public class MapManager : MonoBehaviour
    {
        MapHPUI MHU;
        public MapConfig config;
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
                var mapJson = PlayerPrefs.GetString("Map");
                var map = JsonConvert.DeserializeObject<Map>(mapJson);
                var TampmapJson = PlayerPrefs.GetString("TampMap");
                var Tampmap = JsonConvert.DeserializeObject<Map>(TampmapJson);
                // using this instead of .Contains()
                if (map.path.Any(p => p.Equals(map.GetBossNode().point)))
                {
                    // payer has already reached the boss, generate a new map
                    GenerateNewMap();
                }
                else
                {
                    if(PlayerPrefs.GetInt("StageClear") == 1)
                    {
                    CurrentMap = map;
                    // player has not reached the boss yet, load the current map
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
            var map = MapGenerator.GetMap(config);
            CurrentMap = map;
            Debug.Log(map.ToJson());
            view.ShowMap(map);
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
