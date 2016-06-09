using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoLIC_WOz_Core.Model
{
    public class THistory
    {
        int _id;
        int _simulation_id;
        int _user_tu_id;
        string _user_note;
        int _designer_tu_id;
        string _designer_note;
        DateTime _dialogDateTime;

        public THistory(int simulation_id, int user_tu_id, string user_note, int designer_tu_id, string designer_note, DateTime dialogDateTime)
        {
            this.simulation_id = simulation_id;
            this.user_tu_id = user_tu_id;
            this.user_note = user_note;
            this.designer_tu_id = designer_tu_id;
            this.designer_note = designer_note;
            this.dialogDateTime = dialogDateTime;
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int simulation_id
        {
            get { return _simulation_id; }
            set { _simulation_id = value; }
        }

        public int user_tu_id
        {
            get { return _user_tu_id; }
            set { _user_tu_id = value; }
        }

        public string user_note
        {
            get { return _user_note; }
            set { _user_note = value; }
        }

        public int designer_tu_id
        {
            get { return _designer_tu_id; }
            set { _designer_tu_id = value; }
        }

        public string designer_note
        {
            get { return _designer_note; }
            set { _designer_note = value; }
        }

        public DateTime dialogDateTime
        {
            get { return _dialogDateTime; }
            set { _dialogDateTime = value; }
        }
    }
}
