using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Common.Infrastructure.WebControl
{
    public class ControlFactory
    {
        public static Control GetControlFromName(string controlName,string controlLabelName)
        {
            Control temp;

            switch (controlName.ToLower())
            { 
                case "textbox":
                    temp=new TextBox {ID = "txt" + controlLabelName};
                    break;
                case "textarea":
                    temp = new TextBox {ID = "txt" + controlLabelName};
                    ((TextBox)temp).TextMode = TextBoxMode.MultiLine;
                    break;
                case "calendar":
                    temp = new Calendar {ID = "cld" + controlLabelName};
                    break;
                case "checkbox":
                    temp = new CheckBox {ID = "cbx" + controlLabelName};
                    break;
                case "dropdownlist":
                    temp = new DropDownList {ID = "ddl" + controlLabelName};
                    break;
                case "uploadfile":
                    temp = new FileUpload {ID = "uf" + controlLabelName};
                    break;
                case "hyperlink":
                    temp = new HyperLink {ID = "hyl" + controlLabelName};
                    break;
                case "image":
                    temp = new Image {ID = "img" + controlLabelName};
                    break;
                case "password":
                    temp = new TextBox {ID = "txt" + controlLabelName};
                    ((TextBox)temp).TextMode = TextBoxMode.Password;
                    break;
                case "listbox":
                    temp = new ListBox {ID = "lb" + controlLabelName};
                    break;
                case "gridview":
                    temp = new GridView {ID = "grv" + controlLabelName};
                    break;
                default: 
                    throw new NotSupportedException("didnot find the supported control");
            }

            return temp;
        }
    }
}
