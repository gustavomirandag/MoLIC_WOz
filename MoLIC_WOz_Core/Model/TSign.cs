using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoLIC_WOz_Core.Model
{
    public class TSign
    {
        int _dialog_id;
        int _id;
        string _sign;
        string _sign_value;

        public TSign(string sign)
        {
            this.sign = sign;
        }

        public TSign(int id, int dialog_id, string sign, string sign_value)
        {
            this.dialog_id = dialog_id;
            this.id = id;
            this.sign = sign;
            this.sign_value = sign_value;
        }

        public TSign(int dialog_id, string sign, string sign_value)
        {
            this.dialog_id = dialog_id;
            this.sign = sign;
            this.sign_value = sign_value;
        }

        public int dialog_id
        {
            get { return _dialog_id; }
            set { _dialog_id = value; }
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string sign
        {
            get { return _sign; }
            set { _sign = value; }
        }

        public string sign_value
        {
            get { return _sign_value; }
            set { _sign_value = value; }
        }
    }
}
