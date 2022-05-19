using System;
using Akka.Actor;

namespace Akka.Ex1.Extensions
{
    internal static class UntypedActorContextExtensions
    {
        public static IActorRef GetOrCreateActorOf<TActor>(this IUntypedActorContext context, string name)
            where TActor : ActorBase, new()
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            var actor = context.GetActorOf<TActor>(name);
            if (actor.IsNobody())
            {
                actor = context.CreateActorOf<TActor>(name);
            }
            return actor;
        }

        private static IActorRef CreateActorOf<TActor>(this IUntypedActorContext context, string name = null)
            where TActor : ActorBase, new()
        {
            var actorName = !string.IsNullOrWhiteSpace(name) ? GenerateActorName<TActor>(name) : null;
            return context.ActorOf<TActor>(actorName ?? Guid.NewGuid().ToString());
        }

        private static IActorRef GetActorOf<TActor>(this IUntypedActorContext context, string name)
            where TActor : ActorBase
        {
            var actorName = GenerateActorName<TActor>(name);
            var actor = context.Child(actorName);
            return actor;
        }

        private static string GenerateActorName<TActor>(string name) where TActor : ActorBase
        {
            name = name ?? "singleName";
            return $"{typeof(TActor).Name}_{name}";
        }
    }
}