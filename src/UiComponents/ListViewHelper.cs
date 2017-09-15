using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UiComponents
{
    public class ListViewHelper
    {
        private readonly ListView _listView;
        public ListViewHelper(ListView listView)
        {
            _listView = listView;
        }

        public void Clear()
        {
            while(_listView.Items.Count > 0)
            {
                _listView.Items.RemoveAt(_listView.Items.Count - 1);
            }
        }

        public void Add(int index, params object[] fields)
        {
            var item = new ListViewItem(fields.Select(x => x.ToString()).ToArray());
            if(index < _listView.Items.Count)
            {
                _listView.Items[index] = item;
            }
            else
            {
                _listView.Items.Add(item);
            }
        }

        public void Bind<T>(IEnumerable<T> items, Func<T, string[]> func)
        {
            var ix = 0;
            for(; ix < items.Count(); ix++)
            {
                var item = items.ElementAt(ix);
                Add(ix, func(item));
            }
            while(ix++ < _listView.Items.Count)
            {
                _listView.Items.RemoveAt(ix - 1);
            }
        }
    }
}
