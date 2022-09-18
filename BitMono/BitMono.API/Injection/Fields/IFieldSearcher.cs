﻿using dnlib.DotNet;

namespace BitMono.API.Injection.Fields
{
    public interface IFieldSearcher
    {
        FieldDef Find(string name, ModuleDefMD moduleDefMD);
        FieldDef FindInGlobalNestedTypes(string name, ModuleDefMD moduleDefMD);
    }
}