using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGWP.Models.Templates
{
    public interface BaseTemplate
    {
        string SiteName { get; set; }
        string TransformText();
        IndexList Properties { get; }
        void GenerateProperties();
    }
}
