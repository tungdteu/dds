using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace MiniSharePointComponent.UiEditor
{
    internal class FontEditor : UITypeEditor
    {
        #region Overrider

        /// <summary>
        ///     Style of editor 
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>UIType</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>
        ///     value of object to show
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="provider">Provider</param>
        /// <param name="value">Value </param>
        /// <returns>Object</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var f = new FontDialog();
            if (DialogResult.OK == f.ShowDialog())
            {
                return f.Font;
            }
            
            // ReSharper disable once AssignNullToNotNullAttribute
            return value;
        }

        #endregion
    }
}