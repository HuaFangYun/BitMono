﻿using BitMono.API.Protecting.Contexts;
using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ILogger = Serilog.ILogger;

namespace BitMono.Core.Protecting.Resolvers
{
    public class BitMonoAssemblyResolver
    {
        private readonly IEnumerable<byte[]> m_DependenciesData;
        private readonly ProtectionContext m_ProtectionContext;
        private readonly ILogger m_Logger;

        public BitMonoAssemblyResolver(IEnumerable<byte[]> dependenciesData, ProtectionContext protectionContext, ILogger logger)
        {
            m_DependenciesData = dependenciesData;
            m_ProtectionContext = protectionContext;
            m_Logger = logger.ForContext<BitMonoAssemblyResolver>();
        }

        public Task<bool> ResolveAsync(CancellationToken cancellationToken = default)
        {
            var resolvingSucceed = true;
            foreach (var dependencyData in m_DependenciesData)
            {
                cancellationToken.ThrowIfCancellationRequested();

                m_ProtectionContext.AssemblyResolver.AddToCache(AssemblyDef.Load(dependencyData));
            }

            foreach (var assemblyRef in m_ProtectionContext.ModuleDefMD.GetAssemblyRefs())
            {
                cancellationToken.ThrowIfCancellationRequested();

                try
                {
                    m_Logger.Information("Resolving assembly: " + assemblyRef.Name);
                    m_ProtectionContext.ModuleCreationOptions.Context.AssemblyResolver.ResolveThrow(assemblyRef, m_ProtectionContext.ModuleDefMD);
                }
                catch (Exception ex)
                {
                    resolvingSucceed = false;
                    m_Logger.Error("Failed to resolve dependency {0}, message: ", assemblyRef.FullName, ex.Message);
                }
            }
            return Task.FromResult(resolvingSucceed);
        }
    }
}