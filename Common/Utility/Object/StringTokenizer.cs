using System.Collections;
using System.Linq;
using System.Text;

namespace Common.Utility.Object
{
    public class StringTokenizer
    {
        #region Field
        private readonly string[] _parts;
        private int _i;
        #endregion

        #region Constructor
        public StringTokenizer(string str, string delimiters)
        {
            var chars = Encoding.UTF8.GetChars(Encoding.UTF8.GetBytes(delimiters));
            var splitted = str.Split(chars);

            var list = new ArrayList();
            foreach (var lists in splitted.Where(lists => lists != ""))
                list.Add(lists);

            _parts = (string[]) list.ToArray(typeof (string));
        }
        #endregion

        #region Other
        /// <summary>
        /// all token members
        /// </summary>
        public string[] TokenMember
        {
            get { return _parts; }
        }
        /// <summary>
        /// check has more token (combine with NextToken() method)
        /// </summary>
        /// <returns>true or false</returns>
        public bool HasMoreTokens()
        {
            return (_i < _parts.Length);
        }
        /// <summary>
        /// move next token in list
        /// </summary>
        /// <returns></returns>
        public string NextToken()
        {
            return _parts[_i++];
        }
        /// <summary>
        /// Count all tokens numbers 
        /// </summary>
        /// <returns>numbering of tokens</returns>
        public int CountTokens()
        {
            return _parts.Length;
        }
        #endregion
    }
}