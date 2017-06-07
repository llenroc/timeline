using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Timeline
{
    public class TimelineTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate messageTemplate = new DataTemplate(typeof(CellMessage));

        private readonly DataTemplate splitterTemplate = new DataTemplate(typeof(CellSplitter));

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            // Select template based on input item's type.
            if (item is DataMessage)
                return messageTemplate;
            if (item is DataSplitter)
                return splitterTemplate;

            throw new ArgumentException("Data type not implemented for " + item);
        }
    }
}
