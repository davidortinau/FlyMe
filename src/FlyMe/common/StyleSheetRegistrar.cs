using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Maui.Controls.StyleSheets;

namespace FlyMe.common
{
    // https://gist.github.com/bbenetskyy/4d24db438ecde48a2b359e5449ffbc51
    public static class StyleSheetRegistrar
    {
        public static void RegisterStyle(string name, Type targetType, string bindablePropertyName)
        {
            var stylePropertyInfo = typeof(Microsoft.Maui.Controls.Internals.Registrar).GetProperty("StyleProperties",
                BindingFlags.Static | BindingFlags.NonPublic);
            if (stylePropertyInfo == null)
                return;

            var styleProperties = stylePropertyInfo.GetValue(null);

            var styleAttributeType = typeof(StyleSheet).Assembly.GetType("Microsoft.Maui.StyleSheets.StylePropertyAttribute");
            var styleAttributeInstance = Activator.CreateInstance(styleAttributeType, name, targetType, bindablePropertyName);

            var dictionaryAdd = styleProperties.GetType().GetMethod("Add");
            if (dictionaryAdd == null)
                return;

            var styleListType = typeof(List<>).MakeGenericType(styleAttributeType);
            var styleList = (IList)Activator.CreateInstance(styleListType);

            styleList.Add(styleAttributeInstance);
            dictionaryAdd.Invoke(styleProperties, new object[] { name, styleList });
        }
    }
}
