using Lib9c.Models.Items;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Mimir.MongoDB.Bson.Serialization.Serializers.Lib9c.Items;

public class WeaponSerializer : ClassSerializerBase<Weapon>
{
    public static readonly WeaponSerializer Instance = new();

    public static Weapon Deserialize(BsonDocument doc) => EquipmentSerializer.Deserialize<Weapon>(doc);

    public override Weapon Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var doc = BsonDocumentSerializer.Instance.Deserialize(context, args);
        return Deserialize(doc);
    }

    // DO NOT OVERRIDE Serialize METHOD: Currently objects will be serialized to Json first.
    // public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Weapon value)
    // {
    //     base.Serialize(context, args, value);
    // }
}
