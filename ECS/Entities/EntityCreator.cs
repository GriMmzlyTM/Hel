using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hel.ECS.Entities
{
    public static class EntityCreator 
    {

        private static Dictionary<string, IEntity> entityCache = new Dictionary<string, IEntity>();
        private static JObject json;

        public static IEntity CreateEntity(string entityName) =>
            CreateEntityInternal(entityName);

        public static void LoadJSON(List<string> files) {
            json = new JObject();
            foreach (var file in files) {
                 json.Add(JObject.Parse(File.ReadAllText(@"c:\videogames.json")));
            }
        }


        private static IEntity CreateEntityInternal(string entityName) =>
            json[entityName].ToObject<Entity>();
    }
}
