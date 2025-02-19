using Bencodex.Types;
using Lib9c.Models.Exceptions;
using Lib9c.Models.Extensions;
using MongoDB.Bson.Serialization.Attributes;
using ValueKind = Bencodex.Types.ValueKind;

namespace Lib9c.Models.Mails;

/// <summary>
/// <see cref="Nekoyume.Model.Mail.MaterialCraftMail"/>
/// </summary>
[BsonIgnoreExtraElements]
public record MaterialCraftMail : Mail
{
    public int ItemCount { get; init; }
    public int ItemId { get; init; }

    public override IValue Bencoded => ((Dictionary)base.Bencoded)
        .Add("ic", ItemCount.Serialize())
        .Add("iid", ItemId.Serialize());

    public MaterialCraftMail(IValue bencoded) : base(bencoded)
    {
        if (bencoded is not Dictionary d)
        {
            throw new UnsupportedArgumentTypeException<ValueKind>(
                nameof(bencoded),
                new[] { ValueKind.Dictionary },
                bencoded.Kind);
        }

        ItemCount = d["ic"].ToInteger();
        ItemId = d["iid"].ToInteger();
    }
}
