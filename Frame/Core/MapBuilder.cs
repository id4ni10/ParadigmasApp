using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Frame.Core
{
    public class MapBuilder
    {
        Dictionary<String,Object> dict;

        public MapBuilder(HttpRequest request, GenericController controller)
        {
            dict = new Dictionary<string, object>();
            
            foreach (String key in request.QueryString.AllKeys)
            {
                if(key.Contains("."))
                {
                    Dictionary<String, Object> map = controller.getComplexParams();

                    String[] objetoParametro = key.Split('.');
                    
                    String objetoComplexo = objetoParametro[0];
                    String parametro = objetoParametro[1];

                    if(dict.ContainsKey(objetoComplexo)){
                        object objeto = dict[objetoComplexo];
                        
                        myMethod.Invoke(objeto, new object[] { dict });
                        
                    }

                    Type tipoObjetoComplexo = map[];



                } else 
                {
                    dict.Add(key, request.QueryString[key]);
                }
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
