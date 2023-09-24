using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserStoreApi.Models;


    public class User {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id {get; set;} 

        [BsonElement("Name")]
        public string Name {get; set;} = null!;
        public string Age {get; set;}  = null!;
        public string Occupation {get; set;} = null!;
        public string Gender {get; set;} = null!;

    }
