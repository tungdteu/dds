using System.Web.UI;

[assembly: WebResource("MiniSharePointComponent.Js.jquery-2.1.3.js","application/x-javascript")]
namespace MiniSharePointComponent.Js
{

    /// <summary>
    /// Helps include embedded JavaScript files in pages.
    /// </summary>
    /// <remarks>
    /// It your turn http://www.codeproject.com/Articles/196727/Managing-Your-JavaScript-Library-in-ASP-NET .
    /// Read it and try to practice !
    /// </remarks>
    public class JavaScriptHelper
    {
        #region Constants

        private const string Jquery ="MiniSharePointComponent.Js.jquery-2.1.3.js";
        private const string ChartJs = "MiniSharePointComponent.Chart.js";

        #endregion

        #region Public Methods

        /// <summary>
        /// Includes jquery.js in the page.
        /// </summary>
        /// <param name="manager">Accessible via Page.ClientScript.</param>
        /// <remarks>
        /// Jquery version 2.1.3
        /// </remarks>
        public static void Include_JQuery(ClientScriptManager manager)
        {
            IncludeJavaScript(manager, Jquery);
        }

        /// <summary>
        /// Includes chart.js in the page.
        /// </summary>
        /// <param name="manager">Accessible via Page.ClientScript.</param>
        /// <remarks>
        /// Chart.js version 1.0.1
        /// </remarks>
        public static void Include_ChartJS(ClientScriptManager manager)
        {
            IncludeJavaScript(manager, ChartJs);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Includes the specified embedded JavaScript file in the page.
        /// </summary>
        /// <param name="manager">Accessible via Page.ClientScript.</param>
        /// <param name="resourceName">The name used to identify the 
        /// embedded JavaScript file.
        /// </param>
        private static void IncludeJavaScript
        (ClientScriptManager manager, string resourceName)
        {
            var type = typeof(JavaScriptHelper);
            manager.RegisterClientScriptResource(type, resourceName);
        }

        #endregion
    }
}