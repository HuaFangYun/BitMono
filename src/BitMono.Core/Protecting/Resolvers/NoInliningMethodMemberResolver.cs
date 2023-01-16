﻿namespace BitMono.Core.Protecting.Resolvers;

public class NoInliningMethodMemberResolver : IMemberResolver
{
    private readonly Obfuscation m_Obfuscation;

    public NoInliningMethodMemberResolver(IOptions<Obfuscation> obfuscation)
    {
        m_Obfuscation = obfuscation.Value;
    }

    public bool Resolve([AllowNull] IProtection protection, IMetadataMember member)
    {
        if (m_Obfuscation.NoInliningMethodObfuscationExclude)
        {
            return true;
        }
        if (member is MethodDefinition method)
        {
            if (method.NoInlining)
            {
                return false;
            }
        }
        return true;
    }
}
