using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace PrincePortalWeb.Common
{
    public class UtilsRepeater
    {
        public static bool IsItemRow(RepeaterItem item)
        {
            bool isItemRow = false;

            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                isItemRow = true;
            }

            return isItemRow;
        }

        public static Control GetCtrlFromItem(RepeaterItem item, string ctrlId)
        {
            Control ctrl = (Control)item.FindControl(ctrlId);
            
            if (ctrl == null)
            {
                throw new Exception(String.Format("Control {0} not found in repeater item.", ctrlId));
            }

            return ctrl;
        }

        public static Literal GetLiteralCtrlFromItem(RepeaterItem item, string literalId)
        {
            return (Literal)UtilsRepeater.GetCtrlFromItem(item, literalId);
        }

        public static RepeaterItem FindCheckedRepeaterItem(Repeater repeater, string controlName)
        {
            foreach (RepeaterItem repeaterItem in repeater.Items)
            {
                RadioButton radioButton = (RadioButton)GetCtrlFromItem(repeaterItem, controlName);
                if (radioButton.Checked)
                    return repeaterItem;
            }

            return null;
        }
    }
}
