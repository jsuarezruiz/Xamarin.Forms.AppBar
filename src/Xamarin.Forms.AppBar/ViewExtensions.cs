using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xamarin.Forms
{
    public static class ViewExtensions
    {
        public static IEnumerable<T> GetChildrenOfType<T>(this Element element) where T : Element
        {
            var properties = element.GetType().GetRuntimeProperties();

            var contentProperty = properties.FirstOrDefault(w => w.Name == "Content");

            if (contentProperty != null)
            {
                if (contentProperty.GetValue(element) is Element content)
                {
                    if (content is T)
                    {
                        yield return content as T;
                    }

                    foreach (var child in content.GetChildrenOfType<T>())
                    {
                        yield return child;
                    }
                }
            }
            else
            {
                var childrenProperty = properties.FirstOrDefault(w => w.Name == "Children");

                if (childrenProperty != null)
                {
                    IEnumerable children = childrenProperty.GetValue(element) as IEnumerable;

                    foreach (var child in children)
                    {
                        if (child is Element childVisualElement)
                        {
                            if (childVisualElement is T)
                            {
                                yield return childVisualElement as T;
                            }

                            foreach (var childVisual in childVisualElement.GetChildrenOfType<T>())
                            {
                                yield return childVisual;
                            }
                        }
                    }
                }
            }
        }
    }
}