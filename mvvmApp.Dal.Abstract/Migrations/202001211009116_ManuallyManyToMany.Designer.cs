﻿// <auto-generated />
namespace mvvmApp.Dal.Abstract.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.3.0")]
    public sealed partial class ManuallyManyToMany : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(ManuallyManyToMany));
        
        string IMigrationMetadata.Id
        {
            get { return "202001211009116_ManuallyManyToMany"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}