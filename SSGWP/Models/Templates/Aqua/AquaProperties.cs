using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGWP.Models.Templates.Aqua
{
    partial class Aqua : BaseTemplate
    {
        public String SiteName { get; set; }
        public IndexList Properties { get; }
        public String PreviewUrl = "https://i.pinimg.com/280x280_RS/95/5b/31/955b31fd240a052d0ba51594ac4bb77a.jpg";

        public Aqua() { Properties = new IndexList(); }
        public Aqua(String name,bool defaultProps=false)
        {
            SiteName = name;
            Properties = new IndexList();
            if(defaultProps)
            GenerateProperties();
        }

        public void FillProps(Dictionary<string,string> props)
        {
            foreach(string key in props.Keys)
            {
                if (key != "" || key != "submit" || key!= "update")
                    if(key.Contains("Color"))
                        Properties.Add(new Property(key,PropertyType.Color,props[key]));
                    else
                        Properties.Add(new Property(key, PropertyType.Text, props[key]));
            }
        }

        public void GenerateProperties()
        {
            Properties.Add(new Property("SiteName", PropertyType.Text, SiteName));
            Properties.Add(new Property("FirstSectionColor", PropertyType.Color, "#000000"));
            Properties.Add(new Property("LogoURL", PropertyType.Text, ""));
            Properties.Add(new Property("Motto", PropertyType.Text, "Your Motto"));
            Properties.Add(new Property("MottoColor", PropertyType.Color, "#FF0000"));
            Properties.Add(new Property("MainSectionBgColor", PropertyType.Color, "#F00000"));
            Properties.Add(new Property("MainSectionTxtColor", PropertyType.Color, "#0F0F00"));
            Properties.Add(new Property("MainSection", PropertyType.Text, "Your main section"));
            Properties.Add(new Property("PictureUrl", PropertyType.Text, "Your picture"));
            Properties.Add(new Property("Projects", PropertyType.Text, "Your projects"));
            Properties.Add(new Property("ContactSectionBgColor", PropertyType.Color, "#F00000"));
            Properties.Add(new Property("ContactSectionTxtColor", PropertyType.Color, "#0F0F00"));
            Properties.Add(new Property("Email", PropertyType.Text, "Your Email"));
            Properties.Add(new Property("Phone", PropertyType.Text, "Your Phone"));
            Properties.Add(new Property("Address", PropertyType.Text, "Your Address"));
        }
    }
}
