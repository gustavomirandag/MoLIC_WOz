using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoLIC_WOz_Core.Model
{
    public class TDialog
    {
        int _transition_id;
        int _id;
        string _xml_id;
        string _dialog;
        public List<TSign> signs;

        public TDialog(int id, int transition_id, string dialog, List<TSign> signs)
        {
            this.id = id;
            this.transition_id = transition_id;
            this.dialog = dialog;
            this.signs = signs;
        }

        public TDialog(int transition_id, string dialog)
        {
            this.transition_id = transition_id;
            this.dialog = dialog;
        }

        public TDialog(string xml_id, string dialog)
        {
            this.xml_id = xml_id;
            this.dialog = dialog;
        }

        /*public List<TSign> signs
        {
            get { return _signs; }
            set { _signs = signs; }
        }*/

        public int transition_id
        {
            get { return _transition_id; }
            set { _transition_id = value; }
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string xml_id
        {
            get { return _xml_id; }
            set { _xml_id = value; }
        }

        public string dialog
        {
            get { return _dialog; }
            set { _dialog = value; }
        }

        public override string ToString()
        {
            return dialog;
        }
    }
}
