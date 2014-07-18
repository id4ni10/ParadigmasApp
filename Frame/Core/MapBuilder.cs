using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Reflection;

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
                    criarObjetoComplexo(request, controller, key, request.QueryString[key]);
                } else 
                {
                    dict.Add(key, request.QueryString[key]);
                }
            }
            foreach (String key in request.Form.AllKeys)
            {

                if (key.Contains("."))
                {
                    criarObjetoComplexo(request, controller, key, request.Form[key]);
                }
                else
                {
                    dict.Add(key, request.Form[key]);
                }
                
            }
        }

        private void criarObjetoComplexo(HttpRequest request, GenericController controller, String key, String valor)
        {
            Dictionary<String, Object> map = controller.getComplexParams();

            String[] objetoParametro = key.Split('.');

            String objetoComplexo = objetoParametro[0];
            String property = objetoParametro[1];

            object objeto;
            if (dict.ContainsKey(objetoComplexo))
            {
                objeto = dict[objetoComplexo];
            }
            else
            {
                objeto = map[objetoComplexo];
            }

            PropertyInfo myProperty = objeto.GetType().GetProperty(property);
            myProperty.SetValue(objeto, valor, null);
            dict[objetoComplexo] = objeto;
        }

        public Dictionary<String, Object> getDictionary()
        {
            return dict;
        }


    }
}
