using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace devDesarrollo.models.Database
{

    public partial class categoria
    {
        public categoria(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
