using System.Collections.Generic;
using System.Dynamic;

namespace Framework.Dynamic
{
    /// <summary>
    /// Dynamic object builder
    /// </summary>
    public sealed class ObjectBuilder : DynamicObject
    {
        #region| Fields |

        private readonly Dictionary<string, object> properties;

        #endregion

        #region| Constructor |

        public ObjectBuilder(Dictionary<string, object> properties)
        {
            this.properties = properties;
        }

        #endregion

        #region| Methods |

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return properties.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (properties.ContainsKey(binder.Name))
            {
                result = properties[binder.Name];
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (properties.ContainsKey(binder.Name))
            {
                properties[binder.Name] = value;
                return true;
            }
            else
            {
                return false;
            }
        } 

        #endregion
    }
}
