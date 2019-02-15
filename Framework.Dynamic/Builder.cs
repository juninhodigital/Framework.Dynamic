using System.Collections.Generic;

namespace Framework.Dynamic
{
    public class Builder
    {
        #region| Methods |

        /// <summary>
        /// Create a new dynamic object
        /// </summary>
        /// <example>
        /// <code>
        ///    var item = Create(new Dictionary<string, object>()
        ///    {
        ///        {"ID", 50},
        ///    });
        /// 
        ///    var dyn = Create(new Dictionary<string, object>()
        ///    {
        ///         {"prop1", 12},
        ///         {"teste", item}
        ///    });
        ///    
        ///   MessageBox.Show(dyn.prop1.ToString());
        ///   MessageBox.Show(dyn.teste.ID.ToString());
        /// 
        /// </code>
        /// </example>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static dynamic Create(Dictionary<string, object> properties)
        {
            return new ObjectBuilder(properties);
        } 
        
        private static void Sample()
        {
            var item = Create(new Dictionary<string, object>()
            {
                {"ID", 50},
            });

            var dyn = Create(new Dictionary<string, object>()
            {
                {"prop1", 12},
                {"teste", item}
            });
        }

        #endregion
    }
}
