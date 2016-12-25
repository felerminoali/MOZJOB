using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PortalEmprego_Wth_MemberShip_And_mvc5.CustomHtmlHelpers
{
    public class LinkedSelectList : IEnumerable<LinkedSelectListItem>
    {
        public string DataTextField { get; private set; }
        public string DataValueField { get; private set; }
        public string DataLinkedValueField { get; private set; }

        public IEnumerable Items { get; private set; }
        public IEnumerable SelectedValues { get; private set; }

        public LinkedSelectList(IEnumerable items, string dataValueField, string dataTextField, string dataLinkedValueField, IEnumerable selectedValues)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            Items = items;
            DataValueField = dataValueField;
            DataTextField = dataTextField;
            DataLinkedValueField = dataLinkedValueField;
            SelectedValues = selectedValues;
        }

        public virtual IEnumerator<LinkedSelectListItem> GetEnumerator()
        {
            return GetListItems().GetEnumerator();
        }

        internal IList<LinkedSelectListItem> GetListItems()
        {
            return GetListItemsWithValueField();
        }

        private IList<LinkedSelectListItem> GetListItemsWithValueField()
        {
            HashSet<string> selectedValues = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (SelectedValues != null)
            {
                selectedValues.UnionWith(from object value in SelectedValues select Convert.ToString(value, CultureInfo.CurrentCulture));
            }

            var listItems = from object item in Items
                            let value = Eval(item, DataValueField)
                            select new LinkedSelectListItem
                            {
                                Value = value,
                                Text = Eval(item, DataTextField),
                                LinkValue = Eval(item, DataLinkedValueField),
                                Selected = selectedValues.Contains(value)
                            };
            return listItems.ToList();
        }

        private static string Eval(object container, string expression)
        {
            object value = container;
            if (!String.IsNullOrEmpty(expression))
            {
                value = DataBinder.Eval(container, expression);
            }
            return Convert.ToString(value, CultureInfo.CurrentCulture);
        }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}