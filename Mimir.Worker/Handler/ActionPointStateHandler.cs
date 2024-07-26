using Bencodex;
using Bencodex.Types;
using Mimir.MongoDB.Bson;

namespace Mimir.Worker.Handler;

public class ActionPointStateHandler : IStateHandler
{
    public IBencodable ConvertToState(StateDiffContext context)
    {
        if (context.RawState is not Integer value)
        {
            throw new InvalidCastException(
                $"{nameof(context.RawState)} Invalid state type. Expected {nameof(Integer)}, got {context.RawState.GetType().Name}."
            );
        }

        return new ActionPointState(value);
    }
}
