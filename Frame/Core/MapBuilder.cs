using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Frame.Core
{
    public class MapBuilder
    {
        Dictionary<String,Object> dict;

        public MapBuilder(HttpRequest request)
        {
            dict = new Dictionary<string, object>();
            foreach (String key in request.QueryString.AllKeys)
            {
                dict.Add(key, request.QueryString[key]);
            }
            foreach (String key in request.Form.AllKeys)
            {
                dict.Add(key, request.Form[key]);
            }
        }

        public Dictionary<String, Object> getDictionary()
        {
            return dict;
        }
    }
}
