﻿global using AsmResolver;
global using AsmResolver.DotNet;
global using AsmResolver.DotNet.Builder;
global using AsmResolver.DotNet.Serialized;
global using AsmResolver.PE.DotNet.Builder;
global using BitMono.Core.Extensions;
global using BitMono.Shared.Models;
global using System;
global using System.Collections.Generic;
global using System.Diagnostics;
global using System.Diagnostics.CodeAnalysis;
global using System.IO;
global using System.IO.Compression;
global using System.Linq;
global using System.Text;
global using System.Threading;
global using System.Threading.Tasks;
global using AsmResolver.PE.DotNet;
global using AsmResolver.PE.File.Headers;
global using BitMono.API;
global using BitMono.API.Pipeline;
global using BitMono.Core.Contexts;
global using BitMono.Core.Pipeline;
global using BitMono.Core.Resolvers;
global using BitMono.Core.Services;
global using BitMono.Obfuscation.Files;
global using BitMono.Obfuscation.Logging;
global using BitMono.Obfuscation.Modules;
global using BitMono.Obfuscation.Notifiers;
global using BitMono.Obfuscation.Protections;
global using BitMono.Obfuscation.Referencing;
global using BitMono.Obfuscation.Stripping;
global using BitMono.Utilities.AsmResolver;
global using BitMono.Utilities.Runtime;
global using BitMono.Utilities.Time;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Pocket.Extensions;
global using ILogger = Serilog.ILogger;