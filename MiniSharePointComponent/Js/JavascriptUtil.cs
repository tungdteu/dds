namespace MiniSharePointComponent.Js
{
    public static class JavascriptUtil
    {
        public static string WrapScriptToString(string data)
        {
            return string.Concat("<script type='text/javascript'>", data, "</script>");
        }
    }
}