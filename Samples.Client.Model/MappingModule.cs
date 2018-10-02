﻿using AutoMapper;
using JetBrains.Annotations;
using Samples.Client.Model.Mappers;
using Solid.Practices.Modularity;

namespace Samples.Client.Model
{   
    [UsedImplicitly]
    internal sealed class MappingModule : IPlainCompositionModule
    {
        public void RegisterModule() => Mapper.Initialize(x => x.AddProfile<MappingProfile>());
    }
}