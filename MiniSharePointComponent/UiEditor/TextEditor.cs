using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using MiniSharePointComponent.UI;

namespace MiniSharePointComponent.UiEditor
{
    public class TextEditor : UITypeEditor
    {
        #region Overrider

        /// <summary>
        ///     Indicate Dropdraw style.
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>UIType</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        /// <summary>
        ///     Get value .
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="provider">Provider</param>
        /// <param name="value">Value </param>
        /// <returns>Object</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var edSvc = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
            if (edSvc != null)
            {
                using (var txtControl = new TextController())
                {
                    if (value != null) txtControl.Text = value.ToString();
                    edSvc.DropDownControl(txtControl);
                    return txtControl.Text;
                }
            }
            // ReSharper disable once AssignNullToNotNullAttribute
            return value;
        }

        #endregion
    }
}