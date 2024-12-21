using GiftNotation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using GiftNotation.Models;

namespace GiftNotation.Views
{
    public class GiftNameTemplateSelector : DataTemplateSelector
    {
        public DataTemplate GiftNameWithHyperlinkTemplate { get; set; }
        public DataTemplate GiftNameWithoutHyperlinkTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is DisplayGiftModel gift)
            {
                if (!string.IsNullOrEmpty(gift.Url))
                {
                    return GiftNameWithHyperlinkTemplate;
                }
                return GiftNameWithoutHyperlinkTemplate;
            }

            // Вернуть шаблон по умолчанию или null, если тип не соответствует
            return GiftNameWithoutHyperlinkTemplate;
        }

    }
}
