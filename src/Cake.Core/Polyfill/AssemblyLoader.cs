﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Cake.Core.IO;
using System.Reflection;

#if NETCORE
using System.Runtime.Loader;
#endif

namespace Cake.Core.Polyfill
{
    internal sealed class AssemblyLoader
    {
        public static Assembly LoadFromPath(FilePath path)
        {
            return LoadFromString(path.FullPath);
        }

        public static Assembly LoadFromString(string path)
        {
#if NETCORE
            return AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
#else
            return Assembly.LoadFrom(path);
#endif
        }
    }
}
